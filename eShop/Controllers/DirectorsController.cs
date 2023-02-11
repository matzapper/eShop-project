using eShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class DirectorsController : Controller
    {
        //Declaring the appdbcontext file
        private readonly AppDbContext _context;

        public DirectorsController(AppDbContext context) //Injecting the AppDbContext file
        {
            _context = context;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allDirectors = await _context.Directors.ToListAsync(); //we are returning the director data as a list of directors
            return View(allDirectors);
        }
    }
}
