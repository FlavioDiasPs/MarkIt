using MarkIt.Model;
using MarkIt.Model.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MarkIt.ViewModel
{
    public class ProductDetailsViewModel : INotifyPropertyChanged
    {
        public IEnumerable<Price> Prices { get; set; }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value as Product;

                if (value != null)
                    Task.Run(async () => { await LoadSelectedProduct(); }).GetAwaiter().GetResult();

            }
        }

        public ProductDetailsViewModel()
        {

        }

        public async Task LoadSelectedProduct()
        {
            Prices = await PriceRepository.GetProductDetailsAsync(SelectedProduct.Id);
            SelectedProduct.Prices.AddRange(Prices);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
