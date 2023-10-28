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
	}
}