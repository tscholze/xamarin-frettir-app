using System;

namespace frettir.Models
{
    public class Post
    {
        public string Guid { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
    }
}