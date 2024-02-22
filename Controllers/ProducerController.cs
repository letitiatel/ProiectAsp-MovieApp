using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectasp.Data;
using Proiectasp.Models.DTOs;
using Proiectasp.Models;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Proiectasp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {

        private readonly ProiectContext _proiectContext;

        public ProducerController(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        [HttpGet("producer")]
        public async Task<IActionResult> GetProducer()
        {
            return Ok(await _proiectContext.Producers.ToListAsync());
        }

        [HttpPost("producer")]
        public async Task<IActionResult> Create(ProducerDTO producerDto)
        {
            var newProducer = new Producer
            {
                Id = Guid.NewGuid(),
                FirstName = producerDto.FirstName,
                LastName = producerDto.LastName,
                Age = producerDto.Age,
                Awards = producerDto.Awards


            };

            await _proiectContext.AddAsync(newProducer);
            await _proiectContext.SaveChangesAsync();

            return Ok(newProducer);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProducerDTO producerDto)
        {
            Producer producerById = await _proiectContext.Producers.FirstOrDefaultAsync(x => x.LastName == producerDto.LastName);
            if (producerById == null)
            {
                return BadRequest("Object does not exist");
            }

            producerById.FirstName = producerDto.FirstName;
            _proiectContext.Update(producerById);
            await _proiectContext.SaveChangesAsync();

            return Ok(producerById);
        }

        [HttpDelete("producer")]
        public async Task<IActionResult> DeleteProducer(ProducerDTO producerDto)
        
        {
            Producer producerById = await _proiectContext.Producers.FirstOrDefaultAsync(x => x.LastName == producerDto.LastName);
            if (producerById == null)
            {
                return BadRequest("Object does not exist");
            }
               
            _proiectContext.Producers.Remove(producerById);
            return NoContent();
        }
    }

}
