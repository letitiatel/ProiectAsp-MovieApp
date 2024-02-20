﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectasp.Data;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Proiectasp.Models.DTOs;
using Proiectasp.Models;

namespace Proiectasp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly ProiectContext _proiectContext;

        public MovieController(ProiectContext proiectContext)
        {
            _proiectContext = proiectContext;
        }

        [HttpGet("movie")]
        public async Task<IActionResult> GetMovie()
        {
            return Ok(await _proiectContext.Movies.ToListAsync());
        }

        [HttpPost("movie")]
        public async Task<IActionResult> Create(MovieDTO movieDto)
        {
            var newMovie = new Movie
            {
                Id = Guid.NewGuid(),
                Name = movieDto.Name,
                Release_date = movieDto.Release_date,
                Type_of_movie = movieDto.Type_of_movie,
                Rating = movieDto.Rating

            };

            await _proiectContext.AddAsync(newMovie);
            await _proiectContext.SaveChangesAsync();

            return Ok(newMovie);
        }
    }
}
