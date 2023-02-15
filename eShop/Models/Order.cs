using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } //Unique identifier for the order
        public string  Email { get; set; } //User email
        public string UserId { get; set; } //UserId - value of the logged in userid

        public List<OrderItem> OrderItems { get; set; } //Relationship between the order and the order item

    }
}
