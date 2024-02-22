using AutoMapper;
using Proiectasp.Data.Enums;
using Proiectasp.Helpers.JwtUtils;
using Proiectasp.Models;
using Proiectasp.Models.DTOs;
using Proiectasp.Repositories.UserRepository;
//using BCryptNet = BCrypt.Net.BCrypt;

namespace Proiectasp.Services.UserService
{
    public class UserService : IUserService
    {
       // public IUserRepository _userRepository;
        public IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;

        public object BCryptNet { get; private set; }

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        
        public async Task<List<UserDto>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public object? GetById(Guid value)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByUsername(string lastname)
        {
            var user = _userRepository.FindByUsername(lastname);


            return _mapper.Map<UserDto>(user);
        }

        public Task<UserLoginResponse> Login(UserLoginDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(UserRegisterDto userRegisterDto, Role1 userRole1)
        {
            throw new NotImplementedException();
        }

        User IUserService.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(UserRegisterDto userRegisterDto, object admin)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginResponse> Login(UserLoginDto userDto)
        {
            var user = await _userRepository.FindByUsername(userDto.Email);

            if (user == null || !BCryptNet.Verify(userDto.Password, user.Password))
            {
                return null; // or throw exception
            }
            if (user == null) return null;

            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserLoginResponse(user, token);
        }

        public async Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole)
        {
            var userToCreate = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                Role = userRole,
                Password = BCryptNet.HashPassword(userRegisterDto.Password)
            };

            _userRepository.Create(userToCreate);
            return await _userRepository.SaveAsync();
        }
    }
}
