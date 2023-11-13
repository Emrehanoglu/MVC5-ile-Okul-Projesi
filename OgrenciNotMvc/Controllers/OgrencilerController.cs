using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
		DbMvcOkulEntities db = new DbMvcOkulEntities();
		// GET: Ogrenciler
		public ActionResult Index()
        {
			var ogrenciler = db.TblOgrenciler.ToList();
            return View(ogrenciler);
        }
		[HttpGet]
		public ActionResult OgrenciEkle()
		{
			List<SelectListItem> kulupler = (from x in db.TblKulüpler
											 select new SelectListItem
											 {
												 Text = x.Ad,
												 Value = x.Id.ToString()
											 }).ToList();
			ViewBag.kulupList = kulupler;
			return View();
		}
		[HttpPost]
		public ActionResult OgrenciEkle(TblOgrenciler ogr)
		{
			db.TblOgrenciler.Add(ogr);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult OgrenciSil(int id)
		{
			var ogrenci = db.TblOgrenciler.Find(id);
			db.TblOgrenciler.Remove(ogrenci);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult OgrenciGuncelle(int id)
		{
			List<SelectListItem> Cinsiyet = new List<SelectListItem>();
			Cinsiyet.Add(new SelectListItem() { Text = "Erkek", Value = "Erkek" });
			Cinsiyet.Add(new SelectListItem() { Text = "Kız", Value = "Kız" });
			ViewBag.cnsyt = Cinsiyet;

			List<SelectListItem> kulupler = (from x in db.TblKulüpler
											 select new SelectListItem
											 {
												 Text = x.Ad,
												 Value = x.Id.ToString()
											 }).ToList();
			ViewBag.kulupList = kulupler;
			var ogrenci = db.TblOgrenciler.Find(id);
			return View(ogrenci);
		}
		[HttpPost]
		public ActionResult OgrenciGuncelle(TblOgrenciler ogr)
		{
			var guncOgr = db.TblOgrenciler.Find(ogr.Id);
			guncOgr.Ad = ogr.Ad;
			guncOgr.Soyad = ogr.Soyad;
			guncOgr.Cinsiyet = ogr.Cinsiyet;
			guncOgr.Fotograf = ogr.Fotograf;
			guncOgr.Kulüp = ogr.Kulüp;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}