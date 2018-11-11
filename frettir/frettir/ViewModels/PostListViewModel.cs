using System;
using System.Collections.Generic;
using System.Windows.Input;
using frettir.Models;
using frettir.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace frettir.ViewModels
{
    public class PostListViewModel : BaseViewModel
    {
        #region Members 

        public string Title
        {
            get 
            {
                if (_feed == null)
                    return "Feed";

                return _feed.Title;
            }
        }

        public List<Post> Posts 
        {
            get
            {
                if (_feed == null)
                    return new List<Post>();

                return _feed.Posts;
            }
        }

        public ICommand LoadFeedCommand { get; private set; }

        public ICommand OpenPostUrlCommand { get; private set; }

        Feed _feed;

        readonly string _feedUrlString;

        #endregion

        #region Init

        public PostListViewModel(string feedUrlString)
        {
            _feedUrlString = feedUrlString;
            LoadFeedCommand = new Command(LoadFeedAsync);
            OpenPostUrlCommand = new Command<Post>(OpenPostUrlAsync);
        }

        #endregion

        #region Private helper

        void LoadFeedAsync()
        {

            _feed = WordpressService.GetPosts(_feedUrlString);
            OnPropertyChanged("Title");
            OnPropertyChanged("Posts");
        }

        async void OpenPostUrlAsync(Post post)
        {
            var uri = new Uri(post.Link);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        #endregion
    }
}
