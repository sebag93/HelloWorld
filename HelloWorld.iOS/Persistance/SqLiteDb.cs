using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using HelloWorld.iOS.Persistance;
using HelloWorld.Persistance;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDb))]
namespace HelloWorld.iOS.Persistance
{
    public class SqLiteDb : ISqLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var path = GetDataBasePath();

            return new SQLiteConnection(path);
        }

        private string GetDataBasePath()
        {
            var databaseName = "HelloWorld.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentPath, databaseName);
        }
    }
}