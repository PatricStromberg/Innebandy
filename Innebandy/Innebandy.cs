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
            AppCenter.Start("ios=4645fc84-66d5-417c-98f4-4622ca57fc52;" + "uwp={Your UWP App secret here};" +
                   "android={Your Android App secret here}",
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
