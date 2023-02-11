using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Actor
    {
        [Key] //Data annotation for the id/key
        public int Id { get; set; } //Unique identifier for this model
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")] //Make it so that entering a profile picture is required
        public string ProfilePictureURL { get; set; } //Profile picture of the actor
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")] //Make it so that entering a full name is required
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string FullName { get; set; } //Name/Surname of the actor
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")] //Make it so that entering a biography is required
        public string Bio { get; set; } //Biography of the actor

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
