using Xamarin.Forms;

namespace HelloWorld.Models
{
    public class Car
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }

        public CarType Type { get; set; }
    }

    public enum CarType
    {
        SUV,
        Sport,
        Sedan
    }
}
