using Baitapkiemtra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitapkiemtra01.Controllers
{
    public class BaiKiemtraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dangky(TaiKhoanViewModel model)
        {
            if (model.Tentaikhoan !=null)
            {
                return Content(model.Tentaikhoan);
            }
            return View();

        }

        public IActionResult Baitap2()
        {
            var SanPham = new SanPhamViewModel()
            {
                Tensp = "Qua chuoi nho nho",
                giaban = 25.000,
                anh= "",
            };

            return View(SanPham);
        }
    }
}
