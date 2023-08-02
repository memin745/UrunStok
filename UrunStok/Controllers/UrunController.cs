using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStok.Models.Entity;
namespace UrunStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                select new SelectListItem
                {
                    Text = i.KATEGORİAD,
                    Value = i.KATEGORIID.ToString()
                }
                ).ToList();
            ViewBag.dgr=degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBL_URUNLER p1)
        {
            var ktg=db.TBL_KATEGORİLER.Where(m=>m.KATEGORIID==p1.TBL_KATEGORİLER.KATEGORIID).FirstOrDefault();
            p1.TBL_KATEGORİLER=ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }
               ).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBL_URUNLER p)
        {
            var urun = db.TBL_URUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.URUNFİYAT = p.URUNFİYAT;
            urun.STOK = p.STOK;
            //urun.URUNKATEGORİ = p.URUNKATEGORİ;
            var ktg = db.TBL_KATEGORİLER.Where(m => m.KATEGORIID == p.TBL_KATEGORİLER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORİ = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}