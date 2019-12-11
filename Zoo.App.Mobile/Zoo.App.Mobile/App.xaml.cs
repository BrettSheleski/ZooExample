using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zoo.App.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var rootPage = new MainPage();

            NavigationPage navPage = new NavigationPage(rootPage);

            var vm = new MainPageViewModel(navPage.Navigation);

            rootPage.BindingContext = vm;

            MainPage = navPage;
        }

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
    }
}
