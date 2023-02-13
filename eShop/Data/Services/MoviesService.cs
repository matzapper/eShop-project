using eShop.Data.Base;
using eShop.Data.ViewModels;
using eShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService
    {
        //Injecting the AppDbContext
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //Adding a movie
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ShopId = data.ShopId,
                MovieCategory = data.MovieCategory,
                DirectorId = data.DirectorId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Adding Movie actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        //Getting a movie by id
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies.
                Include(s => s.Shop).
                Include(d => d.Director).
                Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).
                FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        //Dropdown menus for when we are adding a movie
        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Shops = await _context.Shops.OrderBy(n => n.Name).ToListAsync(),
                Directors = await _context.Directors.OrderBy(n => n.FullName).ToListAsync()
            };
            
            return response;
        }
        
        //Updating a movie
        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.ShopId = data.ShopId;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.DirectorId = data.DirectorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Adding Movie actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
