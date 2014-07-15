using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models.Entities;
using MyBlog.Models;
using WebMatrix.WebData;
using MyBlog.Filters;

namespace MyBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private EFDbContext db = new EFDbContext();

        //
        // GET: /Blog/
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            int userId = WebSecurity.CurrentUserId;
            var blog = db.Blogs.Where(d => d.BlogUserId == userId).SingleOrDefault();
            if (blog == null)
            {
                return RedirectToAction("Create");
            }
            return View(blog);
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                int userId = WebSecurity.CurrentUserId;

                blog.BlogDate = DateTime.Now;
                blog.BlogUserId = userId;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogUserId = new SelectList(db.BlogUsers, "BlogUserId", "Username", blog.BlogUserId);
            return View(blog);
        }

        //
        // GET: /Blog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogUserId = new SelectList(db.BlogUsers, "BlogUserId", "Username", blog.BlogUserId);
            return View(blog);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogUserId = new SelectList(db.BlogUsers, "BlogUserId", "Username", blog.BlogUserId);
            return View(blog);
        }

        //
        // GET: /Blog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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