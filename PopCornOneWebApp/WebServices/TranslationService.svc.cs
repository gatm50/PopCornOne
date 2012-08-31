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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TranslationService" in code, svc and config file together.
    public class TranslationService : ITranslationService
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        public List<Models.Translation> DisplayTranslations()
        {
            List<Translation> res = context.Translations.ToList();
            return res;
        }

        public bool CreateTranslation(Models.Translation translation)
        {
            try
            {
                context.Translations.Add(translation);
                context.SaveChanges();
                if (translation.PhraseByDefault)
                {
                    Models.Phrase phrase = context.Phrases
                        .Where(x => x.phraseId == translation.PhraseId)
                        .FirstOrDefault();
                    phrase.TranslationId = translation.TranslationId;
                    context.Entry(phrase).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditTranslation(Models.Translation translation)
        {
            try
            {
                context.Entry(translation).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTranslation(int id)
        {
            try
            {
                Translation translation = context.Translations.Single(x => x.TranslationId == id);
                if (context.Translations.Where(x => x.PhraseId == translation.PhraseId).Count() > 1)
                {
                    if (translation.PhraseByDefault)
                    {
                        var temporalTranslation = context.Translations.FirstOrDefault(
                            x=>x.TranslationId != translation.TranslationId 
                            && x.PhraseId == translation.PhraseId );
                        temporalTranslation.PhraseByDefault = true;
                        context.Entry(temporalTranslation).State = EntityState.Modified;
                        var temporalPhrase = context.Phrases.FirstOrDefault(x => x.phraseId == translation.PhraseId);
                        temporalPhrase.TranslationId = temporalTranslation.TranslationId;
                        context.Entry(temporalPhrase).State = EntityState.Modified;
                    }
                    context.Translations.Remove(translation);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public List<Translation> DisplayTranslationsByPhraseId(int phraseId)
        {
            List<Translation> res = context.Translations.Where(x => x.PhraseId == phraseId).ToList();
            return res;
        }
    }
}
