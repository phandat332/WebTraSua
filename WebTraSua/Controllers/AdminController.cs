using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Web.UI.MobileControls;

namespace WebTraSua.Controllers
{
    public class AdminController : Controller
    { 

        dbQTrasuaDataContext db = new dbQTrasuaDataContext();
        // GET: Admin_QLsanpham
        public ActionResult Index()
        {
            List<Trasua> list = db.Trasuas.ToList();
            int v = list.Count();
            List<TaiKhoan> lists = db.TaiKhoans.ToList();
            int N = lists.Count();
            List<Thuonghieu> thuonghieus = db.Thuonghieus.ToList();
            
            List<TaiKhoan> taiKhoans = db.TaiKhoans.ToList();
            int teenStudents = taiKhoans.Count(s => s.MaQuyen == 2);
            ViewBag.totalElements = v;
            ViewBag.Description = teenStudents;
            ViewBag.thuonghieu = db.Thuonghieus.Count();
            ViewBag.quyen = db.PhanQuyens.Count();
            return View();   
        }
        #region QUẢN LÝ SẢN PHẨM
        public ActionResult ThemSanPham(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.Trasuas.ToList().OrderBy(n => n.MaTS).ToPagedList(pageNumber, pageSize));
        }
        // the moi san pham
        [HttpGet]
        public ActionResult Themmoisp()
        {
            ViewBag.MaTH = new SelectList(db.Thuonghieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoisp(Trasua trasua, HttpPostedFileBase fileupload)
        {
            var fileName = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
            if (System.IO.File.Exists(path))
            {
                ViewBag.Thongbao = "Hình ảnh đã tồn tại ";
            }
            else
            {
                //luu hinh anh vao duong dan
                fileupload.SaveAs(path);
            }
            ViewBag.MaTH = new SelectList(db.Thuonghieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");
            trasua.AnhBia = fileName;
            db.Trasuas.InsertOnSubmit(trasua);
            db.SubmitChanges();
            return RedirectToAction("ThemSanPham");
        }

        //hien thi san pham
        public ActionResult Chitietsp(int id)
        {
            Trasua trasua = db.Trasuas.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = trasua.MaTS;
            if (trasua == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(trasua);
        }
        //xoa san pham
        [HttpGet]
        public ActionResult Xoasp(int id)
        {
            Trasua trasua = db.Trasuas.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = trasua.MaTS;
            if (trasua == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(trasua);
        }
        [HttpPost, ActionName("Xoasp")]
        public ActionResult Xacnhanxoa(int id)
        {
            Trasua trasua = db.Trasuas.SingleOrDefault(n => n.MaTS == id);
            ViewBag.MaTS = trasua.MaTS;
            if (trasua == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Trasuas.DeleteOnSubmit(trasua);
            db.SubmitChanges();
            return RedirectToAction("ThemSanPham");
        }
        //chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult Suasp(int id)
        {
            ViewBag.MaTH = new SelectList(db.Thuonghieus.ToList().OrderBy(n => n.MaTH), "MaTH", "TenTH");
            Trasua trasua = db.Trasuas.SingleOrDefault(n => n.MaTS == id);
            if (trasua == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(trasua);
        }
        [HttpPost, ActionName("Suasp")]
        [ValidateInput(false)]
        public ActionResult DropDownList(int id)
        {

            Trasua product = db.Trasuas.SingleOrDefault(n => n.MaTS == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.MaTS = product.MaTS;
            UpdateModel(product);
            db.SubmitChanges();
            return RedirectToAction("ThemSanPham");
        }
        #endregion
        #region QUẢN LÝ THƯƠNG HIỆU
        public ActionResult QLThuonghieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            return View(db.Thuonghieus.ToList().OrderBy(n => n.MaTH).ToPagedList(pageNumber, pageSize));
        }
        //Them thuong hieu
        [HttpGet]
        public ActionResult Themmoith()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Themmoith(Thuonghieu thuonghieu)
        {
            db.Thuonghieus.InsertOnSubmit(thuonghieu);
            db.SubmitChanges();
            return RedirectToAction("QLThuonghieu");
        }
        //xoa thuong hieu
        [HttpGet]
        public ActionResult Xoath(int id)
        {
            
            
                Thuonghieu dm = db.Thuonghieus.SingleOrDefault(n => n.MaTH == id);
                if (dm == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                ViewBag.idDM = dm.MaTH;
                return View(dm);
          
        }
        [HttpPost, ActionName("Xoath")]
        public ActionResult AcceptXoath(int id)
        {
            Thuonghieu dm = db.Thuonghieus.SingleOrDefault(n => n.MaTH == id);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.idDM = dm.MaTH;
            db.Thuonghieus.DeleteOnSubmit(dm);
            db.SubmitChanges();
            return RedirectToAction("QLThuonghieu");
        }
        //sua thuong hieu
        [HttpGet]
        public ActionResult Suath(int id)
        {
            Thuonghieu thuonghieu = db.Thuonghieus.SingleOrDefault(n => n.MaTH == id);
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(thuonghieu);
        }
        [HttpPost, ActionName("Suath")]
        [ValidateInput(false)]
        public ActionResult DropDown(int id)
        {

            Thuonghieu thuonghieu = db.Thuonghieus.SingleOrDefault(n => n.MaTH == id);
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.MaTS = thuonghieu.MaTH;
            UpdateModel(thuonghieu);
            db.SubmitChanges();
            return RedirectToAction("QLThuonghieu");
        }

        #endregion
    }
}