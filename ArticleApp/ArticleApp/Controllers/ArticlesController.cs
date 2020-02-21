using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArticleApp.Models;

namespace ArticleApp.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleContext db = new ArticleContext();

        public ActionResult List(int? id, string q)
        {
            var articles = db.Articles
                                .Where(i => i.Confirm == true)
                                .Select(i => new ArticleModel()
                                {
                                    Id = i.Id,
                                    Header = i.Header.Length > 100 ? i.Header.Substring(0, 100) + "..." : i.Header,
                                    Description = i.Description,
                                    DateOfAdding = i.DateOfAdding,
                                    Confirm = i.Confirm,
                                    Homepage = i.Homepage,
                                    CategoryId = i.CategoryId
                                }).AsQueryable();

            if (string.IsNullOrEmpty("q") == false)
            {
                articles = articles.Where(i => i.Header.Contains(q) || i.Description.Contains(q));
            }

            if (id != null)
            {
                articles = articles.Where(i => i.CategoryId == id);
            }
                                

            return View(articles.ToList());
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Category);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Header,Description,Content,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.DateOfAdding = DateTime.Now;

                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", article.CategoryId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description,Content,Confirm,Homepage,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Articles.Find(article.Id);

                if (entity != null)
                {
                    entity.Header = article.Header;
                    entity.Description = article.Description;
                    entity.Content = article.Content;
                    entity.Confirm = article.Confirm;
                    entity.Homepage = article.Homepage;
                    entity.CategoryId = article.CategoryId;

                    db.SaveChanges();

                    TempData["Article"] = entity;

                    return RedirectToAction("Index");
                }                
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
