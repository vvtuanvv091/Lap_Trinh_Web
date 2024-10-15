using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_a.Models
{
    public class GioHangViewModel
    {
        [Key]
        public int Id { get; set; }
        public int SanPhamId {  get; set; }
        [ForeignKey("SanPhamId")]
        [ValidateNever]
        public SanPhamViewModel SanPham { get; set; }
        public int Quantity {  get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
