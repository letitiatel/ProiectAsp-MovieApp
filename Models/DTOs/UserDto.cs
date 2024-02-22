namespace Proiectasp.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public int Userid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; } = default!;
        public string? Email { get; set; }
    }
}
