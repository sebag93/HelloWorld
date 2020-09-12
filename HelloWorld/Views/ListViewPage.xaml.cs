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
        public CarsViewModel ViewModel { get; set; }
        public ListViewPage()
        {
            ViewModel = new CarsViewModel(Navigation);
            InitializeComponent();
            BindingContext = ViewModel;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;

            ViewModel.NavigateToCarDeatilPage(car);
        }

        private void CarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedCarCommand.Execute(e.SelectedItem);
        }

        private void CarListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.TappedCarCommand.Execute(e.Item);
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as Xamarin.Forms.MenuItem;
            var car = menuItem.CommandParameter as Car;

            //(BindingContext as CarsViewModel).DisplayAlert(car.Name, "Details from context action");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var carGroup = button.CommandParameter as CarGroup;

            carGroup.ShowOrHideElements();
        }
    }
}