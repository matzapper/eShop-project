using eShop.Data;
using eShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } //Movie name
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } //Movie Name
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; } //Movie price
        [Display(Name = "Movie cover URL")]
        [Required(ErrorMessage = "Cover is required")]
        public string ImageURL { get; set; } //Movie image
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; } //We defined a second folder called Data. We called upon it using "using.eRent.Data"

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select a shop")]
        [Required(ErrorMessage = "Shop is required")]
        public int ShopId { get; set; }
        [Display(Name = "Select a director")]
        [Required(ErrorMessage = "Director is required")]
        public int DirectorId { get; set; }
    }
}
