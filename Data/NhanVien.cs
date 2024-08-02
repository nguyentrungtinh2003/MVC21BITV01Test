using System;
using System.Collections.Generic;

namespace MVC21BITV01Test.Data;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public bool? Nu { get; set; }

    public DateOnly? NgayNv { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Hinh { get; set; }

    public string MaDn { get; set; } = null!;

    public string MatKhau { get; set; } = null!;
}
