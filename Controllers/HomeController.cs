using MyBlog.Filters;
using MyBlog.Models;
using MyBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            EFDbContext db = new EFDbContext();
            //int userId = WebSecurity.CurrentUserId;
            //var blog = db.Blogs.Where(d => d.BlogUserId == userId).SingleOrDefault();
            var articles=db.Articles.OrderByDescending(d => d.ArticleDate).Take(3);//blog.NumOfArticlesInFirstPage);
           //ViewBag.SummaryLength=blog.SummaryLength;
            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CertificatesLogo()
        {
            List<LogoInfo> logos = new List<LogoInfo>();
            logos.Add(new LogoInfo(){ ImageSource = "/Images/MCP_2013.png", Desc = "Microsoft Certified Professional" });
            return PartialView(logos);
        }
        public ActionResult ContactMe()
        {
            return View();
        }
    }
}
