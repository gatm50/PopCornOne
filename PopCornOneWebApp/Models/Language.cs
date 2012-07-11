using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PopCornOneWebApp.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        [Required]
        [Display(Name = "Language name")]
        public string LanguageName { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
    }
}