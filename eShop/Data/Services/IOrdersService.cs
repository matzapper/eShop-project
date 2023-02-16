using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public interface IOrdersService
    {
        //Method 1: Add orders to the database
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        //Method 2: Get all orders from the database
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
