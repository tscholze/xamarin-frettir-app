using System;
using System.Collections.Generic;
using frettir.Utils;

namespace frettir.Models
{
    public class Feed
    {
        /// <summary>
        /// The title.
        /// </summary>
        public string Title;

        /// <summary>
        /// Gets the shortend title.
        /// </summary>
        /// <value>The shortend title.</value>
        public string ShortendTitle
        {
            get
            {
                return Title.Substring(0, Constants.SHORTEND_FEED_TITLE_LENGTH);
            }
        }

        /// <summary>
        /// The URI to the feed.
        /// E.g. https://example.org/feed
        /// </summary>
        public string FeedUri;

        /// <summary>
        /// The posts.
        /// </summary>
        public List<Post> Posts;
    }
}