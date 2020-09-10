using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HelloWorld.Models
{
    public class CarGroup : ObservableCollection<Car>
    {
        public string Title { get; set; }
        public List<Car> CarList { get; set; }
        private bool _isShow;

        public CarGroup(string title, List<Car> carList)
        {
            Title = title;
            CarList = carList;

            _isShow = true;

            foreach (var car in carList)
            {
                base.Add(car);
            }
        }

        public void ShowOrHideElements()
        {
            if (_isShow)
            {
                base.Clear();
            }
            else
            {
                foreach (var car in CarList)
                {
                    base.Add(car);
                }
            }

            _isShow = !_isShow;
        }
    }
}
