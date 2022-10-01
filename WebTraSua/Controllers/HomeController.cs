using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;


namespace WebTraSua.Controllers
{
 
    public class HomeController : Controller
    {
        // GET: Home
        QLTraSuaEntities db = new QLTraSuaEntities();
        public ActionResult Index()
        {

            return View();
        } 
        public PartialViewResult TSHotPartial()
        { 
            var lstTSHot = db.Trasua.Take(6).ToList();
            return PartialView(lstTSHot);
        }
    }
}