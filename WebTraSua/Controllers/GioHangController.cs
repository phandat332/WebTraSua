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
       
       dbQTrasuaDataContext _db = new dbQTrasuaDataContext();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //phuong thuc add item vao gio hang
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.Trasuas.SingleOrDefault(s=>s.MaTS == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "GioHang");
        }
        // trang gio hang
        public ActionResult Index()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "GioHang");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "GioHang");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //public ActionResult Update_Quantity_Cart(FormCollection form)
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    int id_pro = int.Parse(form["ID_Product"]);
        //    int quantity = int.Parse(form["Quantity"]);
        //    cart.Update_Quantity_Shopping(id_pro, quantity);
        //    return RedirectToAction("ShowToCart", "GioHang");
        //}
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "GioHang");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.inforCart = _t_item;
            return PartialView("BagCart");
        }
    }
}