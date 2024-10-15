using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_a.Data;
using Project_a.Models;
using System.Security.Claims;

namespace Project_a.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<GioHangViewModel>dsgiohang=_db.GioHang.Include("SanPham").
                Where(gh=>gh.ApplicationUserId==claim.Value).ToList();
            return View(dsgiohang);
        }
    }
}
