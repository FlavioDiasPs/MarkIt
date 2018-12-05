using MarkIt.Data.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MarkIt.Model
{
    public class Market
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Zipcode { get; set; }
    }

    public class MarketRepository
    {
        private MarketRepository() { }

        private static SQLiteConnection database;
        private static readonly MarketRepository instance = new MarketRepository();
        public static MarketRepository Instance
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
        public static int SalvarAluno(Market market)
        {
            lock (locker)
            {
                if (market.Id != 0)
                {
                    database.Update(market);
                    return market.Id;
                }
                else return database.Insert(market);
            }
        }

        public static IEnumerable<Market> GetMarkets()
        {
            lock (locker)
                return (from c in database.Table<Market>() select c).ToList();
        }

        public static Market GetMarket(int Id)
        {
            lock (locker)
                return database.Table<Market>().Where(c => c.Id == Id).FirstOrDefault();

        }

        public static int DeleteMarket(int Id)
        {
            lock (locker)
                return database.Delete<Market>(Id);
        }
    }
}
