using System;
using System.Collections.Generic;
using System.Windows.Input;
using frettir.Models;
using frettir.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace frettir.ViewModels
{
    public class PostListViewModel: BaseViewModel
    {
        public string Title
        {
            get { return "Title"; }
        }

        public List<Post> Posts { get; private set; }

        public ICommand LoadFeedCommand { get; private set; }

        public ICommand OpenPostUrlCommand { get; private set; }

        private string _urlString;

        public PostListViewModel(string urlString)
        {
            _urlString = urlString;
            LoadFeedCommand = new Command(LoadFeedAsync);
            OpenPostUrlCommand = new Command<Post>(OpenPostUrlAsync);
        }

        private void LoadFeedAsync()
        {
            Posts = WordpressService.GetPosts(_urlString);
            OnPropertyChanged("Posts");
        }

        private async void OpenPostUrlAsync(Post post)
        {
            var uri = new Uri(post.Link);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
