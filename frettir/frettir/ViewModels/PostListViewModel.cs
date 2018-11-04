using System;
using System.Collections.Generic;
using frettir.Models;

namespace frettir.ViewModels
{
    public class PostListViewModel: BaseViewModel
    {
        public List<Post> Posts { get; private set; }

        public readonly string urlString;

        public PostListViewModel(string urlString)
        {
            this.urlString = urlString;
        }
    }
}
