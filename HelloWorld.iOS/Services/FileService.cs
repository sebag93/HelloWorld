using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using HelloWorld.iOS.Services;
using HelloWorld.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace HelloWorld.iOS.Services
{
    class FileService : IFileService
    {
        public async Task WriteTextAsync(string name, string content)
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filePath = System.IO.Path.Combine(basePath, name);
            using (var writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}