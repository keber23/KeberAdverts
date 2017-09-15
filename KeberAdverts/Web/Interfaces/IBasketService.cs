using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Basket;

namespace Web.Interfaces
{
    public interface IBasketService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
        Task TransferBasketAsync(string anonymousId, string userName);
        Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity);
        Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task Checkout(int basketId);
    }
}
