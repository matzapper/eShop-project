using eShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; } //Unique identifier for this model
        public string Name { get; set; } //Movie name
        public string Description { get; set; } //Movie Description
        public double Price { get; set; } //Movie price
        public string ImageURL { get; set; } //Movie image
        public MovieCategory MovieCategory { get; set; } //We defined a second folder called Data. We called upon it using "using.eRent.Data"

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Stores
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        //Directors
        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
    }
}
