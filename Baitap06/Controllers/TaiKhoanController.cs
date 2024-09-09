using Baitap06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap06.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dangnhap(TaiKhoanViewModel taikhoan)
        {
            /* if (model != null) {
                model.password = model.password+"_Chuoi ma hoa";
            }*/
            return View(taikhoan);
        }
       
    }
}
