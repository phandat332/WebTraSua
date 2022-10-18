using PagedList;
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
        dbQTrasuaDataContext db = new dbQTrasuaDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TSHotPartial()
        {
            var lstTSHot = db.Trasuas.Take(6).ToList();
            return PartialView(lstTSHot);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult product(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            return View(db.Trasuas.ToList().OrderBy(n => n.MaTS).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult details(int id)
        {
            var trasua = from s in db.Trasuas
                         where s.MaTS == id
                         select s;
            return View(trasua.Single());

        }
        public ActionResult ThuongHieuTS()
        {
            var thuonghieu = from th in db.Thuonghieus select th;
            return PartialView(thuonghieu);
        }
     
        public ActionResult Lienhe()
        {
            return View();
        }
    }
}