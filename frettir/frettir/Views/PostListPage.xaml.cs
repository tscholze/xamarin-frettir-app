using System;
using System.Collections.Generic;
using frettir.ViewModels;
using Xamarin.Forms;

namespace frettir.Views
{
    public partial class PostListPage : ContentPage
    {
        PostListViewModel viewModel;

        public PostListPage(PostListViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            Debug.Text = viewModel.urlString;
        }
    }
}
