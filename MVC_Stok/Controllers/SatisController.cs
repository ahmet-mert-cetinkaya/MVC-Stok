using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVC_StokEntities db = new MVC_StokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p)
        {
            db.SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}