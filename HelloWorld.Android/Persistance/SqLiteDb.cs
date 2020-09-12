using HelloWorld.Droid.Persistance;
using HelloWorld.Persistance;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDb))]
namespace HelloWorld.Droid.Persistance
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