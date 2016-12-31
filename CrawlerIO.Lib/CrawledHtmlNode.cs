using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerIO.Lib
{
    public class CrawledHtmlNode
    {
        readonly Regex urlData = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)", RegexOptions.Compiled);
        readonly Regex urlParts = new Regex(@"(https?)://([a-z0-9]+)?([.]?)([a-z]*[.][a-z]+)", RegexOptions.Compiled);


        

        public string Node { get; set; }

        public string NodeAsJson { get; set; }

        public string WebSite { get; set; }
        public string URL { get; set; }

        public bool Navigatable { get; set; }
        public string NavigateUrl
        {
            get
            {
                if (Node == "a")
                {
                    Match urlMatch = urlData.Match(NodeAsJson);
                   
                    if (urlMatch.Captures.Count > 0)
                    {
                        Match baseUrl = urlParts.Match(URL);
                        Match compareURL = urlParts.Match(urlMatch.Captures[0].Value);
                        if (urlMatch.Captures[2] == baseUrl.Captures[2])
                        {
                            urlMatch = urlData.Match(NodeAsJson);
                            Navigatable = true;
                            return urlMatch.Captures[0].Value;
                        }

                    }
                }
                return "";
            }
        }


        public string Hash
        {
            get { return getMd5Hash(this.AsString()); }
        }

        public string AsString()
        {
            return string.Format("{0} \t{1} \t {2} \t {3}", WebSite, URL, Node, NodeAsJson);
        }

        public override string ToString()
        {
            return string.Format("{0} \t {1} \t {2} \t {3} \n", Hash, Navigatable, NavigateUrl, this.AsString());
        }

        private string getMd5Hash(string content)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(content));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
