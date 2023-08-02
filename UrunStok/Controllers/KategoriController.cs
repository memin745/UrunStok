using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStok.Models.Entity;

namespace UrunStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORİLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORİLER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TBL_KATEGORİLER.Find(id);
            db.TBL_KATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORİLER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult Guncelle(TBL_KATEGORİLER p1)
        {
            var ktgr = db.TBL_KATEGORİLER.Find(p1.KATEGORIID);
            ktgr.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}