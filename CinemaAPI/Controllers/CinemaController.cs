using CinemaAPI.Entities;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Models;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/cinema/movie")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaServices _cinemaServices;

        public CinemaController(ICinemaServices cinemaServices)
        {
            _cinemaServices = cinemaServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> Get()
        {
            var cinemas = _cinemaServices.GetAll();

            return Ok(cinemas);
        }
        [HttpPost]
        public ActionResult AddMovie([FromBody] CreateMovieDto dto)
        {
            _cinemaServices.AddMovie(dto);

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult EditMovie([FromRoute] int id, [FromBody] EditMovieDto dto)
        {
            _cinemaServices.EditMovie(id, dto);

            return Ok();
        }
        [HttpPut("addmovietocinema/{id}")]
        public ActionResult AddMovieToCinema([FromRoute] int id, [FromBody] MovieDto dto)
        {
            _cinemaServices.AddMovieToCinema(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _cinemaServices.Delete(id);

            return Ok();
        }

    }
}
