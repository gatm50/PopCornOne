using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopCornOneWebApp.Models
{
    public class Translation
    {
        public int TranslationId { get; set; }
        
        [Required]
        [Display(Name = "Translation content")]
        public string TranslationContent { get; set; }

        [Display(Name = "Translation description")]
        public string TranslationDescription { get; set; }
        public string TranslationFirstLetter { get; set; }
        public string Lexicon { get; set; }

        public int LanguageId { get; set; }
        public int PhraseId { get; set; }

        public virtual Language Language_ { get; set; }
        public virtual Phrase Phrase_ { get; set; }
    }
}