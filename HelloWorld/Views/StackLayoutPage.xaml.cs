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
    public partial class StackLayoutPage : ContentPage
    {
        public StackLayoutPage()
        {
            InitializeComponent();
            CreateLayout();
        }

        private void CreateLayout()
        {
            var content = new StackLayout();
            content.Margin = new Thickness(30);

            var titleLabel = new Label
            {
                Text = "Hello World",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Margin = new Thickness(0, 30, 0, 100),
                FontAttributes = FontAttributes.Bold
            };
            content.Children.Add(titleLabel);

            var loginLabel = new Label
            {
                Text = "Login",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold
            };
            content.Children.Add(loginLabel);

            var loginEntry = new Entry
            {
                Placeholder = "Login",
                Keyboard = Keyboard.Text,
                HorizontalTextAlignment = TextAlignment.Center
            };
            content.Children.Add(loginEntry);

            var passwordLabel = new Label
            {
                Text = "Hasło",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold
            };
            content.Children.Add(passwordLabel);

            var passwordEntry = new Entry
            {
                IsPassword = true,
                Placeholder = "Hasło",
                Keyboard = Keyboard.Text,
                HorizontalTextAlignment = TextAlignment.Center
            };
            content.Children.Add(passwordEntry);

            var buttonStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 20
            };
            content.Children.Add(buttonStackLayout);

            var loginButton = new Button
            {
                Text = "Zaloguj",
                BackgroundColor = Color.LightBlue,
                CornerRadius = 10,
                WidthRequest = 150
            };
            loginButton.Clicked += Button_Clicked;
            buttonStackLayout.Children.Add(loginButton);

            var accountButton = new Button
            {
                Text = "Utwórz konto",
                BackgroundColor = Color.LightGray,
                CornerRadius = 10,
                WidthRequest = 150
            };
            accountButton.Clicked += Button_Clicked;
            buttonStackLayout.Children.Add(accountButton);

            this.Content = content;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}