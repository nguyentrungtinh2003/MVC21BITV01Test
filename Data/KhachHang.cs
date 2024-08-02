using System;
using System.Collections.Generic;

namespace MVC21BITV01Test.Data;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string TenCty { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int ThanhPho { get; set; }
}
