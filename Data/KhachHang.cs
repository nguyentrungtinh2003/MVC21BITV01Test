using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC21BITV01Test.Data;

public partial class KhachHang
{
    [Required(ErrorMessage = "Mã khách hàng không được để trống")]
    public string MaKh { get; set; } = null!;
    [Required(ErrorMessage = "Tên công ty là bắt buộc")]
    public string TenCty { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int ThanhPho { get; set; }
}