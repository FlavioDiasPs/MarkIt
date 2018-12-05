using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MarkIt.Model.Repositories
{
    public static class PriceRepository
    {
        public static async Task<IEnumerable<Price>> GetProductDetailsAsync(int id)
        {
            IEnumerable<Price> prices = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://markitapi.azurewebsites.net/api/price/productid/{id}");

                if (response.IsSuccessStatusCode)
                    prices = JsonConvert.DeserializeObject<IEnumerable<Price>>(response.Content.ReadAsStringAsync().Result);
            }

            return prices;
        }
    }
}
