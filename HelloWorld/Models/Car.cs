using SQLite;
using Xamarin.Forms;

namespace HelloWorld.Models
{
    [Table("Cars")]
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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
