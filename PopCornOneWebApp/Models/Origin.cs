using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PopCornOneWebApp.Models
{
    public class Origin
    {
        public int OriginId { get; set; }

        [Required]
        [Display(Name = "Origin name")]
        [DataMember]
        public string OriginName { get; set; }

        [Display(Name = "Origin More Information Url")]
        [DataMember]
        public string OriginUrl { get; set; }

        //public virtual ICollection<Phrase> Phrases { get; set; }
    }
}