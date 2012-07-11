using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopCornOneWebApp.Models
{
    public class Origin
    {
        public int OriginId { get; set; }

        [Required]
        [Display(Name = "Origin name")]
        public string OriginName { get; set; }

        [Display(Name = "Origin More Information Url")]
        public string OriginUrl { get; set; }

        public virtual ICollection<Phrase> Phrases { get; set; }
    }
}