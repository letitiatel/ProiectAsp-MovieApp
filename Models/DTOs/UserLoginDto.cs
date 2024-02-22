using System.ComponentModel.DataAnnotations;

namespace Proiectasp.Models.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
