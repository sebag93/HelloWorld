using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMainPage : MasterDetailPage
    {
        public ObservableCollection<Models.MenuItem> MenuPages { get; set; }
        public MasterDetailMainPage(ObservableCollection<Models.MenuItem> menuPages)
        {
            InitializeComponent();
            MenuPages = menuPages;
            MasterBehavior = MasterBehavior.Split;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(menuPages[0].PageType));
            this.IsPresented = false;

            menuPagesListView.ItemsSource = MenuPages;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = e.SelectedItem as Models.MenuItem;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(menuItem.PageType));
            this.IsPresented = false;
        }
    }
}