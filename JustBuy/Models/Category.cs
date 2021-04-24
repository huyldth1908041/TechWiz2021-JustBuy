using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustBuy.Models
{
    public class Category
    {
        private static string _cloudinaryDomain = "https://res.cloudinary.com/";
        private static string _cloudinaryProjectId = "dwarrion";
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

        public string GetSmallImage()
        {
            if (this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "No-Image-Placeholder";
            }
            //get first cover
            var listCover = this.Cover.Split(',');
            var firstCover = listCover[0];
            return _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_100/v1616932607/" + firstCover + ".jpg";
        }

        public List<string> GetAllCover()
        {
            if (this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "No-Image-Placeholder";
            }
            var listCover = this.Cover.Split(',');
            var listCoverUrl = new List<string>();
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/v1616932607/" + item + ".jpg";
                listCoverUrl.Add(url);
            }
            return listCoverUrl;
        }

        public List<string> GetMediumCovers()
        {
            if (this.Cover == null || this.Cover.Length == 0)
            {
                this.Cover = "No-Image-Placeholder";
            }
            var listCover = this.Cover.Split(',');
            var listCoverUrl = new List<string>();
            foreach (var item in listCover)
            {
                var url = _cloudinaryDomain + _cloudinaryProjectId + @"/image/upload/c_scale,w_550,h_520/v1617164737/" + item + ".jpg";
                listCoverUrl.Add(url);
            }
            return listCoverUrl;
        }
    }
}