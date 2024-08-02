using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MVC21BITV01Test.Data
{
    public partial class SanPham
    {
        public int MaSp { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(40, ErrorMessage = "Tên sản phẩm không được vượt quá 40 ký tự.")]
        public string TenSp { get; set; } = null!;

        [Required(ErrorMessage = "Đơn vị tính là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Đơn vị tính không được vượt quá 50 ký tự.")]
        public string? DonViTinh { get; set; }

        [Required(ErrorMessage = "Đơn giá là bắt buộc.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0.")]
        public double? DonGia { get; set; }

        [Required(ErrorMessage = "Hình là bắt buộc.")]
        public string? Hinh { get; set; }
    }

}
