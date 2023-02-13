using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service) //Injecting the AppDbContext file
        {
            _service = service;
        }
        public async Task<IActionResult> Index() //Using async methods
        {
            var allMovies = await _service.GetAllAsync(n => n.Shop); //we are returning the movie data as a list of movies
            return View(allMovies);
        }

        //Search bar functionality
        public async Task<IActionResult> Filter(string searchString) //Using async methods
        {
            var allMovies = await _service.GetAllAsync(n => n.Shop); //we are returning the movie data as a list of movies
            if (!string.IsNullOrEmpty(searchString)) 
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }

        //GET: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        { 
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail); //We are passing the data from this action to the view
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create() 
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Shops = new SelectList(movieDropdownsData.Shops, "Id", "Name");
            ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie) 
        {
            if (!ModelState.IsValid) 
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Shops = new SelectList(movieDropdownsData.Shops, "Id", "Name");
                ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                ShopId = movieDetails.ShopId,
                DirectorId = movieDetails.DirectorId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Shops = new SelectList(movieDropdownsData.Shops, "Id", "Name");
            ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) 
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Shops = new SelectList(movieDropdownsData.Shops, "Id", "Name");
                ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
