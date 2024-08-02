using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                TempData["successMessage"] = "Thêm mới khách hàng thành công!";
                return View();
            }
            return View(khachHang);
        }
    }
}