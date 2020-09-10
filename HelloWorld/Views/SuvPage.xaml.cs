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

        private void CarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = e.SelectedItem as Car;
            Navigation.PushAsync(new CarDetailPage(car));
        }
    }
}