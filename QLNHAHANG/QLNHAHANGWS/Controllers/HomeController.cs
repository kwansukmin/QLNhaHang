using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNHAHANGWS.Models;

namespace QLNHAHANGWS.Controllers
{
    public class HomeController : Controller
    {
        //
        QLNHAHANGDbContext db = new QLNHAHANGDbContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        

        

        public PartialViewResult _NavigationPartial()
        {
            List<PhanLoai> dsPhanLoai = db.PhanLoais.Include("NhomMons").ToList();
            ViewBag.PhanLoais = dsPhanLoai;
            return PartialView();
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
