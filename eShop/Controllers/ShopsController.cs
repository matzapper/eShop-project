using eShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class ShopsController : Controller
    {
        //Declaring the appdbcontext file
        private readonly AppDbContext _context;

        public ShopsController(AppDbContext context) //Injecting the AppDbContext file
        {
            _context = context;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allShops = await _context.Shops.ToListAsync(); //we are returning the shop data as a list of shops
            return View(allShops);
        }
    }
}
