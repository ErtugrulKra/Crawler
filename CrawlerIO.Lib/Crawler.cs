
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Lib
{
    public class Crawler
    {
        public string UrlToCrawl { get; set; }
        public string WebSiteName { get; set; }


        private List<CrawledHtmlNode> crawledHtmlNodes;

        public Crawler()
        {
            crawledHtmlNodes = new List<CrawledHtmlNode>();
        }

        public Crawler(string urlToCrawl, string webSiteName)
            : this()
        {
            this.UrlToCrawl = urlToCrawl;
            this.WebSiteName = webSiteName;

            crawledHtmlNodes = new List<CrawledHtmlNode>();
        }

        public List<CrawledHtmlNode> StartCrawler()
        {
            return StartCrawler(this.UrlToCrawl, this.WebSiteName);
        }

        public List<CrawledHtmlNode> StartCrawler(string urlToCrawl, string webSiteName)
        {
            this.UrlToCrawl = urlToCrawl;
            this.WebSiteName = webSiteName;

            var httpClient = new HttpClient();
            var htmlContent = Task<string>.Run(() => httpClient.GetStringAsync(urlToCrawl));

            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(htmlContent.Result);


            TraceChildNodes(document.DocumentNode.ChildNodes);

            return crawledHtmlNodes;
        }

        private void TraceChildNodes(HtmlNodeCollection htmlNodeCollection)
        {

            foreach (HtmlNode item in htmlNodeCollection)
            {

                Dictionary<string, string> tagAsJson = new Dictionary<string, string>();
                tagAsJson.Add("tag", item.Name);
                tagAsJson.Add("text", item.InnerText);
                foreach (var attribute in item.Attributes)
                {
                    tagAsJson.Add(attribute.Name, attribute.Value);
                }

                var crawlerNode = new CrawledHtmlNode();
                crawlerNode.URL = UrlToCrawl;
                crawlerNode.WebSite = UrlToCrawl;
                crawlerNode.Node = item.Name;
                crawlerNode.NodeAsJson = JsonConvert.SerializeObject(tagAsJson);

                Console.WriteLine(crawlerNode.ToString());

                crawledHtmlNodes.Add(crawlerNode);

                if (item.HasChildNodes)
                    TraceChildNodes(item.ChildNodes);
            }

        }
    }
}
