using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_01.Models
{
    public class NhanVienViewModel
    {
        [Key]
        public int manhanvien { get; set; }
        [Required]
        public string tennhanvien { get; set; }
        public string chucvu {  get; set; }
        public int phongbanid { get; set; }
        public DateTime ngaybatdaulamviec { get; set; } = DateTime.Now;
        [ForeignKey("phongbanid")]
        public PhongBanViewModel phongban {get; set; }
    }
}
