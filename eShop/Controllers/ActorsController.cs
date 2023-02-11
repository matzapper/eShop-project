using eShop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Controllers
{
    public class ActorsController : Controller
    {
        //Declaring the appdbcontext file
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() //default action Index.
        {
            var data = _context.Actors.ToList(); //we are returning the actor data as a list of actors
            return View(data); //using data
        }
    }
}
