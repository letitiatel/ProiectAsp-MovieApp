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
    public class ProducerDetailsController : ControllerBase
    {
        private readonly ProiectContext _proiectContext;

        public ProducerDetailsController(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetProducerDetails()
        {
            return Ok(await _proiectContext.ProducerDetailss.ToListAsync());
        }

        [HttpPost("details")]
        public async Task<IActionResult> Create(ProducerDetailsDTO producerdetailsDto)
        {
            var newProducerDetails = new ProducerDetails
            {
                Id = Guid.NewGuid(),
                Known_for = producerdetailsDto.Known_for,
                Born = producerdetailsDto.Born,
                Spouse = producerdetailsDto.Spouse
             
            };

            await _proiectContext.AddAsync(newProducerDetails);
            await _proiectContext.SaveChangesAsync();

            return Ok(newProducerDetails);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProducerDetailsDTO producerdetailsDto)
        {
            ProducerDetails producerdetailsById = await _proiectContext.ProducerDetailss.FirstOrDefaultAsync(x => x.Born == producerdetailsDto.Born);
            if (producerdetailsById == null)
            {
                return BadRequest("Object does not exist");
            }

            producerdetailsById.Known_for = producerdetailsDto.Known_for;
            producerdetailsById.Spouse = producerdetailsDto.Spouse;

           
            _proiectContext.Update(producerdetailsById);
            await _proiectContext.SaveChangesAsync();

            return Ok(producerdetailsById);
        }

        [HttpDelete("details")]
        public async Task<IActionResult> DeleteProducerDetails(ProducerDetailsDTO producerdetailsDto)

        {
            ProducerDetails producerdetailsById = await _proiectContext.ProducerDetailss.FirstOrDefaultAsync(x => x.Born == producerdetailsDto.Born);
            if (producerdetailsById == null)
            {
                return BadRequest("Object does not exist");
            }

            _proiectContext.ProducerDetailss.Remove(producerdetailsById);
            return NoContent();
        }
    }
}
