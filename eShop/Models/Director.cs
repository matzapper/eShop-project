using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; } //Unique identifier for this model
        public string ProfilePictureURL { get; set; } //Profile picture of the director
        public string FullName { get; set; } //Name/Surname of the director
        public string Bio { get; set; } //Biography of the director

        //Relationships
        public List<Movie> Movies { get; set; } //A director can have multiple movies
    }
}
