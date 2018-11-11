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
        public static Feed GetPosts(string urlString)
        {
            var client = new WebClient();
            var rssString = client.DownloadString(urlString);

            XDocument doc = XDocument.Parse(rssString);
            XElement channel = doc.Element("rss").Element("channel");

            var list = (from item in channel.Elements("item")
                        select new Post
                        {
                            Title = item.Element("title").Value,
                            Link = item.Element("link").Value,
                            PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                            Guid = item.Element("guid").Value
                        }).ToList();

            var feed = new Feed();
            feed.Title = channel.Element("title").Value;
            feed.Posts = list;

            return feed;
        }
    }
}
