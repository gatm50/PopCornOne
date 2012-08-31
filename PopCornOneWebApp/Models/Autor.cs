using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PopCornOneWebApp.Models
{
    public class Autor
    {
        [DataMember]
        public int AutorId { get; set; }
        
        [Required]
        [Display(Name = "Autor name")]
        [DataMember]
        public string AutorName { get; set; }

        [Display(Name = "Autor More Information Url")]
        [DataMember]
        public string AutorUrl { get; set; }

        //public virtual ICollection<Phrase> Phrases { get; set; }
    }
}