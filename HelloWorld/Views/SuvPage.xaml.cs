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
    public partial class SuvPage : ContentPage
    {
        public ObservableCollection<Car> Cars { get; set; }
        public SuvPage(List<Car> cars)
        {
            InitializeComponent();

            Cars = new ObservableCollection<Car>(cars);
            CarListView.ItemsSource = Cars;
            
        }

        public SuvPage()
        {
            InitializeComponent();

            Cars = new ObservableCollection<Car>()
            {
                new Car{ Name = "Ford Kuga", Year = 2018, Color="czerwony", Type = CarType.SUV, Price=80000 },
                    new Car{ Name = "BMW X5", Year = 2020, Color="czarny", Type = CarType.SUV, Price=120000 },
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