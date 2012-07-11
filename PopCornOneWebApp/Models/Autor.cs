using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PopCornOneWebApp.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        
        [Required]
        [Display(Name = "Autor name")]
        public string AutorName { get; set; }

        [Display(Name = "Autor More Information Url")]
        public string AutorUrl { get; set; }

        public virtual ICollection<Phrase> Phrases { get; set; }
    }
}