﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string Subject { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}