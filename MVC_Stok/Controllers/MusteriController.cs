﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok.Models.Entity;

namespace MVC_Stok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVC_StokEntities db = new MVC_StokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.MUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.MUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER p1)
        {
            if (ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.MUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.MUSTERILER.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult MusteriGuncelle(MUSTERILER p1)
        {
            var musteri=db.MUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}