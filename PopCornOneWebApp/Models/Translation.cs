using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PopCornOneWebApp.Models
{
    public class Translation
    {
        public int TranslationId { get; set; }
        
        [Required]
        [Display(Name = "Translation content")]
        [DataMember]
        public string TranslationContent { get; set; }

        [Display(Name = "Translation description")]
        [DataMember]
        public string TranslationDescription { get; set; }
        
        [DataMember]
        public string TranslationFirstLetter { get; set; }

        [DataMember]
        public string Lexicon { get; set; }

        [DataMember]
        public int LanguageId { get; set; }

        [DataMember]
        public int PhraseId { get; set; }

        [DataMember]
        public bool PhraseByDefault { get; set; }

        //[DataMember]
        //public virtual Language Language_ { get; set; }

        //[DataMember]
        //public virtual Phrase Phrase_ { get; set; }
    }
}