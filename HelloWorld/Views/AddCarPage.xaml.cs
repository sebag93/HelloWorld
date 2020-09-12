using HelloWorld.Models;
using HelloWorld.ViewModels;
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
    public partial class AddCarPage : ContentPage
    {
        public AddCarPage(ObservableCollection<CarGroup> carGroupList)
        {
            InitializeComponent();
            BindingContext = new AddCarViewModel(Navigation, carGroupList);
        }
    }
}