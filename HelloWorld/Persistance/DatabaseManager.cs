using HelloWorld.Models;
using SQLite;
using System;
using System.Collections.Generic;
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
        }

        private void CreateDatabase()
        {
            _connection.CreateTable<Car>();
        }
    }
}
