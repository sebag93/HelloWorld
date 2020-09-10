using HelloWorld.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    public partial class App : Application
    {
        public ObservableCollection<Models.MenuItem> MenuPages = new ObservableCollection<Models.MenuItem>();

        public App()
        {
            InitializeComponent();
            //SetMenuItem();
            //MainPage = new MasterDetailMainPage(MenuPages);
            //var masterPage = MainPage as MasterDetailMainPage;
            //masterPage.Detail = new NavigationPage((Page)Activator.CreateInstance(MenuPages[0].PageType));
            //MainPage = new NavigationPage(new CarouselNavigationPage());
            //MainPage = new CarouselViewPage();
            MainPage = new MainPage();
        }

        private void SetMenuItem()
        {
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Sport, "Samochody sportowe", typeof(SportsCarPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Sport, "SUV", typeof(SuvPage)));
            MenuPages.Add(new Models.MenuItem(Models.MenuItemType.Sport, "Samochody osobowe", typeof(StandardCarPage)));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
