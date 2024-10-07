using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_01.Models
{
    public class PhongBanViewModel
    {
        [Key]
        public  int maphongban {get; set;}
        [Required(ErrorMessage = "Tên phòng ban là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên phòng ban không được vượt quá 100 ký tự.")]
        public string  tenphongban {get; set;}
        public int soluongnhanvien { get; set;}
        public int phongbanquanli { get; set;}
    }
}
