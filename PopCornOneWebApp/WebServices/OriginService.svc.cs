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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OriginService" in code, svc and config file together.
    public class OriginService : IOriginService
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        public List<Models.Origin> DisplayOrigins()
        {
            List<Origin> res = context.Origins.ToList();
            return res;
        }

        public bool CreateOrigin(Models.Origin origin)
        {
            try
            {
                context.Origins.Add(origin);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditOrigin(Models.Origin origin)
        {
            try
            {
                context.Entry(origin).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteOrigin(int id)
        {
            try
            {
                Origin origin = context.Origins.Single(x => x.OriginId == id);
                if (context.Phrases.Where(x => x.OriginId == origin.OriginId).Count() > 0)
                    return false;
                context.Origins.Remove(origin);
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
