using MarkIt.App_Code;
using System;
using Xamarin.Forms;

namespace MarkIt.View
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            menuPage.ListView.ItemSelected += ListView_ItemSelected;
            Detail = new NavigationPage(new Product.ProductView { BindingContext = App.ProductVM });
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is OpcoesMenu item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                menuPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
