using System;

namespace frettir.Models
{
    public class Post
    {
        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        /// <value>The GUID.</value>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The publish date.</value>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the link to the web page.
        /// </summary>
        /// <value>The link to the web page.</value>
        public string Link { get; set; }
    }
}