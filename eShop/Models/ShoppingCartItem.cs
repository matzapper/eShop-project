using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; } //Unique identifier for the shopping cart item

        public Movie Movie { get; set; } //Relationship between a shopping cart item and a movie 
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } //We are going to clean up the database after the order is complete
    }
}
