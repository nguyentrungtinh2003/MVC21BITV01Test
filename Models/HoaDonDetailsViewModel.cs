using System;
using System.Collections.Generic;

namespace MVC21BITV01Test.Models
{
    public class ChiTietHoaDonViewModel
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }

    public class HoaDonDetailsViewModel
    {
        public int MaHd { get; set; }
        public DateTime NgayLapHd { get; set; }
        public string KhachHang { get; set; }
        public List<ChiTietHoaDonViewModel> ChiTietHoaDons { get; set; }
        public double TongTien { get; set; }
    }

}
