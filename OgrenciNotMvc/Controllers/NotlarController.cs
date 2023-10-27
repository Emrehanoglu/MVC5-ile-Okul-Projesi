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
    }
}