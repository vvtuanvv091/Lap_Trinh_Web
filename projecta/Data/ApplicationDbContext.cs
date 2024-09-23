using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projecta.Models;

namespace projecta.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TheLoaiViewModel> TheLoai { get; set; }
        public DbSet<SanPham>Sanphams{ get; set; }
    }
}
