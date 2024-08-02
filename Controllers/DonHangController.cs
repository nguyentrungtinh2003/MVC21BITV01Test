using Microsoft.AspNetCore.Mvc;
using MVC21BITV01Test.Data;
using MVC21BITV01Test.Models;
using System.Linq;

namespace MVC21BITV01Test.Controllers
{
    public class DonHangController : Controller
    {
        private readonly QlbanHangContext _context;

        public DonHangController(QlbanHangContext context)
        {
            _context = context;
        }

        [HttpGet("/donhang/{mahd}")]
        public IActionResult Details(int mahd)
        {
            var hoaDon = _context.HoaDons
                .Where(hd => hd.MaHd == mahd)
                .Select(hd => new HoaDonDetailsViewModel
                {
                    MaHd = hd.MaHd,
                    NgayLapHd = hd.NgayLapHd,
                    KhachHang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKh == hd.MaKh).TenCty,
                    ChiTietHoaDons = _context.ChiTietHoaDons
                        .Where(ct => ct.MaHd == mahd)
                        .Select(ct => new ChiTietHoaDonViewModel
                        {
                            MaSp = ct.MaSp,
                            TenSp = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == ct.MaSp).TenSp,
                            DonViTinh = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == ct.MaSp).DonViTinh,
                            DonGia = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == ct.MaSp).DonGia ?? 0,
                            SoLuong = ct.SoLuong,
                            ThanhTien = ct.SoLuong * (_context.SanPhams.FirstOrDefault(sp => sp.MaSp == ct.MaSp).DonGia ?? 0)
                        }).ToList()
                }).FirstOrDefault();

            if (hoaDon == null)
            {
                return NotFound();
            }

            hoaDon.TongTien = hoaDon.ChiTietHoaDons.Sum(ct => ct.ThanhTien);

            return View(hoaDon);
        }
    }
}
