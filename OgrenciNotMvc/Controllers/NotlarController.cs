using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
		DbMvcOkulEntities db = new DbMvcOkulEntities();
		// GET: Notlar
		public ActionResult Index()
        {
			var notlar = db.TblNotlar.ToList();
            return View(notlar);
        }
		[HttpGet]
		public ActionResult NotEkle()
		{
			List<SelectListItem> ogrenci = (from x in db.TblOgrenciler
											select new SelectListItem
											{
												Text = x.Ad + " " + x.Soyad,
												Value = x.Id.ToString()
											}).ToList();
			ViewBag.ogr = ogrenci;
			List<SelectListItem> ders = (from y in db.TblDersler
											select new SelectListItem
											{
												Text = y.DersAd,
												Value = y.DersId.ToString()
											}).ToList();
			ViewBag.drs = ders;
			return View();
		}
		[HttpPost]
		public ActionResult NotEkle(TblNotlar not)
		{
			db.TblNotlar.Add(not);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult NotGuncelle(int id)
		{
			List<SelectListItem> ogrenci = (from x in db.TblOgrenciler
											select new SelectListItem
											{
												Text = x.Ad + " " + x.Soyad,
												Value = x.Id.ToString()
											}).ToList();
			ViewBag.ogr = ogrenci;
			List<SelectListItem> ders = (from y in db.TblDersler
										 select new SelectListItem
										 {
											 Text = y.DersAd,
											 Value = y.DersId.ToString()
										 }).ToList();
			ViewBag.drs = ders;
			var bilgiler = db.TblNotlar.Find(id);
			return View(bilgiler);
		}
		[HttpPost]
		public ActionResult NotGuncelle(TblNotlar not)
		{
			db.TblNotlar.Add(not);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}