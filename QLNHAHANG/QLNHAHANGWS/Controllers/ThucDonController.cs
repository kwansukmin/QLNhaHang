using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNHAHANGWS.Models;
using PagedList;


namespace QLNHAHANGWS.Controllers
{
    public class ThucDonController : Controller
    {
        private QLNHAHANGDbContext db = new QLNHAHANGDbContext();

        public ActionResult TheoLoai(int id = 0, string name = "", int? page)
        {
            List<ThucDon> dsThucDon=db.ThucDons.Where(p=>p.NhomMon.PhanLoaiID==id).OrderByDescending(p=>p.NgayCapNhat).ToList();
            if(dsThucDon.Count==0)
            {
                object nd ="Truy cập không tồn tại!";
                return View("ThongBao", nd);
            }
            PhanLoai phanloai=db.PhanLoais.SingleOrDefault(p=>p.PhanLoaiID==id);
            ViewBag.Message="Thực đơn thuộc phân loại -" + phanloai.TenPhanLoai;
            ViewBag.Title="Thực Đơn";
            int pageSize = 3;
            int pageNumber = (page?? 1);
            return View("DanhSach", dsThucDon.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TheoMon(int id=0, string name="")
        {
            List<ThucDon> dsThucDon = db.ThucDons.Where(p => p.NhomMon.NhomMonID == id).OrderByDescending(p => p.NgayCapNhat).ToList();
            if (dsThucDon.Count == 0)
            {
                object nd = "Truy cập không tồn tại!";
                return View("ThongBao", nd);
            }

            NhomMon nhommon = db.NhomMons.SingleOrDefault(p => p.NhomMonID == id);
            ViewBag.Title = "Thực Đơn";
            ViewBag.Message = "Thực đơn thuộc nhóm - " + nhommon.TenNhomMon;
            return View("DanhSach", dsThucDon);
        }

        #region Quan Tri Thuc Don
        //
        // GET: /ThucDon/

        public ActionResult Index()
        {
            var thucdons = db.ThucDons.Include(t => t.NhomMon);
            return View(thucdons.ToList());
        }

        //
        // GET: /ThucDon/Details/5

        public ActionResult Details(int id = 0)
        {
            ThucDon thucdon = db.ThucDons.Find(id);
            if (thucdon == null)
            {
                return HttpNotFound();
            }
            return View(thucdon);
        }

        //
        // GET: /ThucDon/Create

        public ActionResult Create()
        {
            ViewBag.NhomMonID = new SelectList(db.NhomMons, "NhomMonID", "TenNhomMon");
            return View();
        }

        //
        // POST: /ThucDon/Create

        [HttpPost]
        public ActionResult Create(ThucDon thucdon)
        {
            if (ModelState.IsValid)
            {
                db.ThucDons.Add(thucdon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NhomMonID = new SelectList(db.NhomMons, "NhomMonID", "TenNhomMon", thucdon.NhomMonID);
            return View(thucdon);
        }

        //
        // GET: /ThucDon/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ThucDon thucdon = db.ThucDons.Find(id);
            if (thucdon == null)
            {
                return HttpNotFound();
            }
            ViewBag.NhomMonID = new SelectList(db.NhomMons, "NhomMonID", "TenNhomMon", thucdon.NhomMonID);
            return View(thucdon);
        }

        //
        // POST: /ThucDon/Edit/5

        [HttpPost]
        public ActionResult Edit(ThucDon thucdon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucdon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NhomMonID = new SelectList(db.NhomMons, "NhomMonID", "TenNhomMon", thucdon.NhomMonID);
            return View(thucdon);
        }

        //
        // GET: /ThucDon/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ThucDon thucdon = db.ThucDons.Find(id);
            if (thucdon == null)
            {
                return HttpNotFound();
            }
            return View(thucdon);
        }

        //
        // POST: /ThucDon/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ThucDon thucdon = db.ThucDons.Find(id);
            db.ThucDons.Remove(thucdon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}