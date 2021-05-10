using System.Text;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonSerializer.Deserialize<ShoppingCart>(basket);



           // return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }
        
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket)); //NewtonSoft
            await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));            
            return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public int MetodoComNomeGrande(string a, string b, string c){

            var j = 15;

            StringBuilder stringBuilder = new();
            


            return j;
        }
    }
}
