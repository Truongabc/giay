using GoBrandingSEO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

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
        public ActionResult GiayNam(int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.Giays
                         select l).OrderBy(x => x.MaGiay);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.Where(n => n.phai == "Nam" || n.phai == "Cahai").ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GiayNu(int? page)
        {
            if (page == null) page = 1;
            var links = (from l in db.Giays
                         select l).OrderBy(x => x.MaGiay);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.Where(n => n.phai == "Nu" || n.phai == "Cahai").ToPagedList(pageNumber, pageSize));
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
        public ActionResult Product(int? page)
        {

            if (page == null) page = 1;
            var links = (from l in db.Giays
                         select l).OrderBy(x => x.MaGiay);        
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
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
        public ActionResult TinTuc()
        {
            ViewBag.Message = "Your Login page.";
            return View();
        }
        public ActionResult GioHang()
        {
            ViewBag.Message = "Your Login page.";
            return View();
        }
        public ActionResult IndexSearch(string searchTerm, int? page)
        {

            if (page == null) page = 1;
            var links = (from l in db.Giays
                         select l).OrderBy(x => x.MaGiay);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var Shoes = from b in db.Giays select b;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                Shoes = db.Giays.Where(b => b.TenGiay.Contains(searchTerm));
            }
            ViewBag.SearchTerm = searchTerm;
            return View(Shoes.ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}