using HelloWorld.Models;
using HelloWorld.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace HelloWorld
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            var carList = new List<Car>()
            {
                 new Car{ Name = "Ferrari California", Year = 2015, Color="czerwony", Type = CarType.Sport, Price=600000 },
                 new Car{ Name = "Lamborghini Gallardo", Year = 2006, Color="niebieski", Type = CarType.Sport, Price=700000 },
                 new Car{ Name = "Maserati granturismo s coupe", Year = 2019, Color="czarny", Type = CarType.Sport, Price=350000 },
                 new Car{ Name = "Audi A4", Year = 2010, Color="czerwony", Type = CarType.Sedan, Price=40000 },
                 new Car{ Name = "Mercedes CLA", Year = 2012, Color="biały", Type = CarType.Sedan, Price=60000 },
                 new Car{ Name = "Ford Kuga", Year = 2018, Color="czerwony", Type = CarType.SUV, Price=80000 },
                 new Car{ Name = "BMW X5", Year = 2020, Color="czarny", Type = CarType.SUV, Price=120000 },
            };

            var sportsCarList = carList.Where(c => c.Type == CarType.Sport).ToList();
            var sportsCarPage = new NavigationPage(new SportsCarPage(sportsCarList))
            {
                Title = "Sportowe",
                IconImageSource = "car_icon.png"
            };

            var standardCarList = carList.Where(c => c.Type == CarType.Sedan).ToList();
            var standardCarPage = new NavigationPage(new StandardCarPage(standardCarList))
            {
                Title = "Osobowe",
                IconImageSource = "car_icon.png"
            };

            var suvCarList = carList.Where(c => c.Type == CarType.SUV).ToList();
            var suvCarPage = new NavigationPage(new SuvPage(suvCarList))
            {
                Title = "SUV",
                IconImageSource = "car_icon.png"
            };

            Children.Add(sportsCarPage);
            Children.Add(standardCarPage);
            Children.Add(suvCarPage);

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            InitializeComponent();
        }
    }
}
