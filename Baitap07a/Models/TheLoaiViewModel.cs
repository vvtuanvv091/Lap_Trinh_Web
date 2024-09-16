using System.ComponentModel.DataAnnotations;

namespace Baitap07a.Models
{
    public class TheLoaiViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
