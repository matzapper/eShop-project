using eShop.Data.Base;
using eShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService //We are inheriting from the EntityBaseRepository and because it is a generic class it will take a parameter "Actor"
    {
        //Instead of Injecting the DbContext file within the actors service, we are passing the AppDbContext to the base class (The EntityBaseRepository)
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
