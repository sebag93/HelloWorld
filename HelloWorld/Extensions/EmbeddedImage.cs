using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Extensions
{
    [ContentProperty("ImageId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ImageId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(ImageId))
            {
                return null;
            }
            return ImageSource.FromResource(ImageId, typeof(EmbeddedImage).GetTypeInfo().Assembly);
        }
    }
}
