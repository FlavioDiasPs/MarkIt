using MarkIt.App_Code;
using MarkIt.Model;
using MarkIt.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using ZXing.Net.Mobile.Forms;

namespace MarkIt.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public Product ProductModel { get; set; }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value as Product;
                EventPropertyChanged();
                if (value != null)
                {
                    ProductModel = value;
                    ProductDetail(value);
                }
            }
        }

        private void ProductDetail(Product value)
        {

            App.Current.MainPage.Navigation.PushAsync( new View.Product.ProductDetailView() { BindingContext = App.ProductVM });
        }

        private string searchByName;
        public string SearchByName
        {
            get { return searchByName; }
            set
            {
                if (value == searchByName) return;

                searchByName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchByName)));
            }
        }

        private string searchByBarCode;
        public string SearchByBarCode
        {
            get { return searchByBarCode; }
            set
            {
                if (value == searchByBarCode) return;

                searchByBarCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchByBarCode)));
                Search(value);
            }
        }

        public List<Product> stagedProductList;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public Command SearchCommand { get; }
        public Command ScanBarcodeCommand { get; }

        public ProductViewModel()
        {
            SearchCommand = new Command(() => { Search(SearchByName); });
            ScanBarcodeCommand = new Command(ScanBarcode);

            stagedProductList = new List<Product>();
            Task.Run(() => LoadPopularProducts());
        }
        
        public async Task LoadPopularProducts()
        {
            stagedProductList = await ProductRepository.GetProductsAsync();
            stagedProductList.ForEach(p => Products.Add(p));
        }
        public async Task LoadProducts(string keyword)
        {
            stagedProductList = await ProductRepository.GetProductByNameAsync(keyword);
            stagedProductList.ForEach(p => Products.Add(p));
        }

        private void ProductDetail(Product value)
        {
            App.ProductDetailsVM.SelectedProduct = value;
            App.Current.MainPage.Navigation.PushAsync(new View.Product.ProductDetailView() { BindingContext = App.ProductDetailsVM });
        }
        private void ScanBarcode(object obj)
        {
            var scan = new ZXingScannerPage();
            App.Current.MainPage.Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                    SearchByBarCode = result.Text;
                });
            };
        }
        public async void Search(string value)
        {
            stagedProductList = await ProductRepository.GetProductsByKeywordAsync(keyword);
            stagedProductList.ForEach(p => Products.Add(p));
        }

        //private void ApplyFilter()
        //{
        //    if (searchByName == null) searchByName = "";
        //    Products.Clear();
        //    Task.Run(() => LoadProducts(searchByName));
        //}

        //public async Task AddAsync(Product product)
        //{
        //    await new TaskFactory().StartNew(() =>
        //    {
        //        if ((product == null) || (string.IsNullOrWhiteSpace(product.Name)))
        //            App.Current.MainPage.DisplayAlert("Atenção", "O campo nome é obrigatório", "OK");
        //        else if (ProductRepository.PostProductAsync(product).GetAwaiter().GetResult())
        //            App.Current.MainPage.Navigation.PushAsync(new View.MainPage());
        //        else
        //            App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
        //    });                    
        //}

        //public async void Edit()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(
        //        new View.Product.NewProductView() { BindingContext = App.ProductVM });
        //}     

        public async void Search()
        {
            Products.Clear();
            if (!string.IsNullOrWhiteSpace(searchByName)) 
                await Task.Run(() => LoadProducts(searchByName));
        }
        private async void OnQuit()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }        

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
