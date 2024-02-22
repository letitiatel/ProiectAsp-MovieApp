using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectasp.Data;
using Proiectasp.Models.DTOs;
using Proiectasp.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiectasp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ProiectContext _proiectContext;

        public RoleController(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        [HttpGet("role")]
        public async Task<IActionResult> GetRole()
        {
            return Ok(await _proiectContext.Roles.ToListAsync());
        }

        [HttpPost("role")]
        public async Task<IActionResult> Create(RoleDTO roleDto)
        {
            var newRole = new Role
            {
                Id = Guid.NewGuid(),
                Idd = roleDto.Idd,
                Name = roleDto.Name

            };

            await _proiectContext.AddAsync(newRole);
            await _proiectContext.SaveChangesAsync();

            return Ok(newRole);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RoleDTO roleDto)
        {
            Role roleById = await _proiectContext.Roles.FirstOrDefaultAsync(x => x.Idd == roleDto.Idd);
            if (roleById == null)
            {
                return BadRequest("Object does not exist");
            }

            roleById.Name = roleDto.Name;
            _proiectContext.Update(roleById);
            await _proiectContext.SaveChangesAsync();

            return Ok(roleById);
        }

        [HttpDelete("role")]
        public async Task<IActionResult> DeleteRole(RoleDTO roleDto)

        {
            Role roleById = await _proiectContext.Roles.FirstOrDefaultAsync(x => x.Idd == roleDto.Idd);
            if (roleById == null)
            {
                return BadRequest("Object does not exist");
            }

            _proiectContext.Roles.Remove(roleById);
            return NoContent();
        }
    }
}
