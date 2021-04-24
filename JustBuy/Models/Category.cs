using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustBuy.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  Description { get; set; }
        public string Cover { get; set; }
        public CategoryStatus Status { get; set; }
        public enum CategoryStatus
        {
            DeActive,
            Active
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //navigation properties
        public virtual ICollection<Product> Products { get; set; }
    }
}