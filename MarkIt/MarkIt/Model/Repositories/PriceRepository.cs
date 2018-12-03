using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MarkIt.Model.Repositories
{
    public static class PriceRepository
    {
        private static List<Price> prices;
        public static async Task<List<Price>> GetProductsAsync()
        {
            if (prices != null) return prices;

            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync("http://fiapmarkeitapiteste.azurewebsites.net/api/price");

            var priceSerializer = new DataContractJsonSerializer(typeof(List<Product>));
            prices = (List<Price>)priceSerializer.ReadObject(stream);
            return prices;
        }
        public static async Task<List<Price>> GetPricesByProductAsync(string id)
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync($"http://fiapmarkeitapiteste.azurewebsites.net/api/price/getbyproduct/{id}");

            var productSerializer = new DataContractJsonSerializer(typeof(List<Price>));
            prices = (List<Price>)productSerializer.ReadObject(stream);
            return prices;
        }
    }
}
