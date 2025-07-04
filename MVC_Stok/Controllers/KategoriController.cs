﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MVC_StokEntities db = new MVC_StokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.KATEGORILER.ToList();
            var degerler = db.KATEGORILER.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(KATEGORILER p1)
        {
            if (ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.KATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.KATEGORILER.Find(id);
            db.KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(KATEGORILER p1)
        {
            var ktg = db.KATEGORILER.Find(@p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}