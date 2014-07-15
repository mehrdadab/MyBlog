using MyBlog.Filters;
using MyBlog.Models;
using MyBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MyBlog.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private EFDbContext db = new EFDbContext();

        //
        // GET: /Article/

        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Blog);
            return View(articles.ToList());
        }

        //
        // GET: /Article/Details/5

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Article/Create

        public ActionResult Create()
        {
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName");
            return View();
        }

        //
        // POST: /Article/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                int userId = WebSecurity.CurrentUserId;
                var blog = db.Blogs.Where(d => d.BlogUserId == userId).SingleOrDefault();
                if (blog == null)
                {
                    return RedirectToAction("index", "Blog");
                }
                article.ArticleDate = DateTime.Now;
                article.BlogId = blog.BlogId;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", article.BlogId);
            return View(article);
        }
        [AllowAnonymous]
        public ActionResult Content(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", article.BlogId);
            return View(article);
        }

        //
        // GET: /Article/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", article.BlogId);
            return View(article);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                int userId = WebSecurity.CurrentUserId;
                var blog = db.Blogs.Where(d => d.BlogUserId == userId).SingleOrDefault();
                article.BlogId = blog.BlogId;
               // article.ArticleContent = HttpUtility.HtmlEncode(article.ArticleContent);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", article.BlogId);
            return View(article);
        }
        [AllowAnonymous]
        public ActionResult Articles(String date=null)
        {
            DateTime minDate = DateTime.MinValue;
            DateTime maxDate= DateTime.MaxValue;
            bool successfulDateParse = false;
            //int userId = WebSecurity.CurrentUserId;
            var blog = db.Blogs.FirstOrDefault();
            if (date == null)
            {
                minDate = DateTime.MinValue;
                maxDate = DateTime.MaxValue;

            }
            else
            {
               successfulDateParse= DateTime.TryParse("1 " + date.Replace("_"," "),out minDate);
            }
            if (successfulDateParse)
            {
                maxDate = minDate.AddMonths(1);
            }

            var articles = db.Articles
                .Where(d => d.BlogId == blog.BlogId && d.ArticleDate>=minDate && d.ArticleDate<maxDate)
                .OrderByDescending(d => d.ArticleDate)
                .Take(blog.NumOfArticlesInFirstPage);
            return View(articles);
        }
        [InitializeSimpleMembership]
        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult ArchiveMonths()
        {
            int userId = WebSecurity.CurrentUserId;
            var blog = db.Blogs.Where(d => d.BlogUserId == userId).SingleOrDefault();
            var articleDates = db.Articles.OrderBy(d=>d.ArticleDate).Select(d => d.ArticleDate).Distinct();
            List<String> articleDatesString = new List<String>();
            foreach (var item in articleDates)
            {
                articleDatesString.Add(item.ToString("MMMM yyyy"));
            }
            return PartialView(articleDatesString.Distinct());
        }
        //
        // GET: /Article/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Article/Delete/5

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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}