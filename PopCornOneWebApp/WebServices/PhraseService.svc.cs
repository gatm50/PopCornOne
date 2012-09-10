using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PopCornOneWebApp.Models;
using System.Data;

namespace PopCornOneWebApp.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PhraseService" in code, svc and config file together.
    public class PhraseService : IPhraseService
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        public List<Models.Phrase> DisplayPhrases()
        {
            List<Phrase> res = context.Phrases.ToList();
            return res;
        }

        public int CreatePhrase(Models.Phrase phrase)
        {
            try
            {
                context.Phrases.Add(phrase);
                context.SaveChanges();
                return phrase.phraseId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool EditPhrase(Models.Phrase phrase)
        {
            try
            {
                context.Entry(phrase).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletePhrase(int id)
        {
            try
            {
                Phrase phrase = context.Phrases.Single(x => x.phraseId == id);
                context.Phrases.Remove(phrase);
                
                foreach (var item in context.Translations.Where(x => x.PhraseId == id).ToList())
                    context.Translations.Remove(item);

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
