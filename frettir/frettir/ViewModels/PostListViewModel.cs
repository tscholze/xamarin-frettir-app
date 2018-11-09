using System;
using System.Collections.Generic;
using System.Windows.Input;
using frettir.Models;
using frettir.Services;
using Xamarin.Forms;

namespace frettir.ViewModels
{
    public class PostListViewModel: BaseViewModel
    {
        public string Title = "Dbudwm";

        public List<Post> Posts { get; private set; }

        public ICommand LoadFeedCommand { get; private set; }

        private string _urlString;

        public PostListViewModel(string urlString)
        {
            _urlString = urlString;
            LoadFeedCommand = new Command(LoadFeedAsync);
        }

        private void LoadFeedAsync()
        {
            Posts = WordpressService.GetPosts(_urlString);
            OnPropertyChanged("Posts");
        }
    }
}
