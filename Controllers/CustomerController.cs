using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC21BITV01Test.Data;
using MVC21BITV01Test.Models;

namespace MVC21BITV01Test.Controllers
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
            return View(khachHangs);
        }
        public IActionResult Create()
        {
            var thanhPhoList = _context.ThanhPhos.ToList();
            ViewBag.ThanhPhoList = new SelectList(thanhPhoList, "MaThanhPho", "TenThanhPho");
            return View();
        }

        [HttpPost]
        public IActionResult Create(KhachHang khachHang)
        {
            if (ModelState.IsValid) // Check for model validation
            {
                _context.Add(khachHang);
                _context.SaveChanges();
                TempData["successMessage"] = "Thêm mới khách hàng thành công!";
                return RedirectToAction("Create");
            }
            return View(khachHang);

        }
    }
}