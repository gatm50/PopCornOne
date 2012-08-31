using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PopCornOneWebApp.Models
{
    public class Phrase
    {
        [DataMember]
        public int phraseId { get; set; }

        [DataMember]
        public int TranslationId { get; set; }

        [DataMember]
        public int AutorId { get; set; }

        [DataMember]
        public int OriginId { get; set; }

        //[DataMember]
        //public virtual IList<Translation> Translations { get; set; }

        //[DataMember]
        //public virtual Autor Autor_ { get; set; }

        //[DataMember]
        //public virtual Origin Origin_ { get; set; }
    }
}