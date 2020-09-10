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
    public partial class CarouselNavigationPage : CarouselPage
    {
        public CarouselNavigationPage()
        {
            InitializeComponent();

            var sportCarPage = new SportsCarPage();
            var sedanCarPage = new StandardCarPage();
            var suvCarPage = new SuvPage();

            Children.Add(sportCarPage);
            Children.Add(sedanCarPage);
            Children.Add(suvCarPage);
        }
    }
}