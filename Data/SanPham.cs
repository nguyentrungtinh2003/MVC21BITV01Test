using System;
using System.Collections.Generic;

namespace MVC21BITV01Test.Data;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public string? DonViTinh { get; set; }

    public double? DonGia { get; set; }

    public string? Hinh { get; set; }
}
