using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_a.Data;
using Project_a.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Project_a.Controllers
{
    [Area("Customer")]
    //[Authorize(Roles = "User")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPhamViewModel> sanpham = _db.SanPham.Include(sp => sp.TheLoai).ToList();

            return View(sanpham);
        }
        public IActionResult Details(int sanphamid)
        {
            GioHangViewModel giohang = new GioHangViewModel
            {
                SanPhamId = sanphamid,
                SanPham= _db.SanPham.Include(sp => sp.TheLoai).FirstOrDefault(sp => sp.Id == sanphamid),
                Quantity = 1
            };

            return View(giohang);
        }
        [HttpPost]
        [Authorize]//yêu cầu đăng nhập ms mua được
        public IActionResult Details(GioHangViewModel giohang)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim=identity.FindFirst(ClaimTypes.NameIdentifier);
            giohang.ApplicationUserId = claim.Value;
            _db.GioHang.Add(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult FilterByTheLoai(int id)
        {
            var sanpham = _db.SanPham
                             .Include("TheLoai")  // Include để lấy thông tin thể loại
                             .Where(sp => sp.TheLoaiId == id)  // Tìm sản phẩm theo TheLoaiId
                             .ToList();

            return View("Index", sanpham); // Trả về view "Index" với danh sách sản phẩm
        }
    }
}
