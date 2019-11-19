using GoBrandingSEO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoBrandingSEO.Controllers
{
    public class HomeController : Controller
    {
        private SEOWEBEntities db = new SEOWEBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult abc()
        {
            return View();
        }
        public ActionResult GiayNam()
        {
            return View(db.Giays.SingleOrDefault());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product()
        {
            ViewBag.Message = "you are.";

            return View(db.Giays.ToList());
        }
        public ActionResult LienHe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoGin()
        {
            ViewBag.Message = "Your Login page.";

            return View();
        }
        public ActionResult IndexSearch(string searchTerm)
        {

            var books = from b in db.Giays select b;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                books = db.Giays.Where(b => b.TenGiay.Contains(searchTerm));
            }
            ViewBag.SearchTerm = searchTerm;
            return View(books.ToList());
        }
    }
}