using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dawaly.Models
{
    public class ApplyToPlace
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int  PlaceId { get; set; }
        public string UserId { get; set; }

        public virtual Place Place { get; set; }    
        public virtual ApplicationUser User { get; set; }
    }
}