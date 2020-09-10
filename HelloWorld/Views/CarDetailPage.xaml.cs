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
    public partial class CarDetailPage : ContentPage
    {
        public Car Car { get; set; }
        public CarDetailPage(Car car)
        {
            Car = car;

            BindingContext = Car;
            InitializeComponent();
        }
    }
}