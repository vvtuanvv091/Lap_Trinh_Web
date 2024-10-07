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
        [HttpGet]
        public IActionResult Index()
        {
             IEnumerable<NhanVienViewModel> Nhanvien = _db.NhanVien
            .Include(nv => nv.phongban) // Dùng lambda expression thay vì chuỗi
            .Select(nv => new NhanVienViewModel
            {
                manhanvien = nv.manhanvien,
                tennhanvien = nv.tennhanvien,
                chucvu = nv.chucvu,
                phongban = new PhongBanViewModel
                {
                    maphongban = nv.phongban.maphongban, // Chuyển đổi sang ViewModel
                    tenphongban = nv.phongban.tenphongban,
                },
                ngaybatdaulamviec = nv.ngaybatdaulamviec
            })
            .ToList();

                    return View(Nhanvien);

        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            NhanVienViewModel sp = new NhanVienViewModel();
            IEnumerable<SelectListItem> dstheloai = _db.NhanVien.Select(
                item => new SelectListItem
                {
                    Value = item.manhanvien.ToString(),
                    Text = item.tennhanvien,
                });
            ViewBag.DsTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sp);
            }
            else
            {
                sp = _db.NhanVien.Include("PhongBan").FirstOrDefault(s => s.manhanvien == id);
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
            return View();
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
