using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_01.Controllers
{
    public class NhanVienController : Controller
    {
        public readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<NhanVienViewModel> nhanViens = _db.NhanVien.Include(nv => nv.phongban).ToList();
            return View(nhanViens);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            NhanVienViewModel sp = new NhanVienViewModel();
            IEnumerable<SelectListItem> dstheloai = _db.PhongBan.Select(
                item => new SelectListItem
                {
                    Value = item.maphongban.ToString(),
                    Text = item.tenphongban,
                });
            ViewBag.DsTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sp);
            }
            else
            {
                sp = _db.NhanVien.Include(nv => nv.phongban).FirstOrDefault(s => s.manhanvien == id);
                return View(sp);
            }

        }
        [HttpPost]
        public IActionResult Upsert(NhanVienViewModel sp)
        {
            if (ModelState.IsValid)
            {
                if (sp.manhanvien == 0)
                {
                    _db.NhanVien.Add(sp);
                }
                else
                {
                    _db.NhanVien.Update(sp);

                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(sp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.NhanVien.FirstOrDefault(s => s.manhanvien == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.NhanVien.Remove(sanpham);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var sanpham = _db.NhanVien.FirstOrDefault(s => s.manhanvien == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.NhanVien.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });

        }
        [HttpGet]
        public IActionResult detai(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var sanpham = _db.NhanVien.Find(id);
            return View(sanpham);
        }


    }
}
