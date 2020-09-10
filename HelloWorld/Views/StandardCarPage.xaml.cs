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
    public partial class StandardCarPage : ContentPage
    {
        public ObservableCollection<Car> Cars { get; set; }
        public StandardCarPage(List<Car> cars)
        {
            InitializeComponent();

            Cars = new ObservableCollection<Car>(cars);
            CarListView.ItemsSource = Cars;
            
        }

        public StandardCarPage()
        {
            InitializeComponent();

            Cars = new ObservableCollection<Car>()
            {
                new Car{ Name = "Audi A4", Year = 2010, Color="czerwony", Type = CarType.Sedan, Price=40000 },
                new Car{ Name = "Mercedes CLA", Year = 2012, Color="biały", Type = CarType.Sedan, Price=60000 }
            };

            CarListView.ItemsSource = Cars;
        }

        private void CarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = e.SelectedItem as Car;
            Navigation.PushAsync(new CarDetailPage(car));
        }
    }
}