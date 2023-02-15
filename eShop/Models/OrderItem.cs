using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } //unique identifier for the order item
        public int Amount { get; set; } //Number of items a customer/user has ordered
        public double Price { get; set; } //Movie price
        public int MovieId { get; set; } //Reference for the movie that is being ordered
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; } //Relationship between an order item and a movie

        public int OrderId { get; set; } //Reference for the order
        [ForeignKey("OrderId")]
        public Order Order { get; set; } //Relationship between an order item and an order
    }
}
