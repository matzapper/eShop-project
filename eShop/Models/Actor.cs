using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; } //Unique identifier for this model
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; } //Profile picture of the actor
        [Display(Name = "Full Name")]
        public string FullName { get; set; } //Name/Surname of the actor
        [Display(Name = "Biography")]
        public string Bio { get; set; } //Biography of the actor

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
