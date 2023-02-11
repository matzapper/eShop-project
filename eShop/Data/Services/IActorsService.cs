using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public interface IActorsService //Here we define 5 methods
    {
        //Method 1 - Get all the actors from the database (Async)
        Task<IEnumerable<Actor>> GetAllAsync();
        //Method 2 - Get a single actor from the database by id
        Task<Actor> GetByIdAsync(int id);
        //Method 3 - Adding an actor to the database
        Task AddAsync(Actor actor);
        //Method 4 - Updating an actor to the database and have him showwn to us
        //We are going to check if the id for this actor exists before we update the actor
        Task<Actor> UpdateAsync(int id, Actor newActor);
        //Method 5 - Deleting an actor from the database
        Task DeleteAsync(int id);
    }
}
