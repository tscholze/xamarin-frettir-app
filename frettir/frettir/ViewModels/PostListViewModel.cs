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
        #region Public properties 

        /// <summary>
        /// Gets the page's title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get 
            {
                if (_feed == null)
                    return "Feed";

                return _feed.Title;
            }
        }

        /// <summary>
        /// Gets the feed's posts.
        /// </summary>
        /// <value>The posts.</value>
        public List<Post> Posts 
        {
            get
            {
                if (_feed == null)
                    return new List<Post>();

                return _feed.Posts;
            }
        }

        /// <summary>
        /// Gets the load feed command.
        /// </summary>
        /// <value>The load feed command.</value>
        public ICommand LoadFeedCommand { get; private set; }

        /// <summary>
        /// Gets the open post URL command.
        /// </summary>
        /// <value>The open post URL command.</value>
        public ICommand OpenPostUrlCommand { get; private set; }

        #endregion

        #region Private properties

        /// <summary>
        /// Underyling feed object.
        /// </summary>
        Feed _feed;

        #endregion

        #region Init

        /// <summary>
        /// Initializes a new instance of the <see cref="T:frettir.ViewModels.PostListViewModel"/> class.
        /// </summary>
        /// <param name="feed">Underlying feed.</param>
        public PostListViewModel(Feed feed)
        {
            SetFeed(feed);
            LoadFeedCommand = new Command(LoadFeedAsync);
            OpenPostUrlCommand = new Command<Post>(OpenPostUrlAsync);
        }

        #endregion

        #region Private helper

        /// <summary>
        /// Sets the underyling feed and updates the UI.
        /// </summary>
        /// <param name="feed">Feed.</param>
        void SetFeed(Feed feed)
        {
            _feed = feed;
            OnPropertyChanged("Title");
            OnPropertyChanged("Posts");
        }

        /// <summary>
        /// Loads the feed async.
        /// </summary>
        void LoadFeedAsync()
        {
            if (_feed == null)
                return;

            SetFeed(WordpressService.GetPosts(_feed.FeedUri));
        }

        /// <summary>
        /// Opens the post URL async.
        /// </summary>
        /// <param name="post">Post.</param>
        async void OpenPostUrlAsync(Post post)
        {
            var uri = new Uri(post.Link);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        #endregion
    }
}
