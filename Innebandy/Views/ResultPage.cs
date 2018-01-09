using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Innebandy.Models;
using Innebandy.Services;
using Xamarin.Forms;

namespace Innebandy.Views
{
    public class ResultPage : ContentPage
    {
        ObservableCollection<RoundNumber> RoundList = new ObservableCollection<RoundNumber>();

        public ResultPage()
        {
            var titleDataTemplate = new DataTemplate(() =>
            {
                var stack = new StackLayout();

                var titleLabel = new Label { TextColor = Color.White, FontAttributes = FontAttributes.Bold, VerticalTextAlignment = TextAlignment.Center };

                titleLabel.SetBinding(Label.TextProperty, "Title");

                stack.Children.Add(titleLabel);
                stack.HorizontalOptions = LayoutOptions.FillAndExpand;
                //stack.HeightRequest = 25;
                stack.BackgroundColor = Color.FromRgb(52, 152, 218);
                stack.Padding = new Thickness(5,5,5,5);
                //stack.VerticalOptions = LayoutOptions.CenterAndExpand;
                stack.Margin = 0;
                return new ViewCell { View = stack };
            });
                                                      
            var resultDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.Margin = new Thickness(0, 0, 0, 1);
                grid.BackgroundColor = Color.FromRgb(245, 245, 220);
                grid.Padding = new Thickness(0, 10);

                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                var homeTeamNameLabel = new Label { HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold };
                var awayTeamNameLabel = new Label { HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold };
                var homeTeamScoreLabel = new Label { HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold, FontSize = 35 };
                var awayTeamScoreLabel = new Label { HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold, FontSize = 35 };
                var homeExclusionLabel = new Label { HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), };
                var awayExclusionLabel = new Label { HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), };

                homeTeamNameLabel.SetBinding(Label.TextProperty, "home_team_name");
                awayTeamNameLabel.SetBinding(Label.TextProperty, "away_team_name");
                homeTeamScoreLabel.SetBinding(Label.TextProperty, "home_team_score");
                awayTeamScoreLabel.SetBinding(Label.TextProperty, "away_team_score");
                homeExclusionLabel.SetBinding(Label.TextProperty, "home_team_exclusion");
                awayExclusionLabel.SetBinding(Label.TextProperty, "away_team_exclusion");

                grid.Children.Add(homeTeamNameLabel, 0, 0);
                grid.Children.Add(awayTeamNameLabel, 1, 0);
                grid.Children.Add(homeTeamScoreLabel, 0, 1);
                grid.Children.Add(awayTeamScoreLabel, 1, 1);
                grid.Children.Add(homeExclusionLabel, 0, 1);
                grid.Children.Add(awayExclusionLabel, 1, 1);

                return new ViewCell { View = grid };
            });

            var resultView = new ListView();
            resultView.ItemsSource = RoundList;
            resultView.IsGroupingEnabled = true;
            resultView.GroupDisplayBinding = new Binding("Title");
            resultView.GroupHeaderTemplate = titleDataTemplate;
            resultView.ItemTemplate = resultDataTemplate;
            resultView.HasUnevenRows = true;
            //resultView.RowHeight = 75;
            resultView.BackgroundColor = Color.FromRgb(52, 152, 218);
            resultView.SeparatorVisibility = SeparatorVisibility.None;

            var layout = new StackLayout();
            layout.Children.Add(resultView);

            GetResult();

            Title = "Resultat";
            Content = layout;
        }
         
        async void GetResult()
        {
            var result = await App.Manager.GetRounds();

            foreach(var round in result)
            {
                RoundList.Add(round);
            }
        }
    }
}
