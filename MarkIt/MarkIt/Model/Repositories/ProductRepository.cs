using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MarkIt.Model.Repositories
{
    public static class ProductRepository
    {
        private static List<Product> products;
        public static async Task<List<Product>> GetProductsAsync()
        {
            if (products != null) return products;

            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync("http://fiapmarkeitapiteste.azurewebsites.net/api/product");

            var productSerializer = new DataContractJsonSerializer(typeof(List<Product>));
            products = (List<Product>)productSerializer.ReadObject(stream);
            return products;
        }

        public static async Task<List<Product>> GetProductsByKeywordAsync(string keyword)
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync($"http://fiapmarkeitapiteste.azurewebsites.net/api/product/GetByKeyword/{keyword}");

            var productSerializer = new DataContractJsonSerializer(typeof(List<Product>));
            products = (List<Product>)productSerializer.ReadObject(stream);
            return products;
        }
        public static async Task<List<Product>> GetProductsByIdAsync(string id)
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync($"http://fiapmarkeitapiteste.azurewebsites.net/api/product/{id}");

            var productSerializer = new DataContractJsonSerializer(typeof(List<Product>));
            products = (List<Product>)productSerializer.ReadObject(stream);
            return products;
        }
        //public static async Task<bool> PostProductAsync(Product product)
        //{
        //    if (product == null) return false;

        //    var httpRequest = new HttpClient();
        //    httpRequest.BaseAddress = new Uri("http://apiaplicativofiap.azurewebsites.net/ ");

        //    httpRequest.DefaultRequestHeaders.Accept.Clear();
        //    httpRequest.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    string profJson = Newtonsoft.Json.JsonConvert.SerializeObject(product);
        //    var content = new StringContent(profJson, System.Text.Encoding.UTF8, "application/json");
        //    var response = await httpRequest.PostAsync("api/professors", content);

        //    if (response.IsSuccessStatusCode) return true;
        //    return false;
        //}

        // public static async Task<bool>
        //DeleteProfessorSqlAzureAsync(string profId)
        // {
        //     if (string.IsNullOrWhiteSpace(profId)) return false;

        //     var httpRequest = new HttpClient();
        //     httpRequest.BaseAddress = new Uri("http://apiaplicativofiap.azurewebsites.net/");

        //     httpRequest.DefaultRequestHeaders.Accept.Clear();

        //     httpRequest.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //     var response = httpRequest.DeleteAsync(string.Format("api/professors/{0}", profId)).Result;

        //     if (response.IsSuccessStatusCode) return true;
        //     return false;
        // }
    }
}
