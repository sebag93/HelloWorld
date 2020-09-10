using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            InitializeComponent();

            CreateLayout();
        }

        private void CreateLayout()
        {
            var gridContent = new Grid
            {
                Padding = new Thickness(30),
                ColumnSpacing = 0,
                RowSpacing = 0,
                BackgroundColor = Color.FromHex("#181818")
            };

            gridContent.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition{ Height = new GridLength(1.0, GridUnitType.Star)},
                new RowDefinition{ Height = new GridLength(140, GridUnitType.Absolute)},
                new RowDefinition{ Height = new GridLength(140, GridUnitType.Absolute)},
                new RowDefinition{ Height = new GridLength(140, GridUnitType.Absolute)},
                new RowDefinition{ Height = new GridLength(1.0, GridUnitType.Star)}
            };

            gridContent.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition{ Width = new GridLength(1.0, GridUnitType.Star)},
                new ColumnDefinition{ Width = new GridLength(1.0, GridUnitType.Star)}
            };

            var titleLabel = new Label
            {
                Text = "Who's Watching?",
                TextColor = Color.White,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            gridContent.Children.Add(titleLabel, 0, 2, 0, 1);

            //User 1
            var profileStackLayout = new StackLayout { Margin = new Thickness(20, 0, 0, 0) };
            var boxView = new BoxView
            {
                HeightRequest = 100,
                WidthRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0),
                BackgroundColor = Color.FromHex("#86A73E")
            };
            var userLabel = new Label
            {
                Text = "User 1",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            profileStackLayout.Children.Add(boxView);
            profileStackLayout.Children.Add(userLabel);
            gridContent.Children.Add(profileStackLayout, 0, 1);

            //User 2
            var profileStackLayout_2 = new StackLayout { Margin = new Thickness(0, 0, 20, 0) };
            var boxView_2 = new BoxView
            {
                HeightRequest = 100,
                WidthRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0),
                BackgroundColor = Color.FromHex("#3E4EA7")
            };
            var userLabel_2 = new Label
            {
                Text = "User 2",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            profileStackLayout_2.Children.Add(boxView_2);
            profileStackLayout_2.Children.Add(userLabel_2);
            gridContent.Children.Add(profileStackLayout_2, 1, 1);

            //User 3
            var profileStackLayout_3 = new StackLayout { Margin = new Thickness(20, 0, 0, 0) };
            var boxView_3 = new BoxView
            {
                HeightRequest = 100,
                WidthRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0),
                BackgroundColor = Color.FromHex("#3EA75A")
            };
            var userLabel_3 = new Label
            {
                Text = "User 3",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            profileStackLayout_3.Children.Add(boxView_3);
            profileStackLayout_3.Children.Add(userLabel_3);
            gridContent.Children.Add(profileStackLayout_3, 0, 2);


            //User 4
            var profileStackLayout_4 = new StackLayout { Margin = new Thickness(0, 0, 20, 0) };
            var boxView_4 = new BoxView
            {
                HeightRequest = 100,
                WidthRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0),
                BackgroundColor = Color.FromHex("#A73E8B")
            };
            var userLabel_4 = new Label
            {
                Text = "User 4",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center
            };
            profileStackLayout_4.Children.Add(boxView_4);
            profileStackLayout_4.Children.Add(userLabel_4);
            gridContent.Children.Add(profileStackLayout_4, 1, 2);

            //Add profile
            var addProfileBoxView = new BoxView
            {
                HeightRequest = 80,
                WidthRequest = 80,
                Margin = new Thickness(20, 0, 0, 0),
                CornerRadius = 40,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White
            };

            var plusLabel = new Label
            {
                Text = "+",
                FontSize = 80,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Margin = new Thickness(20, 12, 0, 0),
                HorizontalOptions = LayoutOptions.Center
            };

            var addProfileLabel = new Label
            {
                Text = "Add Profile",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(20, 0, 0, 0),
                HorizontalOptions = LayoutOptions.Center
            };

            gridContent.Children.Add(addProfileBoxView, 0, 3);
            gridContent.Children.Add(plusLabel, 0, 3);
            gridContent.Children.Add(addProfileLabel, 0, 3);

            this.Content = gridContent;
        }
    }
}