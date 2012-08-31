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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AutorService" in code, svc and config file together.
    public class AutorService : IAutorService
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        public List<Models.Autor> DisplayAutors()
        {
            List<Autor> res = context.Autors.ToList();
            return res;
        }

        public bool CreateAutor(Models.Autor autor)
        {
            try
            {
                context.Autors.Add(autor);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditAutor(Models.Autor autor)
        {
            try
            {
                context.Entry(autor).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteAutor(int id)
        {
            try
            {
                Autor autor = context.Autors.Single(x => x.AutorId == id);
                if (context.Phrases.Where(x => x.AutorId == autor.AutorId).Count() > 0)
                    return false;
                context.Autors.Remove(autor);
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
