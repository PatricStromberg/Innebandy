using System;
using Innebandy.Services;
using Innebandy.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Innebandy
{
    public class App : Application
    {
        public static FloorballManager Manager { get; set; }

        public App()
        {
            Manager = new FloorballManager(new ApiService());

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.FromRgb(255, 255, 51) };
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=56bca083-e2a3-4315-9e99-3aaee0c7e967;" + "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));
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
