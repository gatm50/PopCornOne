using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.Serialization;

namespace PopCornOneWebApp.Models
{
    //[Serializable]
    public class Language
    {
        [DataMember]
        public int LanguageId { get; set; }

        [Required]
        [Display(Name = "Language name")]
        [DataMember]
        public string LanguageName { get; set; }

        //public virtual ICollection<Language> Languages { get; set; }
    }
}