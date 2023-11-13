using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
		DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Default
        public ActionResult Index()
        {
			var dersler = db.TblDersler.ToList();
            return View(dersler);
        }
		[HttpGet]
		public ActionResult DersEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult DersEkle(TblDersler ders)
		{
			db.TblDersler.Add(ders);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DersSil(int id)
		{
			var ders = db.TblDersler.Find(id);
			db.TblDersler.Remove(ders);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult DersGuncelle(int id)
		{
			var ders = db.TblDersler.Find(id);
			return View(ders);
		}
		[HttpPost]
		public ActionResult DersGuncelle(TblDersler ders)
		{
			var guncelDers = db.TblDersler.Find(ders.DersId);
			guncelDers.DersAd = ders.DersAd;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}