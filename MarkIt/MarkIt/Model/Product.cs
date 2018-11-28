using MarkIt.Data.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MarkIt.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }       
        public string Name { get; set; }
        public double Price { get; set; }
        public Market Market { get; set; }        
    }

    public class ProductRepository
    {
        private ProductRepository() { }

        private static SQLiteConnection database;
        private static readonly ProductRepository instance = new ProductRepository();
        public static ProductRepository Instance
        {
            get
            {
                if (database == null)
                {
                    database = DependencyService.Get<IDependencyServiceSQLite>().GetConection();
                    database.CreateTable<Product>();
                }
                return instance;
            }
        }

        static object locker = new object();
        public static int SalvarAluno(Product product)
        {
            lock (locker)
            {
                if (product.Id != 0)
                {
                    database.Update(product);
                    return product.Id;
                }
                else return database.Insert(product);
            }
        }

        public static IEnumerable<Product> GetProducts()
        {
            lock (locker)            
                return(from c in database.Table<Product>() select c).ToList();            
        }

        public static Product GetProduct(int Id)
        {
            lock (locker)
                return database.Table<Product>().Where(c => c.Id == Id).FirstOrDefault();

        }

        public static int DeleteProduct(int Id)
        {
            lock (locker)            
                return database.Delete<Product>(Id);            
        }
    }
}
