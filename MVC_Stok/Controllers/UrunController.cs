using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;


namespace MVC_Stok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVC_StokEntities db = new MVC_StokEntities();
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            //LINQ Sorgusu
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                select new SelectListItem
                { Text = i.KATEGORIAD,
                    Value = i.KATEGORIID.ToString()
                }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(URUNLER p1)
        {
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p1.KATEGORILER.KATEGORIID).FirstOrDefault();
            p1.KATEGORILER = ktg;
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(URUNLER p1)
        {
            var urun = db.URUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.URUNMARKA = p1.URUNMARKA;
            urun.URUNSTOK = p1.URUNSTOK;
            urun.URUNFIYAT = p1.URUNFIYAT;
            //urun.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.KATEGORILER.Where(m => m.KATEGORIID == p1.KATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}