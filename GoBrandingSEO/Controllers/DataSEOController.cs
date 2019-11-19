using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoBrandingSEO.Models;
namespace GoBrandingSEO.Controllers
{
    public class DataSEOController : Controller
    {
        // GET: DataSEO
        SEOWEBEntities DB_Seo = new SEOWEBEntities();
        public ActionResult Index()
        {
            return View(DB_Seo.ADMINs.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Khachhang objUser)
        {
            if (ModelState.IsValid)
            {
                using (SEOWEBEntities db = new SEOWEBEntities())
                {
                    var obj = db.Khachhangs.Where(a => a.TenDN.Equals(objUser.TenDN) && a.MatKhau.Equals(objUser.MatKhau)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.MaKH.ToString();
                        Session["UserName"] = obj.TenDN.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}