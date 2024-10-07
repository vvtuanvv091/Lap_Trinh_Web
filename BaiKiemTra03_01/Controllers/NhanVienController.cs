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

        //public IActionResult Upsert(int id)
        //{
        //    NhanVienViewModel sp = new NhanVienViewModel();

        //    // Fetch the list of PhongBan (Departments) to display in the dropdown
        //    IEnumerable<SelectListItem> dsPhongBan = _db.PhongBan.Select(
        //        item => new SelectListItem
        //        {
        //            Value = item.phongbanquanli.ToString(),
        //            Text = item.tenphongban, // Display department name
        //        }).ToList(); // Make sure to call ToList() to materialize the query

        //    ViewBag.DsPhongBan = dsPhongBan; // Make sure this matches your view

        //    if (id == 0)
        //    {
        //        // Creating a new employee
        //        return View(sp);
        //    }
        //    else
        //    {
        //        // Editing an existing employee
        //        sp = _db.NhanVien.Include("PhongBan").FirstOrDefault(s => s.manhanvien == id);
        //        return View(sp);
        //    }
        //}
        //[HttpPost]
        //public IActionResult Upsert(NhanVienViewModel sp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (sp.manhanvien == 0)
        //        {
        //            _db.NhanVien.Add(sp);
        //        }
        //        else
        //        {
        //            _db.NhanVien.Update(sp);

        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}
        [HttpGet]
        public IActionResult Upsert(int id = 0)
        {
            NhanVienViewModel sp = new NhanVienViewModel();

            // Fetch the list of PhongBan (Departments) to display in the dropdown
            IEnumerable<SelectListItem> dsPhongBan = _db.PhongBan.Select(
                item => new SelectListItem
                {
                    Value = item.maphongban.ToString(),
                    Text = item.tenphongban // Display department name
                }).ToList();

            ViewBag.DsPhongBan = dsPhongBan;

            if (id == 0)
            {
                // Creating a new employee
                return View(sp);
            }
            else
            {
                // Editing an existing employee
                sp = _db.NhanVien
                         .Include(nv => nv.phongban)
                         .Select(nv => new NhanVienViewModel
                         {
                             manhanvien = nv.manhanvien,
                             tennhanvien = nv.tennhanvien,
                             chucvu = nv.chucvu,
                             phongban = new PhongBanViewModel
                             {
                                 maphongban = nv.phongban.maphongban,
                                 tenphongban = nv.phongban.tenphongban,
                             },
                             ngaybatdaulamviec = nv.ngaybatdaulamviec
                         })
                         .FirstOrDefault(s => s.manhanvien == id);

                if (sp == null)
                {
                    return NotFound(); // Handle the case when the employee does not exist
                }

                return View(sp);
            }
        }

        [HttpPost]
        public IActionResult Upsert(NhanVienViewModel sp)
        {
            // Ensure that the list of departments is available in case of validation failure
            IEnumerable<SelectListItem> dsPhongBan = _db.PhongBan.Select(
                item => new SelectListItem
                {
                    Value = item.maphongban.ToString(),
                    Text = item.tenphongban
                }).ToList();
            ViewBag.DsPhongBan = dsPhongBan;

            if (ModelState.IsValid)
            {
                if (sp.manhanvien == 0)
                {
                    // Create a new employee entity from the view model
                    var newEmployee = new NhanVienViewModel
                    {
                        tennhanvien = sp.tennhanvien,
                        chucvu = sp.chucvu,
                        phongban = _db.PhongBan.Find(sp.phongban.maphongban), // Ensure the correct department is linked
                        ngaybatdaulamviec = sp.ngaybatdaulamviec
                    };
                    _db.NhanVien.Add(newEmployee);
                }
                else
                {
                    // Update existing employee
                    var existingEmployee = _db.NhanVien.Find(sp.manhanvien);
                    if (existingEmployee != null)
                    {
                        existingEmployee.tennhanvien = sp.tennhanvien;
                        existingEmployee.chucvu = sp.chucvu;
                        existingEmployee.phongban = _db.PhongBan.Find(sp.phongban.maphongban); // Update the department
                        existingEmployee.ngaybatdaulamviec = sp.ngaybatdaulamviec;
                        _db.NhanVien.Update(existingEmployee);
                    }
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Return the view with the original model to display validation errors
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
