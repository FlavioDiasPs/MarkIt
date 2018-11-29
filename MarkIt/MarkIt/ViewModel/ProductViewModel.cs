using MarkIt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarkIt.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public Product ProductModel { get; set; }

        private Product selecionado;
        public Product Selecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value as Product;
                EventPropertyChanged();
            }
        }

        private string pesquisaPorNome;
        public string PesquisaPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                if (value == pesquisaPorNome) return;

                pesquisaPorNome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorNome)));
                AplicarFiltro();
            }
        }

        public List<Product> CopiaListaProducts;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        // UI Events
        public OnAdicionarProductCMD OnAdicionarProductCMD { get; }
        public OnEditarProductCMD OnEditarProductCMD { get; }
        //public OnDeleteProductCMD OnDeleteProductCMD { get; }
        public ICommand OnSairCMD { get; private set; }
        public ICommand OnNovoCMD { get; private set; }



        public ProductViewModel()
        {
            //ProductRepository repository = new ProductRepository();

            OnAdicionarProductCMD = new OnAdicionarProductCMD(this);
            OnEditarProductCMD = new OnEditarProductCMD(this);
            //OnDeleteProductCMD = new OnDeleteProductCMD(this);
            OnSairCMD = new Command(OnSair);
            OnNovoCMD = new Command(OnNovo);

            CopiaListaProducts = new List<Product>();
            Carregar();
        }


        public void Carregar()
        {
            CopiaListaProducts = ProductRepository.GetProductsAsync().Result;
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (pesquisaPorNome == null)
                pesquisaPorNome = "";

            var resultado = CopiaListaProducts.Where(n => n.Nome.ToLowerInvariant()
                                .Contains(PesquisaPorNome.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = Products.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                Products.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > Products.Count || !Products[index].Equals(item))
                    Products.Insert(index, item);
            }
        }



        public void Adicionar(Product paramProduct)
        {
            if ((paramProduct == null) || (string.IsNullOrWhiteSpace(paramProduct.Nome)))
                App.Current.MainPage.DisplayAlert("Atenção", "O campo nome é obrigatório", "OK");
            else if (ProductRepository.PostProductAsync(paramProduct).Result)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
        }

        public async void Editar()
        {
            await App.Current.MainPage.Navigation.PushAsync(
                new View.Product.NewProductView() { BindingContext = App.ProductVM });
        }

        //public async void Remover()
        //{
        //    if (await App.Current.MainPage.DisplayAlert("Atenção?",
        //        string.Format("Tem certeza que deseja remover o {0}?", Selecionado.Nome), "Sim", "Não"))
        //    {
        //        var teste = Selecionado.Id.ToString();

        //        if (ProductRepository.DeleteProductSqlAzureAsync(teste).Result)
        //        {
        //            CopiaListaProductes.Remove(Selecionado);
        //            Carregar();
        //        }
        //        else
        //            await App.Current.MainPage.DisplayAlert(
        //                    "Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
        //    }
        //}

        private async void OnSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnNovo()
        {
            App.ProductVM.Selecionado = new Model.Product();
            App.Current.MainPage.Navigation.PushAsync(
                new View.Product.NewProductView() { BindingContext = App.ProductVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class OnAdicionarProductCMD : ICommand
    {
        private ProductViewModel ProductVM;
        public OnAdicionarProductCMD(ProductViewModel paramVM)
        {
            ProductVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            ProductVM.Adicionar(parameter as Product);
        }
    }

    public class OnEditarProductCMD : ICommand
    {
        private ProductViewModel ProductVM;
        public OnEditarProductCMD(ProductViewModel paramVM)
        {
            ProductVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void EditarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            App.ProductVM.Selecionado = parameter as Product;
            ProductVM.Editar();
        }
    }

    //public class OnDeleteProductCMD : ICommand
    //{
    //    private ProductViewModel ProductVM;
    //    public OnDeleteProductCMD(ProductViewModel paramVM)
    //    {
    //        ProductVM = paramVM;
    //    }
    //    public event EventHandler CanExecuteChanged;
    //    public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    //    public bool CanExecute(object parameter) => (parameter != null);
    //    public void Execute(object parameter)
    //    {
    //        App.ProductVM.Selecionado = parameter as Product;
    //        ProductVM.Remover();
    //    }
    //}
}
