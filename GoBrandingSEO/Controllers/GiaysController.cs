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
    public class GiaysController : Controller
    {
        private SEOWEBEntities db = new SEOWEBEntities();

        // GET: Giays
        public ActionResult Index()
        {
            var giays = db.Giays.Include(g => g.LoaiGiay).Include(g => g.Nhassanxuat);
            return View(giays.ToList());
        }

        // GET: Giays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // GET: Giays/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiGiays, "MaLoai", "TenLoaiGiay");
            ViewBag.MaNSX = new SelectList(db.Nhassanxuats, "MaNSX", "TenNSX");
            return View();
        }

        // POST: Giays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiay,TenGiay,GiaBan,MoTa,Hinh,MaLoai,MaNSX,NgayBan,SoLuongTonKho,Size,mausac,phai,masale")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Giays.Add(giay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LoaiGiays, "MaLoai", "TenLoaiGiay", giay.MaLoai);
            ViewBag.MaNSX = new SelectList(db.Nhassanxuats, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // GET: Giays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiGiays, "MaLoai", "TenLoaiGiay", giay.MaLoai);
            ViewBag.MaNSX = new SelectList(db.Nhassanxuats, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // POST: Giays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiay,TenGiay,GiaBan,MoTa,Hinh,MaLoai,MaNSX,NgayBan,SoLuongTonKho,Size,mausac,phai,masale")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiGiays, "MaLoai", "TenLoaiGiay", giay.MaLoai);
            ViewBag.MaNSX = new SelectList(db.Nhassanxuats, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // GET: Giays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = db.Giays.Find(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // POST: Giays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giay giay = db.Giays.Find(id);
            db.Giays.Remove(giay);
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
