using HelloWorld.Models;
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
    public partial class ListViewCodeBehind : ContentPage
    {
        public ListViewCodeBehind()
        {
            InitializeComponent();

            List<Car> carList = new List<Car>
            {
                new Car{ Name = "Audi A4", Year = 2010},
                new Car{ Name = "Mercedes CLA", Year = 2012},
                new Car{ Name = "Ford Kuga", Year = 2018},
                new Car{ Name = "Ferrari California", Year = 2015},
                new Car{ Name = "Lamborghini Gallardo", Year = 2006},
                new Car{ Name = "BMW X5", Year = 2020},
                new Car{ Name = "Maserati granturismo s coupe", Year = 2019}
            };

            CreateListView(carList);
        }

        private void CreateListView(List<Car> carList)
        {
            var carListView = new ListView();
            carListView.ItemsSource = carList;
            carListView.HasUnevenRows = true;


            carListView.ItemTemplate = new DataTemplate(typeof(CustomListViewCell));
            this.Content = carListView;
        }
    }

    public class CustomListViewCell : ViewCell
    {
        public CustomListViewCell()
        {
            var mainStackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(15, 0, 15, 0)
            };

            var boxView = new BoxView
            {
                HeightRequest = 50,
                WidthRequest = 50,
                BackgroundColor = Color.Black,
                Margin = new Thickness(5),
                VerticalOptions = LayoutOptions.Center
            };
            mainStackLayout.Children.Add(boxView);

            var verticalStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            mainStackLayout.Children.Add(verticalStackLayout);

            var titleLabel = new Label
            {
                FontSize = 16,
                WidthRequest = 100
            };
            titleLabel.SetBinding(Label.TextProperty, "Name");
            verticalStackLayout.Children.Add(titleLabel);

            var yearLabel = new Label
            {
                FontSize = 12
            };
            yearLabel.SetBinding(Label.TextProperty, "Year");
            verticalStackLayout.Children.Add(yearLabel);

            var button = new Button
            {
                Text = "Details",
                WidthRequest = 80,
                HeightRequest = 40,
                VerticalOptions = LayoutOptions.Center
            };
            button.Clicked += Button_Clicked;
            mainStackLayout.Children.Add(button);

            View = mainStackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;
            App.Current.MainPage.DisplayAlert("Wybrany samochód", car.Name, "Ok");
        }
    }
}