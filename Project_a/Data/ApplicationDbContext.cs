using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Project_a.Models;

namespace Project_a.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        public DbSet<TheLoaiViewModel>TheLoai { get; set; }
        public DbSet<SanPhamViewModel>SanPham { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
