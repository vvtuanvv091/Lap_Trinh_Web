using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Project_a.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address {get; set; }
    }
}
