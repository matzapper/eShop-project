using eShop.Data.Base;
using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.Services
{
    public class DirectorsService : EntityBaseRepository<Director>, IDirectorsService //We are inheriting from the EntityBaseRepository and the IDirectorsService
    {
        public DirectorsService(AppDbContext context) : base(context)
        {

        }
    }
}
