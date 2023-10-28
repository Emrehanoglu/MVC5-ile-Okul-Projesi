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
	}
}