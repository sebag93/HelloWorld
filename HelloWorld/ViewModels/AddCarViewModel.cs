using HelloWorld.Models;
using HelloWorld.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        public List<string> CarTypes { get; set; } = new List<string>();
        public ObservableCollection<CarGroup> CarGroupList { get; set; } = new ObservableCollection<CarGroup>();
        public Dictionary<string, CarType> CarTypeDictionary { get; set; } = new Dictionary<string, CarType>();
        public INavigation Navigation { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetValue<string>(ref _name, value); }
        }

        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set { SetValue<string>(ref _selectedType, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetValue<string>(ref _color, value); }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set { SetValue<int>(ref _year, value); }
        }


        public ICommand SaveCarCommand { get; set; }

        public AddCarViewModel(INavigation navigation, ObservableCollection<CarGroup> carGroup)
        {
            CarGroupList = carGroup;
            Navigation = navigation;
            FilCarTypePicker();
            SaveCarCommand = new Command(async () => await AddCarToDatabaseAsync());
        }

        private void FilCarTypePicker()
        {
            foreach (CarType carType in (CarType[])Enum.GetValues(typeof(CarType)))
            {
                CarTypes.Add(carType.ToString());
                CarTypeDictionary.Add(carType.ToString(), carType);
            }
        }

        private async Task AddCarToDatabaseAsync()
        {
            var car = new Car();
            car.Name = Name;
            car.Color = Color;
            car.Year = Year;
            car.Type = CarTypeDictionary[SelectedType];

            DatabaseManager.Instance.Add<Car>(car);

            foreach (var carGroup in CarGroupList)
            {
                if (carGroup[0].Type == car.Type)
                {
                    carGroup.Add(car);
                }
            }

            await Navigation.PopModalAsync();
        }
    }
}
