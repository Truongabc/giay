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
        SEOWEBEntities Seo = new SEOWEBEntities();
        public ActionResult Index()
        {
            return View(Seo.ADMINs.ToList());
        }

    }
}