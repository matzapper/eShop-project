using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eShop.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //Method 1 - Get all the actors from the database (Async)
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        //Method 2 - Get a single actor from the database by id
        Task<T> GetByIdAsync(int id);
        //Method 3 - Adding an actor to the database
        Task AddAsync(T entity);
        //Method 4 - Updating an actor to the database and have him showwn to us
        //We are going to check if the id for this actor exists before we update the actor
        Task UpdateAsync(int id, T entity);
        //Method 5 - Deleting an actor from the database
        Task DeleteAsync(int id);
    }
}
