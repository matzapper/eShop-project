using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; } //unique identifier for this model
        [Display(Name = "Shop Logo")]
        public string Logo { get; set; } //Shop logo
        [Display(Name = "Shop Name")]
        public string Name { get; set; } //Shop Name
        [Display(Name = "Shop Desription")]
        public string Description { get; set; } //Shop description

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
