using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using PagedList.Mvc;
using PagedList;

namespace WebTraSua.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem

        dbQTrasuaDataContext db = new dbQTrasuaDataContext();
        [HttpGet]
        public ActionResult KQTimkiem(string sTukhoa,int ? page)
        {
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            //tim kiem theo ten san pham
            var listSP = db.Trasuas.Where(n=>n.TenTS.Contains(sTukhoa));
            ViewBag.Tukhoa = sTukhoa;
            return View(listSP.OrderBy(n => n.TenTS).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTukhoa)
        {
            //goij ve ham get tim kiem

            return RedirectToAction("KQTimkiem", new {@sTukhoa=sTukhoa});
        }
    }
}