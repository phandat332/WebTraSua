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
    public class ChuDeController : Controller
    {
        dbQTrasuaDataContext db = new dbQTrasuaDataContext();
        public ActionResult TSTheoThuongHieu(int id, int? page)
        {// kiem tra thuong hieu co ton tai khong
            
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            Thuonghieu thuonghieu = db.Thuonghieus.SingleOrDefault(n => n.MaTH == id);
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //truy xuat danh sach theo thuong hieu
            List<Trasua> listtrasua = db.Trasuas.Where(n => n.MaTH == id).OrderBy(n => n.GiaTS).ToList();
            if (listtrasua.Count == 0)
            {
                ViewBag.Trasua = "Thương hiệu này chưa mở bán!!";
            }
            else
            {
                int i;
                for ( i = 0; i < listtrasua.Count; i++)
                {
                    i = i++;                 
                }
                ViewBag.soluong = i;
            }
            return View(listtrasua .ToPagedList(pageNumber, pageSize));
        }
    }
}