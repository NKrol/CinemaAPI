using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using CinemaAPI.Models;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("/api/movie")]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<MovieDto>> Get()
        {
            var cinemas = _movieService.GetAll();

            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<MovieDto> GetById([FromRoute] int id)
        {
            var movie = _movieService.GetById(id);

            return Ok(movie);
        }

        [HttpPost]
        [Authorize(Roles = "Cinema manager, Admin")]
        public ActionResult AddMovie([FromBody] CreateMovieDto dto)
        {
            _movieService.AddMovie(dto);

            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Cinema manager, Admin")]
        public ActionResult EditMovie([FromRoute] int id, [FromBody] EditMovieDto dto)
        {
            _movieService.EditMovie(id, dto);

            return Ok();
        }
        //public void AddMovieToCinema(int cinemaId, int movieId)
        [HttpPut("addMovieToCinema/{movieId}/{cinemaId}")]
        [Authorize(Roles = "Cinema manager, Admin")]
        public ActionResult AddMovieToCinema([FromRoute] int cinemaId, [FromRoute] int movieId)
        {
            _movieService.AddMovieToCinema(cinemaId, movieId);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _movieService.Delete(id);

            return Ok();
        }
    }
}
