using Baitap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngay05";
            ViewBag.Thang = "Thang08";
            ViewData["Nam"] = "Nam2004";
            return View();
        }
        public IActionResult Index2()
        {
            var TheLoai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "Tong Ngoc Tuan"

            };
            return View(TheLoai);
        }
    }
}
