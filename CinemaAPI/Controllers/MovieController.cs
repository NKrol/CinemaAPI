using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using CinemaAPI.Models;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("/api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMovieService _movieService;

        public MovieController(CinemaDbContext dbContext, IMovieService movieService)
        {
            _dbContext = dbContext;
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> Get()
        {
            var cinemas = _movieService.GetAll();

            return Ok(cinemas);
        }
        [HttpPost]
        public ActionResult AddMovie([FromBody] CreateMovieDto dto)
        {
            _movieService.AddMovie(dto);

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult EditMovie([FromRoute] int id, [FromBody] EditMovieDto dto)
        {
            _movieService.EditMovie(id, dto);

            return Ok();
        }
        [HttpPut("addmovietocinema/{id}")]
        public ActionResult AddMovieToCinema([FromRoute] int id, [FromBody] MovieDto dto)
        {
            _movieService.AddMovieToCinema(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _movieService.Delete(id);

            return Ok();
        }
    }
}
