using System;
using Basket.API.Entities;
using Basket.API.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories
{
   
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart?> GetBasket(string userName)
        {
            var basket = await _redisCache.GetRecordAsync<ShoppingCart>(userName);
            return basket;
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetRecordAsync<ShoppingCart>(basket.UserName, basket);
            return await GetBasket(basket.UserName);
        }
    }
}

