using eShop.Data.Base;
using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class ShopsService:EntityBaseRepository<Shop>, IShopsService
    {
        public ShopsService(AppDbContext context) : base(context)
        {
                
        }
    }
}
