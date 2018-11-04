using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using frettir.Models;

namespace frettir.Services
{
    public static class WordpressService
    {
        public static IEnumerable<Post> GetPosts(string urlString)
        {
            var list = new List<Post>();
            var client = new WebClient();
            var rssString = client.DownloadString(urlString);

            XDocument doc = XDocument.Parse(rssString);
            list = (from item in doc.Element("rss").Element("channel").Elements("item")
                    select new Post
                    {
                        Title = item.Element("title").Value,
                        Link = item.Element("link").Value,
                        PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                        Guid = item.Element("guid").Value
                    }).ToList();

            return list;
        }
    }
}
