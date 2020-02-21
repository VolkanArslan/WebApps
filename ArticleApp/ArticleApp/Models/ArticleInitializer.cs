using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArticleApp.Models
{
    public class ArticleInitializer : DropCreateDatabaseIfModelChanges<ArticleContext>
    {
        protected override void Seed(ArticleContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() { CategoryName = "C#" },
                new Category() { CategoryName = "Asp.Net MVC" },
                new Category() { CategoryName = "Asp.Net WebForm" },
                new Category() { CategoryName = "Windows Form" },
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Article> articles = new List<Article>()
            {
                new Article() { Header = "C# Delegates Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-10), Homepage = true, Confirm = true, Content = "tyjhuryhdgssfdfghjsghjgghjg", CategoryId = 1 },
                new Article() { Header = "C# Generic List Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-10), Homepage = true, Confirm = false, Content = "sdjnsfjknjfnsjkndjkgnsrfkjnskngjkfngj", CategoryId = 1 },
                new Article() { Header = "C# li bişeyler Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-30), Homepage = true, Confirm = true, Content = "mwserftgfeghyjnmjnhyfu", CategoryId = 2 },
                new Article() { Header = "C# blabla Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-10), Homepage = true, Confirm = true, Content = "htgryjhngmhwzrf", CategoryId = 3 },
                new Article() { Header = "C# Delegates Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-20), Homepage = true, Confirm = true, Content = "hjnrgyfhdgzhhngfjnfryj", CategoryId = 4 },
                new Article() { Header = "C# Delegates Hakkında", Description = "Delegates Açıklama", DateOfAdding = DateTime.Now.AddDays(-10), Homepage = true, Confirm = false, Content = "grfsgrfgsrfgsrfgsrfg", CategoryId = 4 },
            };

            foreach (var item in articles)
            {
                context.Articles.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}