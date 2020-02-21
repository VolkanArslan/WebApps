using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArticleApp.Models
{
    public class ArticleContext:DbContext   
    {
        public ArticleContext():base("ArticleDB")
        {
            Database.SetInitializer(new ArticleInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}