using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Innebandy.Views;
using Innebandy.Services;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace Innebandy.Views
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var standing = new Button();
            standing.Text = "Tabell";
            standing.HorizontalOptions = LayoutOptions.Center;
            standing.VerticalOptions = LayoutOptions.Center;
            standing.TextColor = Color.FromRgb(255, 255, 255);
            standing.BackgroundColor = Color.FromRgb(52, 152, 218);
            standing.FontSize = 20;
            standing.WidthRequest = 330;
            standing.HeightRequest = 70;

            var result = new Button();
            result.Text = "Resultat";
			result.HorizontalOptions = LayoutOptions.Center;
            result.VerticalOptions = LayoutOptions.Center;
            result.TextColor = Color.FromRgb(255, 255, 255);
            result.BackgroundColor = Color.FromRgb(52, 152, 218);
            result.FontSize = 20;
            result.WidthRequest = 330;
            result.HeightRequest = 70;

            standing.Clicked += Standings;
            result.Clicked += Result;

            Title = "Svenska Superligan";
            NavigationPage.SetBackButtonTitle(this, "Tillbaka");

            var layout = new StackLayout();
            layout.VerticalOptions = LayoutOptions.Center;
            layout.Spacing = 20;
            layout.Children.Add(standing);
            layout.Children.Add(result);

            BackgroundColor = Color.FromRgb(240, 240, 240);
            Content = layout;
        }

        async void Result(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultPage());
        }

        async void Standings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StandingPage());
        }
    }
}
