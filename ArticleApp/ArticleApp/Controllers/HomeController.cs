using ArticleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleApp.Controllers
{
    public class HomeController : Controller
    {
        private ArticleContext context = new ArticleContext();
        // GET: Home
        public ActionResult Index()
        {
            var articles = context.Articles
                                .Where(i => i.Confirm == true && i.Homepage == true)
                                .Select(i => new ArticleModel()
                                {
                                    Id = i.Id,
                                    Header = i.Header.Length > 100 ? i.Header.Substring(0, 100) + "..." : i.Header,
                                    Description = i.Description,
                                    DateOfAdding = i.DateOfAdding,
                                    Confirm = i.Confirm,
                                    Homepage = i.Homepage
                                });
                                

            return View(articles.ToList());
        }
    }
}