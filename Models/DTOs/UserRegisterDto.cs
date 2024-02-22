using System.ComponentModel.DataAnnotations;

namespace Proiectasp.Models.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Userid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
