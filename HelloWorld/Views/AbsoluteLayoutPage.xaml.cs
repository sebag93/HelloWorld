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
    public partial class AbsoluteLayoutPage : ContentPage
    {
        public AbsoluteLayoutPage()
        {
            InitializeComponent();

            Createlayout();
        }

        private void Createlayout()
        {
            var absLayout = new AbsoluteLayout
            {
                Margin = new Thickness(20)
            };

            var placeholder = new BoxView
            {
                CornerRadius = 20,
                BackgroundColor = Color.Gray,
            };
            absLayout.Children.Add(placeholder, new Rectangle(0, 0, 1, 0.35), AbsoluteLayoutFlags.All);

            var bankLabel = CreateLabel("Bank Label", 18);
            absLayout.Children.Add(bankLabel, new Rectangle(1, 0.05, 150, 20), AbsoluteLayoutFlags.PositionProportional);

            var cardTypeLabel = CreateLabel("Credit Card", 18);
            absLayout.Children.Add(cardTypeLabel, new Rectangle(0.1, 0.03, 120, 20), AbsoluteLayoutFlags.PositionProportional);

            var number1 = CreateLabel("1234", 22);
            absLayout.Children.Add(number1, new Rectangle(0.1, 0.18, 50, 30), AbsoluteLayoutFlags.PositionProportional);

            var number2 = CreateLabel("1234", 22);
            absLayout.Children.Add(number2, new Rectangle(0.32, 0.18, 50, 30), AbsoluteLayoutFlags.PositionProportional);

            var number3 = CreateLabel("1234", 22);
            absLayout.Children.Add(number3, new Rectangle(0.54, 0.18, 50, 30), AbsoluteLayoutFlags.PositionProportional);

            var number4 = CreateLabel("1234", 22);
            absLayout.Children.Add(number4, new Rectangle(0.76, 0.18, 50, 30), AbsoluteLayoutFlags.PositionProportional);

            var validLabel = CreateLabel("VALID THRU", 8);
            absLayout.Children.Add(validLabel, new Rectangle(0.67, 0.255, 40, 30), AbsoluteLayoutFlags.PositionProportional);

            var dateLabel = CreateLabel("10/20", 18);
            absLayout.Children.Add(dateLabel, new Rectangle(0.86, 0.25, 80, 30), AbsoluteLayoutFlags.PositionProportional);

            var nameLabel = CreateLabel("Xamarin Forms", 18);
            nameLabel.FontAttributes = FontAttributes.Bold;
            absLayout.Children.Add(nameLabel, new Rectangle(0.18, 0.29, 200, 30), AbsoluteLayoutFlags.PositionProportional);

            this.Content = absLayout;
        }

        private Label CreateLabel(string text, int fontSize)
            => new Label
            {
                Text = text,
                FontSize = fontSize,
                TextColor = Color.White
            };
    }
}