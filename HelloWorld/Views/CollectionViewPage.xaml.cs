using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {
        public ObservableCollection<CarGroup> carList { get; set; }

        public CollectionViewPage()
        {
            InitializeComponent();

            carList = new ObservableCollection<CarGroup>
            {
                new CarGroup("Samochody sportowe", new List<Car>
                {
                    new Car{ Name = "Ferrari California", Year = 2015},
                    new Car{ Name = "Lamborghini Gallardo", Year = 2006},
                    new Car{ Name = "Maserati granturismo s coupe", Year = 2019}
                }),
                new CarGroup("Samochody osobowe", new List<Car>
                {
                    new Car{ Name = "Audi A4", Year = 2010},
                    new Car{ Name = "Mercedes CLA", Year = 2012}
                }),
                new CarGroup("SUV", new List<Car>
                {
                    new Car{ Name = "Ford Kuga", Year = 2018},
                    new Car{ Name = "BMW X5", Year = 2020},
                })
            };

            CarListView.ItemsSource = carList;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;
            DisplayAlert("Wybrany samochód", car.Name, "Ok");
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var car = button.CommandParameter as Car;
            DisplayAlert("Details from context action", car.Name, "Ok");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var car = button.CommandParameter as Car;

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

    }
}