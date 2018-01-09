using System;
using Xamarin.Forms;
using Innebandy.Models;
using System.Collections.ObjectModel;
using Innebandy;

namespace Innebandy.Views
{
    public class StandingPage : ContentPage
    {
        ObservableCollection<TeamStanding> StandingList = new ObservableCollection<TeamStanding>();
        Button total;
        Button home;
        Button away;

        public StandingPage()
        {
            var header = new Grid();
            header.ColumnSpacing = 0;
            header.Padding = new Thickness(5, 5, 5, 0);
            header.BackgroundColor = Color.FromRgb(52, 152, 218);

            header.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            total = new Button();
            total.Text = "Total";
            total.TextColor = Color.FromRgb(255, 255, 51);
            total.BorderWidth = 1;
            total.BorderRadius = 0;
            total.BorderColor = Color.FromRgb(255, 255, 51);
            total.BackgroundColor = Color.FromRgb(52, 152, 218);

            home = new Button();
            home.Text = "Hemma";
            home.TextColor = Color.FromRgb(255, 255, 51);
            home.BorderWidth = 1;
            home.BorderRadius = 0;
            home.BorderColor = Color.FromRgb(255, 255, 51);
            home.BackgroundColor = Color.FromRgb(52, 152, 218);

            away = new Button();
            away.Text = "Borta";
            away.TextColor = Color.FromRgb(255, 255, 51);
            away.BorderWidth = 1;
            away.BorderRadius = 0;
            away.BorderColor = Color.FromRgb(255, 255, 51);
            away.BackgroundColor = Color.FromRgb(52, 152, 218);

            header.Children.Add(total, 0, 0);
            header.Children.Add(home, 1, 0);
            header.Children.Add(away, 2, 0);

            total.Clicked += GetTotalStandings;
            home.Clicked += GetHomeStandings;
            away.Clicked += GetAwayStandings;

            var standingDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.Margin = new Thickness(0, 0, 0, 1);
                grid.BackgroundColor = Color.FromRgb(245, 245, 220);
                grid.Padding = new Thickness(0, 5);

                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 50 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 20 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 20 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 10 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 40 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                var rankLabel = new Label { HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold, FontSize = 40 };
                var nameLabel = new Label{ TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold };
                var playedLabel = new Label { TextColor = Color.FromRgb(52, 152, 218) };
                var winLabel = new Label{ HorizontalTextAlignment = TextAlignment.End, TextColor = Color.FromRgb(52, 152, 218) };
                var drawLabel = new Label{ HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218) };
                var lossLabel = new Label{ HorizontalTextAlignment = TextAlignment.Start, TextColor = Color.FromRgb(52, 152, 218) };
                var scoreForLabel = new Label{ HorizontalTextAlignment = TextAlignment.End, TextColor = Color.FromRgb(52, 152, 218) };
                var scoreAgainstLabel = new Label{ HorizontalTextAlignment = TextAlignment.Start, TextColor = Color.FromRgb(52, 152, 218) };
                var dividingLabel = new Label{ Text= "-", HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218)  };
                var scoreDiffLabel = new Label{ HorizontalTextAlignment = TextAlignment.End, TextColor = Color.FromRgb(52, 152, 218) };
                var pointsLabel = new Label { HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, TextColor = Color.FromRgb(52, 152, 218), FontAttributes = FontAttributes.Bold, FontSize = 27 };

                rankLabel.SetBinding(Label.TextProperty, "rank");
                nameLabel.SetBinding(Label.TextProperty, "team.name");
                playedLabel.SetBinding(Label.TextProperty, "played");
                winLabel.SetBinding(Label.TextProperty, "win");
                drawLabel.SetBinding(Label.TextProperty, "draw");
                lossLabel.SetBinding(Label.TextProperty, "loss");
                scoreForLabel.SetBinding(Label.TextProperty, "score_for");
                scoreAgainstLabel.SetBinding(Label.TextProperty, "score_against");
                scoreDiffLabel.SetBinding(Label.TextProperty, "score_diff");
                pointsLabel.SetBinding(Label.TextProperty, "points");

                grid.Children.Add(rankLabel, 0, 0);
                Grid.SetRowSpan(rankLabel, 2);
                grid.Children.Add(nameLabel, 1, 0);
                Grid.SetColumnSpan(nameLabel, 8);
                grid.Children.Add(playedLabel, 1, 1);
                grid.Children.Add(winLabel, 2, 1);
                grid.Children.Add(drawLabel, 3, 1);
                grid.Children.Add(lossLabel, 4, 1);
                grid.Children.Add(scoreForLabel, 5, 1);
                grid.Children.Add(dividingLabel, 6, 1);
                grid.Children.Add(scoreAgainstLabel, 7, 1);
                grid.Children.Add(scoreDiffLabel, 8, 1);
                grid.Children.Add(pointsLabel, 9, 0);
                Grid.SetRowSpan(pointsLabel, 2);

                return new ViewCell { View = grid };
            });

            var standingView = new ListView();
            standingView.ItemsSource = StandingList;
            standingView.ItemTemplate = standingDataTemplate;
            standingView.HasUnevenRows = true;
            standingView.BackgroundColor = Color.FromRgb(52, 152, 218);
            //standingView.RowHeight = 55;
            standingView.SeparatorVisibility = SeparatorVisibility.None;

            var body = new StackLayout();
            body.Children.Add(standingView);
            body.BackgroundColor = Color.FromRgb(52, 152, 218);

            Populate();

            var layout = new StackLayout();
            layout.Children.Add(header);
            layout.Children.Add(body);
            layout.BackgroundColor = Color.FromRgb(52, 152, 218);


            Title = "Tabell";
            Content = layout;
        }

        async void Populate()
        {
            ChangeButtonColors(total);

            var teams = await App.Manager.GetStandings("total");

            foreach (var team in teams)
            {
                StandingList.Add(team);
            }
        }

        async void GetTotalStandings(object sender, EventArgs e)
        {
            
            ChangeButtonColors(total);

            StandingList.Clear();
            var teams = await App.Manager.GetStandings("total");

            foreach (var team in teams)
            {
                StandingList.Add(team);
            }
        }

        async void GetHomeStandings(object sender, EventArgs e)
        {
            ChangeButtonColors(home);

            StandingList.Clear();
            var teams = await App.Manager.GetStandings("home");

            foreach (var team in teams)
            {
                StandingList.Add(team);
            }
        }

        async void GetAwayStandings(object sender, EventArgs e)
        {
            ChangeButtonColors(away);

            StandingList.Clear();
            var teams = await App.Manager.GetStandings("away");

            foreach (var team in teams)
            {
                StandingList.Add(team);
            }
        }

        private void ChangeButtonColors(Button button)
        {
            total.BackgroundColor = Color.FromRgb(255, 255, 51);
            total.TextColor = Color.FromRgb(52, 152, 218);
        }
    }
}
