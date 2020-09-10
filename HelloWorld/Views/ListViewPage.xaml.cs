using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ObservableCollection<CarGroup> carList { get; set; }
        public ListViewPage()
        {
            InitializeComponent();

            carList = new ObservableCollection<CarGroup>
            {
                new CarGroup("Samochody sportowe", new List<Car>
                {
                    new Car{ Name = "Ferrari California", Year = 2015, Color="czerwony", Type = CarType.Sport, Price=600000 },
                    new Car{ Name = "Lamborghini Gallardo", Year = 2006, Color="niebieski", Type = CarType.Sport, Price=700000 },
                    new Car{ Name = "Maserati granturismo s coupe", Year = 2019, Color="czarny", Type = CarType.Sport, Price=350000 }
                }),
                new CarGroup("Samochody osobowe", new List<Car>
                {
                    new Car{ Name = "Audi A4", Year = 2010, Color="czerwony", Type = CarType.Sedan, Price=40000 },
                    new Car{ Name = "Mercedes CLA", Year = 2012, Color="biały", Type = CarType.Sedan, Price=60000 }
                }),
                new CarGroup("SUV", new List<Car>
                {
                    new Car{ Name = "Ford Kuga", Year = 2018, Color="czerwony", Type = CarType.SUV, Price=80000 },
                    new Car{ Name = "BMW X5", Year = 2020, Color="czarny", Type = CarType.SUV, Price=120000 },
                })
            };

            CarListView.ItemsSource = carList;

            CarListView.IsPullToRefreshEnabled = true;
            CarListView.Refreshing += CarListView_Refreshing;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;
            //DisplayAlert("Wybrany samochód", car.Name, "Ok");

            Navigation.PushAsync(new CarDetailPage(car));
        }

        private void CarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = e.SelectedItem as Car;
            DisplayAlert("Item Selected", car.Name, "Ok");
        }

        private void CarListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car = e.Item as Car;
            DisplayAlert("Item tapped", car.Name, "Ok");
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as Xamarin.Forms.MenuItem;
            var car = menuItem.CommandParameter as Car;
            DisplayAlert("Details from context action", car.Name, "Ok");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var menuItem = sender as Xamarin.Forms.MenuItem;
            var car = menuItem.CommandParameter as Car;

            foreach (var carGroup in carList)
            {
                if (carGroup.Contains(car))
                {
                    carGroup.Remove(car);
                }
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var carGroup = button.CommandParameter as CarGroup;

            carGroup.ShowOrHideElements();
        }

        private void CarListView_Refreshing(object sender, EventArgs e)
        {
            var carList = new List<Car>
            {
                new Car()
                {
                    Name = "Jeep Grand Cherokee",
                    Year = 2010
                },
                new Car()
                {
                    Name = "Toyota Land Cruiser",
                    Year = 2009
                }
            };

            var carGroup = new CarGroup("Samochody terenowe", carList);
            this.carList.Add(carGroup);

            CarListView.EndRefresh();
        }
    }
}