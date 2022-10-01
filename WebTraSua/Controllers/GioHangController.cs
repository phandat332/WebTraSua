using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
namespace WebTraSua.Controllers
{
    public class GioHangController : Controller
    {
        QLTraSuaEntities db = new QLTraSuaEntities();
        //lay gio hang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        //them gio hang
        public ActionResult ThemGioHang(int iMaTS,string strURL)
        {
            Trasua trasua = db.Trasuaes.SingleOrDefault(n => n.iMaTS == iMaTS);
            List<GioHang> lstGioHang = LayGioHang();
            //kt xem sach da co trong gio hang chua
            GioHang gh = lstGioHang.Find(n => n.iMaTS == iMaTS);
            if (gh != null)
            {
                gh = new GioHang(iMaTS);
            }
        }
        
    }
}