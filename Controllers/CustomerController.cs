using Microsoft.AspNetCore.Mvc;
using MVCMidterm.Data;
using MVCMidterm.Models;

namespace MVCMidterm.Controllers
{
    public class CustomerController : Controller
    {
        private readonly QlbanHangContext _context;

        public CustomerController(QlbanHangContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Truy vấn tất cả khách hàng
            var khachHangs = _context.KhachHangs.ToList();

            // Truyền dữ liệu cho view
            return View(khachHangs);
        }
        public static class TinhThanhData
        {
            public static List<TinhThanh> GetTinhThanhList()
            {
                return new List<TinhThanh>
        {
            new TinhThanh { Id = 1, TenTinhThanh = "Hà Nội" },
            new TinhThanh { Id = 2, TenTinhThanh = "Hồ Chí Minh" },
            // ... các tỉnh thành khác
        };
            }
        }
        public IActionResult Create()
        {
            return View(); // Hiển thị form Create.cshtml
        }

        [HttpPost]
        public IActionResult Create(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Chuyển hướng về Index sau khi thêm mới
            }
            ViewBag.TinhThanhList = TinhThanhData.GetTinhThanhList();
            return View(khachHang); // Hiển thị lại form với dữ liệu đã nhập nếu validation thất bại
        }
    }
}