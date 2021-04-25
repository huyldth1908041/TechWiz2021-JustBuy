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
        public string UserId { get; set; }
        //navigation property
        public virtual AppUser User { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus
        {
            Pending = 0,
            Done = 1,
            Processing = 2,
            Canceled = -1,
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public OrderPaymentMethod PaymentMethod { get; set; }

        public double ShippingFee { get; set; }
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

        public double CalculateTotalPrice()
        {
            var listOrdertails = this.OrderDetails.ToList();
            if( listOrdertails == null || listOrdertails.Count() == 0)
            {
                return 0;
            }
            double totalPrice = 0;
            foreach(var item in listOrdertails)
            {
                totalPrice += item.CalculateTotalPrice();
            }
            totalPrice += this.ShippingFee;
            this.TotalPrice = totalPrice;
            return this.TotalPrice;
        }
        public double GetTotalCartPrice()
        {
            var listOrdertails = this.OrderDetails.ToList();
            if(listOrdertails == null || listOrdertails.Count() == 0)
            {
                return 0;
            }
            double totalPrice = 0;
            foreach (var item in listOrdertails)
            {
                totalPrice += item.CalculateTotalPrice();
            }
            return totalPrice;

        }



    }
}