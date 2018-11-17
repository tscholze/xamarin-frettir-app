using System;
using System.Collections.Generic;
using frettir.Models;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class PostListPage : ContentPage
    {
        #region Properties

        PostListViewModel viewModel;

        #endregion

        #region Init

        public PostListPage()
        {
            // Required for XAML previewer
            InitializeComponent();
        }

        public PostListPage(PostListViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            viewModel.LoadFeedCommand.Execute(null);
        }

        #endregion

        #region Event handler

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedPost = e.Item as Post;
            viewModel.OpenPostUrlCommand.Execute(selectedPost);
        }

        #endregion
    }
}
