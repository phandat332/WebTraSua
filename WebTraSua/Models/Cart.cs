﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTraSua.Models;


namespace WebTraSua.Models
{
    public class CartItem
    {
       
        public Trasua _shopping_Trasua { get; set; }
        public int _shopping_quantity { get; set; }
    }
    //gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Trasua _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_Trasua.MaTS == _pro.MaTS);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_Trasua = _pro,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        //public void Update_Quantity_Shopping(int id, int _quantity)
        //{
        //    var item = items.Find(s => s._shopping_Trasua.MaTS == id);
        //    if (item != null)
        //    {
        //        item._shopping_quantity = _quantity;
        //    }
        //}
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_Trasua.GiaTS * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_Trasua.MaTS == id);
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s._shopping_quantity);
        }
    }
}