using eShop.Data.Base;
using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public interface IActorsService:IEntityBaseRepository<Actor> //Here we inherit from the IEntityBaseRepository
    {

    }
}
