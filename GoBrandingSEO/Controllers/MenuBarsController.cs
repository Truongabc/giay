using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoBrandingSEO.Models;

namespace GoBrandingSEO.Controllers
{
    public class MenuBarsController : Controller
    {
        private SEOWEBEntities db = new SEOWEBEntities();

        // GET: MenuBars
        public ActionResult Menu()
        {
            return View(db.MenuBars.ToList());
        }
    }
}
