using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BaiKiemTra03_01.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PhongBanViewModel>PhongBan { get; set; }
        public DbSet<NhanVienViewModel> NhanVien {  get; set; }
    }
}
