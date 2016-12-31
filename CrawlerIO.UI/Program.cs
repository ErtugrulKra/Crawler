using CrawlerIO.Data;
using CrawlerIO.Data.Repository;
using CrawlerIO.Lib;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerIO.UI
{

    class Program
    {


        static string pageUrl = "http://www.hackquarters.co";


        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();

            var result = crawler.StartCrawler(pageUrl, pageUrl);

            CrawlingRepository crawlingRepo = new CrawlingRepository();
            var crawling = new Crawlings() { CrawingDate = DateTime.Now, WebSite = pageUrl, WebSiteURL = pageUrl };
            crawlingRepo.Add(crawling);
            crawlingRepo.Save();


            UrlRepository urlRepo = new UrlRepository();
            Urls url = new Urls()
            {
                CrawlingId = crawling.Id,
                Url = crawling.WebSiteURL
            };
            urlRepo.Add(url);
            urlRepo.Save();

            SaveCrawledData(result, url, crawling);


            System.Console.ReadLine();
        }


        static void SaveCrawledData(List<CrawledHtmlNode> result, Urls url, Crawlings crawling)
        {
            ElementRepository elementRepo = new ElementRepository();
            foreach (var item in result)
            {
                elementRepo.Add(new Elements()
                {
                    UrlId = url.Id,
                    ElementType = item.Node,
                    TagName = item.Node,
                    TagAsJson = item.NodeAsJson,
                    TagHash = item.Hash,
                    Navigatable = item.Navigatable,
                    NavigateURL = item.NavigateUrl
                });

            }

            Console.WriteLine("URL:{0}  Tag Count : {1}", url.Url, result.Count);

            elementRepo.Save();

            var NavigatableUrls = result.Where(s => s.Navigatable && !(s.NavigateUrl.Contains(url.Url) || url.Url.Contains(s.NavigateUrl))).ToList();
            if (NavigatableUrls.Count > 0)
            {
                foreach (var item in NavigatableUrls)
                {
                    UrlRepository urlRepo = new UrlRepository();
                    Urls subUrl = new Urls()
                    {
                        CrawlingId = crawling.Id,
                        Url = item.NavigateUrl
                    };
                    urlRepo.Add(subUrl);
                    urlRepo.Save();
                    Crawler crawler = new Crawler();
                    var subResult = crawler.StartCrawler(item.NavigateUrl, pageUrl);

                    SaveCrawledData(subResult, subUrl, crawling);
                }

            }
        }

    }
}
