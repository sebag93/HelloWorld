using HelloWorld.Models;
using HelloWorld.Persistance;
using HelloWorld.Services;
using HelloWorld.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class CarsViewModel : BaseViewModel
    {
        public ObservableCollection<CarGroup> CarList { get; private set; }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
        }

        public ICommand RefreshCarListCommand { get; private set; }
        public ICommand RemoveCarCommand { get; private set; }
        public ICommand TappedCarCommand { get; private set; }
        public ICommand SelectedCarCommand { get; private set; }
        public ICommand AddCarCommand { get; private set; }


        private INavigation _navigation;

        public CarsViewModel(INavigation navigation)
        {
            _navigation = navigation;

            RefreshCarListCommand = new Command(() => RefresLissView());
            RemoveCarCommand = new Command<Car>(car => RemoveCarFromCollection(car));
            TappedCarCommand = new Command<Car>(car => TappedItem(car));
            SelectedCarCommand = new Command<Car>(car => SelectedItem(car));
            AddCarCommand = new Command(() => AddCar());

            var carsFromDatabae = DatabaseManager.Instance.GetALL<Car>();

            CarList = new ObservableCollection<CarGroup>
            {
                new CarGroup("Samochody sportowe", carsFromDatabae.Where(c => c.Type == CarType.Sport).ToList()),
                new CarGroup("Samochody osobowe", carsFromDatabae.Where(c => c.Type == CarType.Sedan).ToList()),
                new CarGroup("SUV", carsFromDatabae.Where(c => c.Type == CarType.SUV).ToList())
            };
        }

        private void AddCar()
        {
            _navigation.PushModalAsync(new AddCarPage(CarList));
        }

        public void NavigateToCarDeatilPage(Car car)
        {
            _navigation.PushAsync(new CarDetailPage(car));
        }

        private void TappedItem(Car car)
        {
            App.Current.MainPage.DisplayAlert("Tapped item", car.Name, "Ok");
        }

        private async Task SelectedItem(Car car)
        {
            //App.Current.MainPage.DisplayAlert("Selected item", car.Name, "Ok");
            //var fileService = DependencyService.Get<IFileService>();
            //fileService.WriteTextAsync(car.Name, $"To jest samochód: {car.Name} w kolorze: {car.Color}");

            using (var stream = await FileSystem.OpenAppPackageFileAsync(car.Name))
            {
                using (var writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync($"To jest samochód: {car.Name} w kolorze: {car.Color}");
                }
            }
        }

        private void RemoveCarFromCollection(Car car)
        {
            foreach (var carGroup in CarList)
            {
                if (carGroup.Contains(car))
                {
                    carGroup.Remove(car);
                }
            }

            DatabaseManager.Instance.RemoveFromDatabase<Car>(car.Id);
        }

        private void RefresLissView()
        {
            IsRefreshing = true;
            var carList = new List<Car>
            {
                new Car()
                {
                    Name = "Jeep Grand Cherokee",
                    Year = 2010
                },
                new Car()
                {
                    Name = "Toyota Land Cruiser",
                    Year = 2009
                }
            };

            var carGroup = new CarGroup("Samochody terenowe", carList);
            CarList.Add(carGroup);
            IsRefreshing = false;
        }
    }
}
