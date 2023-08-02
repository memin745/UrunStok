using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStok.Models.Entity;

namespace UrunStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler =db.TBL_MUSTERİ.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERİ p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_MUSTERİ.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBL_MUSTERİ.Find(id);
            db.TBL_MUSTERİ.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_MUSTERİ.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TBL_MUSTERİ p1)
        {
            var musteri = db.TBL_MUSTERİ.Find(p1.MUSTERIID);
            musteri.MUSTERİAD = p1.MUSTERİAD;
            musteri.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}