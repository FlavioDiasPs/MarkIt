using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarkIt.Model.Repositories
{
    public static class ProductRepository
    {                
        public static async Task<List<Product>> GetProductsAsync()
        {
            List<Product> products = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://markitapi.azurewebsites.net/api/product/");

                if (response.IsSuccessStatusCode)
                    products = JsonConvert.DeserializeObject<List<Product>>(response.Content.ReadAsStringAsync().Result);
            }

            return products;
        }
        public static async Task<List<Product>> GetProductByBarCodeAsync(string barcode)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://markitapi.azurewebsites.net/api/product/barcode/{barcode}");

            List<Product> products = null;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            return products;
        }
        public static async Task<List<Product>> GetProductByNameAsync(string name)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://markitapi.azurewebsites.net/api/product/name/{name}");

            List<Product> products = null;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            return products;
        }
    }
}
