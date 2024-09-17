﻿using Baitap07a.Data;
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
            if (ModelState.IsValid)
            {
                _db.TheLoai.Add(theloai);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Index()
        {
            var theloai =_db.TheLoai.ToList();
            ViewBag.TheLoai =theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            if(id==0)
            {
                return NotFound();
            }    
            var theloai= _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult Edit(TheLoaiViewModel theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeletedConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if(theloai == null)
            {
                return NotFound();
            }    
            _db.TheLoai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
