using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using frettir.Models;

namespace frettir.Services
{
    public static class WordpressService
    {
        #region Private properties

        /// <summary>
        /// The placeholder image URL.
        /// </summary>
        private static readonly string _placeholderImageUrl = "https://dbudwm.files.wordpress.com/2018/03/bildschirmfoto-2018-03-26-um-20-34-43.png";

        #endregion

        #region Public helper

        /// <summary>
        /// Gets the url's feed posts.
        /// </summary>
        /// <returns>The feed's posts.</returns>
        /// <param name="urlString">URL string.</param>
        public static Feed GetPosts(string urlString)
        {
            var client = new WebClient();
            var rssString = client.DownloadString(urlString);

            XDocument doc = XDocument.Parse(rssString);
            XNamespace dc = "http://purl.org/dc/elements/1.1/";
            XNamespace content = "http://purl.org/rss/1.0/modules/content/";

            // Parse list of posts.
            XElement channel = doc.Element("rss").Element("channel");
            var items = (from item in channel.Elements("item")
                         select new Post
                         {
                             Title = item.Element("title").Value,
                             Link = item.Element("link").Value,
                             Author = item.Element(dc + "creator").Value,
                             PublishDate = DateTime.Parse(item.Element("pubDate").Value),
                             Guid = item.Element("guid").Value,
                             Abstract = item.Element("description").Value,
                             Content = item.Element(content + "encoded").Value
                         }).ToList();

            // Post process
            foreach (var item in items)
            {
                var foundImage = Regex.Match(item.Content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;

                if (string.IsNullOrEmpty(foundImage))
                {
                    foundImage = _placeholderImageUrl;
                }

                item.FirstImage = foundImage;
                item.Subtitle = $"{item.PublishDate.ToShortDateString()} - {item.Author}";
            }

            // Create wrapping feed object.
            var feed = new Feed
            {
                Title = channel.Element("title").Value,
                FeedUri = urlString,
                Posts = items
            };

            return feed;
        }

        #endregion
    }
}
