using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_01.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhongBanController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var pb = _db.PhongBan.ToList();
            ViewBag.PhongBann = pb;
            return View();
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhongBanViewModel pb)
        {
            if (ModelState.IsValid)
            {
                _db.PhongBan.Add(pb);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.PhongBan.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(PhongBanViewModel pb)
        {
            if (ModelState.IsValid)
            {
                _db.PhongBan.Update(pb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Deleted(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pb = _db.PhongBan.Find(id);
            if (pb == null)
            {
                return NotFound();
            }

            return View(pb);
        }

        // POST: DeletedConfirm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletedConfirm(int id)
        {
            var pb = _db.PhongBan.Find(id);
            if (pb == null)
            {
                return NotFound();
            }

            _db.PhongBan.Remove(pb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pb = _db.PhongBan.Find(id);
            return View(pb);
        }

    }
}
