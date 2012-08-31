using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PopCornOneWebApp.Models
{
    public class PopCornOneWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<PopCornOneWebApp.Models.PopCornOneWebAppContext>());

        public DbSet<PopCornOneWebApp.Models.Autor> Autors { get; set; }

        public DbSet<PopCornOneWebApp.Models.Origin> Origins { get; set; }

        public DbSet<PopCornOneWebApp.Models.Language> Languages { get; set; }

        public DbSet<PopCornOneWebApp.Models.Phrase> Phrases { get; set; }

        public DbSet<PopCornOneWebApp.Models.Translation> Translations { get; set; }
    }
}