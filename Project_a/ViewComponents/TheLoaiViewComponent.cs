using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_a.Data;
using Project_a.Models;
namespace Project_a.ViewComponents
{
    public class TheLoaiViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        // Sử dụng InvokeAsync để trả về Task<IViewComponentResult>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var theloai = await _db.TheLoai.ToListAsync(); // Sử dụng truy vấn async
            return View(theloai); // Trả về view với danh sách thể loại
        }
        

    }
}
