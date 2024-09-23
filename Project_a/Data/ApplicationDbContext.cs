using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_a.Models;

namespace Project_a.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TheLoaiViewModel>TheLoai { get; set; }
        public DbSet<SanPhamViewModel>SanPham { get; set; }
    }
}
