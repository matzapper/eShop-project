using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class ApplicationUser : IdentityUser //We are inheriting from the IdentityUser base class
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; } //This is an additional column along with the other properties already defined in the IdentityUser base class
    }
}
