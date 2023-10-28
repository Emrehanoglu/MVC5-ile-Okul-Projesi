using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
		DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {
			var kulupler = db.TblKulüpler.ToList();
            return View(kulupler);
        }
		[HttpGet]
		public ActionResult KulupEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult KulupEkle(TblKulüpler kulup)
		{
			db.TblKulüpler.Add(kulup);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}