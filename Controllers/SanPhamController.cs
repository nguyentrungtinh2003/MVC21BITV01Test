using Microsoft.AspNetCore.Mvc;
using MVC21BITV01Test.Data;
using MVC21BITV01Test.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace MVC21BITV01Test.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly QlbanHangContext _context;

        public SanPhamController(QlbanHangContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.SanPhams != null ? _context.SanPhams.ToList() :

             new List<SanPham>();

            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SanPham model, IFormFile HinhAnh)
        {
            if (HinhAnh != null)
            {
                //upload và cập nhật field Logo
                model.Hinh = Tools.UploadImageToFolder(HinhAnh, "SanPham");
            }
            _context.Add(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Sản phẩm đã được thêm thành công!";
            return RedirectToAction("Create");
        }
    }
}   
