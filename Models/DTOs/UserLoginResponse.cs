namespace Proiectasp.Models.DTOs
{
    public class UserLoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public UserLoginResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Token = token;
        }
    }
}
