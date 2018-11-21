using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using frettir.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace frettir
{
    public partial class App : Application
    {
        #region Init

        public App()
        {
            InitializeComponent();

            XF.Material.Forms.Material.Init(this, "Material.Configuration");
            XF.Material.Forms.Material.PlatformConfiguration.ChangeStatusBarColor(Color.Red);

            MainPage = new MainPage();
        }

        #endregion

        #region Event handler

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}
