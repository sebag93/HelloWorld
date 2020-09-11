using HelloWorld.Models;
using HelloWorld.ViewModels;
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
        public ListViewPage()
        {
            InitializeComponent();
            BindingContext = new CarsViewModel(Navigation);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;

            (BindingContext as CarsViewModel).NavigateToCarDetailPage(car);
        }

        private void CarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var car = e.SelectedItem as Car;
            (BindingContext as CarsViewModel).DisplayAlert(car.Name, "Item Selected");
        }

        private void CarListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car = e.Item as Car;
            (BindingContext as CarsViewModel).DisplayAlert(car.Name, "Item Tapped");
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as Xamarin.Forms.MenuItem;
            var car = menuItem.CommandParameter as Car;
            (BindingContext as CarsViewModel).DisplayAlert(car.Name, "Details from context action");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var menuItem = sender as Xamarin.Forms.MenuItem;
            var car = menuItem.CommandParameter as Car;

            (BindingContext as CarsViewModel).RemoveCarFromCollection(car);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var carGroup = button.CommandParameter as CarGroup;

            carGroup.ShowOrHideElements();
        }

        private void CarListView_Refreshing(object sender, EventArgs e)
        {
            (BindingContext as CarsViewModel).RefreshListView();
        }
    }
}