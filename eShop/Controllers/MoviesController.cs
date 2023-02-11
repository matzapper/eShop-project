using eShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class MoviesController : Controller
    {
        //Declaring the appdbcontext file
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context) //Injecting the AppDbContext file
        {
            _context = context;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allMovies = await _context.Movies.Include(n => n.Shop).OrderBy(n => n.Name).ToListAsync(); //we are returning the movie data as a list of movies
            return View(allMovies);
        }
    }
}
