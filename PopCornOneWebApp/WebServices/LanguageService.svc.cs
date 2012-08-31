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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LanguageService" in code, svc and config file together.
    public class LanguageService : ILanguageService
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        public List<Language> DisplayLanguages()
        {
            List<Language> res = context.Languages.ToList();
            return res;
        }

        public bool CreateLanguage(Models.Language language)
        {
            try
            {
                context.Languages.Add(language);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditLanguage(Models.Language language)
        {
            try
            {
                context.Entry(language).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteLanguage(int id)
        {
            try
            {
                Language language = context.Languages.Single(x => x.LanguageId == id);
                if (context.Translations.Where(x => x.LanguageId == language.LanguageId).Count() > 0)
                    return false;
                context.Languages.Remove(language);
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
