using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class Order
    {
        public int Id { get; set; }
        //forein key
        public int UserId { get; set; }
        //navigation property
        public virtual AppUser User { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus
        {
            Pending = 0,
            Done = 1,
            Canceled = -1,
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public OrderPaymentMethod PaymentMethod { get; set; }
        public enum OrderPaymentMethod
        {
            [Display(Name ="Card")]
            Card,
            [Display(Name = "Cash on direct")]
            COD
        }
        public DateTime DeliveryDate { get; set; }
        //navigation
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}