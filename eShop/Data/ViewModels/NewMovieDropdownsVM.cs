using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Directors = new List<Director>();
            Shops = new List<Shop>();
            Actors = new List<Actor>();
        }

        public List<Director> Directors { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Actor> Actors { get; set; }
    }
}

