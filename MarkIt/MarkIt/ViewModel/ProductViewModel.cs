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
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                EventPropertyChanged();
                if (value != null) ProductDetail(value);                
            }
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
                SearchCode();
            }
        }

        public List<Product> stagedProductList;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public Command SearchCommand { get; }
        public Command ScanBarcodeCommand { get; }

        public ProductViewModel()
        {
            SearchCommand = new Command(Search);
            ScanBarcodeCommand = new Command(ScanBarcode);

            stagedProductList = new List<Product>();
            Task.Run(async () => await LoadPopularProducts()).GetAwaiter().GetResult();
        }
        
        public async Task LoadPopularProducts()
        {
            stagedProductList = await ProductRepository.GetProductsAsync();
            stagedProductList.ForEach(p => Products.Add(p));
        }
        public async Task GetProductByNameAsync(string name)
        {
            stagedProductList = await ProductRepository.GetProductByNameAsync(name);
            stagedProductList.ForEach(p => Products.Add(p));
        }
        public async Task GetProductByBarCodeAsync(string BarCode)
        {
            stagedProductList = await ProductRepository.GetProductByBarCodeAsync(BarCode);
            stagedProductList.ForEach(p => Products.Add(p));
        }

        private void ProductDetail(Product value)
        {
            App.ProductDetailsVM.SelectedProduct = value;
            App.Current.MainPage.Navigation.PushAsync(new View.Product.ProductDetailView() { BindingContext = App.ProductDetailsVM });
        }
        private void ScanBarcode()
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

        public async void SearchCode()
        {
            Products.Clear();
            if (!string.IsNullOrWhiteSpace(searchByBarCode)) await GetProductByBarCodeAsync(searchByBarCode);
        }

        public async void Search()
        {
            Products.Clear();
            if (!string.IsNullOrWhiteSpace(searchByName)) await GetProductByNameAsync(searchByName);
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
