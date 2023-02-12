using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
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
        private readonly IShopsService _service;

        public ShopsController(IShopsService service) //Injecting the AppDbContext file
        {
            _service = service;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allShops = await _service.GetAllAsync(); //we are returning the shop data as a list of shops
            return View(allShops);
        }

        //GET: Shops/Create
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Shop shop) 
        {
            if(!ModelState.IsValid) return View(shop);
            await _service.AddAsync(shop);
            return RedirectToAction(nameof(Index));
        }

        //GET: Shops/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        //GET: Shops/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Shop shop)
        {
            if (!ModelState.IsValid) return View(shop);
            await _service.UpdateAsync(id, shop);
            return RedirectToAction(nameof(Index));
        }

        //GET: Shops/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
