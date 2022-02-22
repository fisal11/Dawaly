using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dawaly.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required]
        [Display(Name ="Type")]
        public string CategortName { get; set; }
        [Required]
        [Display(Name = "Place Description")]
        public string CategortDescription { get; set; }

        public virtual ICollection<Place> home { get; set; }   


    }
}