using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            //var imageSource = new UriImageSource();
            //imageSource.Uri = new Uri("https://source.unsplash.com/1600x900/?dog");
            //imageSource.CachingEnabled = true;
            //imageSource.CacheValidity = TimeSpan.FromHours(3);

            //imageControl.Source = imageSource;
            //imageControl.Source = ImageSource.FromResource("HelloWorld.Images.car.jpg");
        }
    }
}