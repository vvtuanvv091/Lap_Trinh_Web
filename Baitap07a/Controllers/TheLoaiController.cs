using Baitap07a.Data;
using Baitap07a.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitap07a.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Create() { 
               return View();
        }
        [HttpPost]
        public IActionResult Create(TheLoaiViewModel theloai)
        {
            _db.TheLoai.Add(theloai);
            _db.SaveChanges();
            return View();
        }
        public IActionResult Index()
        {
            var theloai =_db.TheLoai.ToList();
            ViewBag.TheLoai =theloai;
            return View();
        }

    }
}
