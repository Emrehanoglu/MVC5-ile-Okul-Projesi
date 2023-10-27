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
    }
}