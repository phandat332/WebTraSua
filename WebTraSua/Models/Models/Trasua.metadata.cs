using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebTraSua.Models
{
    [MetadataTypeAttribute(typeof(TrasuaMetadata))]
    public partial class Trasua
    {
        internal sealed class TrasuaMetadata
        {
           
            [Display(Name = "Mã Trà Sữa")]//dùng để đặt cho các cột
            public int MaTS { get; set; }

            [Display(Name = "Tên Trà Sữa")]//dùng để đặt cho các cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// kiểm tra rỗng
            public string TenTS { get; set; }

            [Display(Name = " Giá Trà Sữa")]//dùng để đặt cho các cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// kiểm tra rỗng

            public Nullable<decimal> GiaTS { get; set; }

            [Display(Name = " Anh Sản Phẩm")]//dùng để đặt cho các cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// kiểm tra rỗng
            public string AnhBia { get; set; }

            [Display(Name = " Tên Thương Hiệu")]//dùng để đặt cho các cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// kiểm tra rỗng
            public Nullable<int> MaTH { get; set; }

        }
    }
}