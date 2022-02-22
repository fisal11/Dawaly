using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dawaly.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Home Type")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Details")]
        public string Details { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Type")]
        public int CategoryId { get; set; }

        public string UserID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }



    }
}