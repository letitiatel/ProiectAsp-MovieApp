using Proiectasp.Data.Enums;
using Proiectasp.Models;
using Proiectasp.Models.DTOs;

namespace Proiectasp.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        //object? GetById(Guid value);
        UserDto GetUserByUsername(string lastname);

        Task<UserLoginResponse> Login(UserLoginDto user);
        User GetById(Guid id);

        Task<bool> Register(UserRegisterDto userRegisterDto, Role1 userRole1);
        Task<bool> Register(UserRegisterDto userRegisterDto, object admin);
    }
}
