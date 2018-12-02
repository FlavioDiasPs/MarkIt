using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MarkIt.Model
{
    public class Product
    {
        public int Id { get; set; }
        //só pra funcionar no exemplo...
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public List<Price> Prices { get; set; }
    }    public static class ProductRepository
    {
        private static List<Product> products;
        public static async Task<List<Product>> GetProductsAsync()
        {
            if (products != null) return products;

            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync("http://apiaplicativofiap.azurewebsites.net/api/professors");

            var productSerializer = new
           DataContractJsonSerializer(typeof(List<Product>));
            products =
           (List<Product>)productSerializer.ReadObject(stream);
            return products;
        }

        public static async Task<bool> PostProductAsync(Product product)
        {
            if (product == null) return false;

            var httpRequest = new HttpClient();
            httpRequest.BaseAddress = new Uri("http://apiaplicativofiap.azurewebsites.net/ ");

            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string profJson = Newtonsoft.Json.JsonConvert.SerializeObject(product);
            var content = new StringContent(profJson, System.Text.Encoding.UTF8, "application/json");
            var response = await httpRequest.PostAsync("api/professors", content);

            if (response.IsSuccessStatusCode) return true;
            return false;
        }






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
    //public class Product
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }       
    //    public string Name { get; set; }
    //    public double Price { get; set; }
    //    public Market Market { get; set; }        
    //}

    //public class ProductRepository
    //{
    //    private ProductRepository() { }

    //    private static SQLiteConnection database;
    //    private static readonly ProductRepository instance = new ProductRepository();
    //    public static ProductRepository Instance
    //    {
    //        get
    //        {
    //            if (database == null)
    //            {
    //                database = DependencyService.Get<IDependencyServiceSQLite>().GetConection();
    //                database.CreateTable<Product>();
    //            }
    //            return instance;
    //        }
    //    }

    //    static object locker = new object();
    //    public static int SalvarAluno(Product product)
    //    {
    //        lock (locker)
    //        {
    //            if (product.Id != 0)
    //            {
    //                database.Update(product);
    //                return product.Id;
    //            }
    //            else return database.Insert(product);
    //        }
    //    }

    //    public static IEnumerable<Product> GetProducts()
    //    {
    //        lock (locker)            
    //            return(from c in database.Table<Product>() select c).ToList();            
    //    }

    //    public static Product GetProduct(int Id)
    //    {
    //        lock (locker)
    //            return database.Table<Product>().Where(c => c.Id == Id).FirstOrDefault();

    //    }

    //    public static int DeleteProduct(int Id)
    //    {
    //        lock (locker)            
    //            return database.Delete<Product>(Id);            
    //    }
    //}
}
