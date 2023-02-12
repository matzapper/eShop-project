using eShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Shop:IEntityBase
    {
        [Key]
        public int Id { get; set; } //unique identifier for this model
        [Display(Name = "Shop Logo")]
        [Required(ErrorMessage = "Shop Logo is required")]
        public string Logo { get; set; } //Shop logo
        [Display(Name = "Shop Name")]
        [Required(ErrorMessage = "Shop Name is required")]
        public string Name { get; set; } //Shop Name
        [Display(Name = "Shop Desription")]
        [Required(ErrorMessage = "Shop Description is required")]
        public string Description { get; set; } //Shop description

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
