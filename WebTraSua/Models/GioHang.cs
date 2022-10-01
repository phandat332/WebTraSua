using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebTraSua.Models
{
    public class GioHang
    {
        QLTraSuaEntities db = new QLTraSuaEntities();
        public int iMaTS { get; set; }
        public string sTenTS { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Ham Tạo giỏ hàng
        public GioHang(int MaTS)
        {
            iMaTS = MaTS;
            Trasua trasua = db.Trasua.Single(n => n.MaTS == iMaTS);
            sTenTS = trasua.TenTS;
            sAnhBia = trasua.AnhBia;
            dDonGia = double.Parse(trasua.GiaTS.ToString());
            iSoLuong = 1;
        }

    }
}