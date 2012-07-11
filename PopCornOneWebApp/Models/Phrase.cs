using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopCornOneWebApp.Models
{
    public class Phrase
    {
        public int phraseId { get; set; }

        public int TranslationId { get; set; }
        public int AutorId { get; set; }
        public int OriginId { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }

        public virtual Autor Autor_ { get; set; }
        public virtual Origin Origin_ { get; set; }
    }
}