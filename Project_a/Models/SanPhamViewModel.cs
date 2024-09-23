﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_a.Models
{
    public class SanPhamViewModel
    {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public double price { get; set; }
            public string? Description { get; set; }
            public string? ImageUrl { get; set; }
            [Required]
            public int TheLoaiId { get; set; }
            [ForeignKey("TheLoaiId")]
            public TheLoaiViewModel TheLoai { get; set; }
        
    }
}
