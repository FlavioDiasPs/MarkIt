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
                //ApplyFilter();
            }
        }

        public List<Product> stagedProductList;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();


        public Command SearchCommand { get; }
        public Command ScanBarcodeCommand { get; }
        //public OnAddProductCMD OnAddProductCMD { get; }
        //public OnEditProductCMD OnEditProductCMD { get; }        
        //public ICommand OnNewProductCMD { get; private set; }
        //public ICommand OnQuitCMD { get; private set; }


        public ProductViewModel()
        {

            SearchCommand = new Command(Search);
            ScanBarcodeCommand = new Command(ScanBarcode);
            //OnAddProductCMD = new OnAddProductCMD(this);
            //OnEditProductCMD = new OnEditProductCMD(this);
            //OnQuitCMD = new Command(OnQuit);
            //OnNewProductCMD = new Command(OnNewProduct);

            stagedProductList = new List<Product>();
            Task.Run(() => LoadPopularProducts());
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
                    SearchByName = result.Text;
                });
            };
        }

        public async Task LoadPopularProducts()
        {
            stagedProductList = await ProductRepository.GetProductsAsync();
            stagedProductList.ForEach(p => Products.Add(p));
        }

        public async Task LoadProducts(string keyword)
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

        public void Search()
        {
            Products.Clear();
            if (!string.IsNullOrWhiteSpace(searchByName)) 
                Task.Run(() => LoadProducts(searchByName)).GetAwaiter().GetResult();
        }


        private async void OnQuit()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        //private void OnNewProduct()
        //{
        //    App.ProductVM.SelectedProduct = new Product();
        //    App.Current.MainPage.Navigation.PushAsync(new View.Product.NewProductView() { BindingContext = App.ProductVM });
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    //public class OnAddProductCMD : ICommand
    //{
    //    private ProductViewModel ProductVM;
    //    public OnAddProductCMD(ProductViewModel paramVM)
    //    {
    //        ProductVM = paramVM;
    //    }
    //    public event EventHandler CanExecuteChanged;
    //    public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    //    public bool CanExecute(object parameter) => true;
    //    public void Execute(object parameter)
    //    {
    //        //ProductVM.AddAsync(parameter as Product).GetAwaiter().GetResult();
    //    }
    //}

    //public class OnEditProductCMD : ICommand
    //{
    //    private ProductViewModel ProductVM;
    //    public OnEditProductCMD(ProductViewModel paramVM)
    //    {
    //        ProductVM = paramVM;
    //    }
    //    public event EventHandler CanExecuteChanged;
    //    public void EditarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    //    public bool CanExecute(object parameter) => (parameter != null);
    //    public void Execute(object parameter)
    //    {
    //        App.ProductVM.SelectedProduct = parameter as Product;
    //        ProductVM.Edit();
    //    }
    //} 


}
