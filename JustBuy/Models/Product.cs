using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class Product
    {
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "dwarrion";

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public double Price { get; set; }
        public ProductStatus Status { get; set; }

        public enum ProductStatus
        {
            DeActive,
            Active,

        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Images { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }
        //navigation properties
        public int CategoryId{ get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime LaunchDate { get; set; }

        public string GetSmallImage()
        {
            if (this.Images == null || this.Images.Length == 0)
            {
                this.Images = "No-Image-Placeholder";
            }
            //get first cover
            var listCover = this.Images.Split(',');
            var firstCover = listCover[0];
            return _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_100/v1616932607/" + firstCover + ".jpg";
        }

        public List<string> GetAllImages()
        {
            if (this.Images == null || this.Images.Length == 0)
            {
                this.Images = "No-Image-Placeholder";
            }
            var listCover = this.Images.Split(',');
            var listImagesUrl = new List<string>();
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1616932607/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

        public List<string> GetMediumCovers()
        {
            if (this.Images == null || this.Images.Length == 0)
            {
                this.Images = "No-Image-Placeholder";
            }
            var listCover = this.Images.Split(',');
            var listImagesUrl = new List<string>();
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_550,h_520/v1617164737/" + item + ".jpg";
                listImagesUrl.Add(url);
            }
            return listImagesUrl;
        }

    }
}