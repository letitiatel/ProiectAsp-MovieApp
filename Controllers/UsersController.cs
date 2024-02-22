using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectasp.Data;
using Proiectasp.Models.DTOs;
using Proiectasp.Models;
using Microsoft.EntityFrameworkCore;
using Proiectasp.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Proiectasp.Data.Enums;
using EnumsNET;

namespace Proiectasp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProiectContext _proiectContext;

        public UsersController(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _proiectContext.Users.ToListAsync());
        }

        [HttpPost("user")]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Userid= userDto.Userid,
                Email = userDto.Email,
                Password = userDto.Password


            };

            await _proiectContext.AddAsync(newUser);
            await _proiectContext.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            User userById = await _proiectContext.Users.FirstOrDefaultAsync(x => x.Userid == userDto.Userid);
            if (userById == null)
            {
                return BadRequest("Object does not exist");
            }

            userById.FirstName = userDto.FirstName;
            userById.LastName = userDto.LastName;
            _proiectContext.Update(userById);
            await _proiectContext.SaveChangesAsync();

            return Ok(userById);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUser(UserDto userDto)

        {
            User userById = await _proiectContext.Users.FirstOrDefaultAsync(x => x.Userid== userDto.Userid);
            if (userById == null)
            {
                return BadRequest("Object does not exist");
            }

            _proiectContext.Users.Remove(userById);
            return NoContent();
        }

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserByUserName([FromBody] string lastname)
        {
            return Ok(_userService.GetUserByUsername(lastname));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Test(UserLoginDto userLoginDto)
        {
            return Ok("Users");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await _userService.Login(userLoginDto);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Data.Enums.Role1.User);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto,Data.Enums.Role1.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok(new { Message = "Account is logged in" });
        }


        [Authorize(Role1.User)]
        [HttpGet("check-auth-user")]
        public IActionResult GetTextUser()
        {
            return Ok(new { Message = "User is logged in" });
        }

        [Authorize(Role1.Admin)]
        [HttpGet("check-auth-admin")]
        public IActionResult GetTextAdmin()
        {
            return Ok(new { Message = "Admin is logged in" });
        }

        [Authorize(Role1.Admin, Role1.User)]
        [HttpGet("check-auth-admin-and-user")]
        public IActionResult GetTextAdminUser()
        {
            return Ok(new { Message = "Account is user or admin" });
        }



    }
}
