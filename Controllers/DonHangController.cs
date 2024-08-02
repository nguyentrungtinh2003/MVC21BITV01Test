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
                    KhachHang = _context.KhachHangs
                        .Where(kh => kh.MaKh == hd.MaKh)
                        .Select(kh => kh.TenCty)
                        .FirstOrDefault() ?? "Khách hàng không xác định",
                    ChiTietHoaDons = _context.ChiTietHoaDons
                        .Where(ct => ct.MaHd == mahd)
                        .Select(ct => new ChiTietHoaDonViewModel
                        {
                            MaSp = ct.MaSp,
                            TenSp = _context.SanPhams
                                .Where(sp => sp.MaSp == ct.MaSp)
                                .Select(sp => sp.TenSp)
                                .FirstOrDefault() ?? "Sản phẩm không xác định",
                            DonViTinh = _context.SanPhams
                                .Where(sp => sp.MaSp == ct.MaSp)
                                .Select(sp => sp.DonViTinh)
                                .FirstOrDefault() ?? "N/A",
                            DonGia = _context.SanPhams
                                .Where(sp => sp.MaSp == ct.MaSp)
                                .Select(sp => sp.DonGia)
                                .FirstOrDefault() ?? 0,
                            SoLuong = ct.SoLuong,
                            ThanhTien = ct.SoLuong * (_context.SanPhams
                                .Where(sp => sp.MaSp == ct.MaSp)
                                .Select(sp => sp.DonGia)
                                .FirstOrDefault() ?? 0)
                        }).ToList()
                }).FirstOrDefault();

            if (hoaDon == null)
            {
                return NotFound();
            }

            hoaDon.TongTien = hoaDon.ChiTietHoaDons.Sum(ct => ct.ThanhTien);

            return View(hoaDon);
        }

        [HttpPost]
        public IActionResult RedirectToDetails(int maHd)
        {
            return RedirectToAction("Details", new { mahd = maHd });
        }
    }
}
