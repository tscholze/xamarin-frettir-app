using System;
using System.Collections.Generic;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class PostListPage : ContentPage
    {
        PostListViewModel viewModel;

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
    }
}
