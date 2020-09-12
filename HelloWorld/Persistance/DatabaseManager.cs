using HelloWorld.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace HelloWorld.Persistance
{
    public sealed class DatabaseManager
    {
        private static DatabaseManager instance = null;
        private static readonly object locker = new object();
        private readonly SQLiteConnection _connection; 
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new DatabaseManager();
                        }
                    }
                }
                return instance;
            }
        }
        private DatabaseManager()
        {
            _connection = DependencyService.Get<ISqLiteDb>().GetConnection();
            CreateDatabase();
            var car = _connection.GetAllWithChildren<Car>().FirstOrDefault();
            if (car == null)
            {
                SeedDatabase();
            }
        }

        private void SeedDatabase()
        {
            var cars = new List<Car>
            {
                new Car{ Name = "Ferrari California", Year = 2015, Color="czerwony", Type = CarType.Sport, Price=600000 },
                new Car{ Name = "Lamborghini Gallardo", Year = 2006, Color="niebieski", Type = CarType.Sport, Price=700000 },
                new Car{ Name = "Maserati granturismo s coupe", Year = 2019, Color="czarny", Type = CarType.Sport, Price=350000 },
                new Car{ Name = "Audi A4", Year = 2010, Color="czerwony", Type = CarType.Sedan, Price=40000 },
                new Car{ Name = "Mercedes CLA", Year = 2012, Color="biały", Type = CarType.Sedan, Price=60000 },
                new Car{ Name = "Ford Kuga", Year = 2018, Color="czerwony", Type = CarType.SUV, Price=80000 },
                new Car{ Name = "BMW X5", Year = 2020, Color="czarny", Type = CarType.SUV, Price=120000 },
            };
            _connection.InsertAll(cars);
        }

        public List<T> GetALL<T>() where T : class , new()
        {
            return _connection.GetAllWithChildren<T>().ToList();
        }

        private void CreateDatabase()
        {
            _connection.CreateTable<Car>();
        }

        public void Add<T>(T objectToAdd)
        {
            _connection.Insert(objectToAdd);
        }
    }
}
