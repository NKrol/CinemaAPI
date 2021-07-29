using CinemaAPI.Entities;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaServices _cinemaServices;

        public CinemaController(ICinemaServices cinemaServices, IUserContextService userContextService)
        {
            _cinemaServices = cinemaServices;
        }

        //--------------------------------------------HttpGet--------------------------------------------\\
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CinemaDto>> Get()
        {
            var cinemas = _cinemaServices.GetAll();

            return Ok(cinemas);
        }
        [HttpGet("{id}")]
        public ActionResult<CinemaDto> GetById([FromRoute] int id)
        {
            var cinema = _cinemaServices.GetById(id);

            return Ok(cinema);
        }

        [Authorize]
        [HttpGet("{cinemaId}/movies/")]
        public ActionResult<IEnumerable<MovieDto>> GetMovieFromCinema([FromRoute] int cinemaId)
        {
            var movies = _cinemaServices.GetMovieFromCinema(cinemaId);


            return Ok(movies);

        }
        [Authorize(Roles = "Cinema manager")]
        [HttpGet("{cinemaId}/halls")]
        public ActionResult<IEnumerable<HallDto>> GetHalls([FromRoute] int cinemaId)
        {
            var halls = _cinemaServices.GetHalls(cinemaId);
            return Ok(halls);
        }
        [Authorize]
        [HttpGet("{cinemaId}/address")]
        public ActionResult<AdressDto> GetAddress([FromRoute] int cinemaId)
        {
            var address = _cinemaServices.GetAddress(cinemaId);

            return Ok(address);
        }
        [Authorize]
        [HttpGet("{cinemaId}/contact")]
        public ActionResult<ContactDto> GetContact([FromRoute] int cinemaId)
        {
            var address = _cinemaServices.GetContact(cinemaId);

            return Ok(address);
        }

        //--------------------------------------------HttpPut--------------------------------------------\\
        [Authorize(Roles = "Cinema manager")]
        [HttpPut("{id}/halls/{idHall}")] // Update a hall identyfication from cinema id
        public ActionResult UpdateHall([FromRoute] int id, [FromRoute] int idHall, [FromBody] HallDto dto)
        {
            _cinemaServices.UpdateHall(id, idHall, dto);

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCinema([FromRoute] int id, [FromBody] UpdateCinemaDto dto)
        {
            _cinemaServices.UpdateCinema(id, dto);

            return Ok();
        }
        //--------------------------------------------HttpPost--------------------------------------------\\

        [HttpPost]//Add a cinema to database
        [Authorize(Roles = "Cinema manager,Admin")]
        public ActionResult AddCinema([FromBody] CreateCinemaDto dto)
        {
            var id = _cinemaServices.AddCinema(dto);

            return Created($"/api/cinema/{id}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Cinema manager,Admin")]
        public ActionResult RemoveCinema([FromRoute] int id)
        {
            _cinemaServices.RemoveCinema(id);

            return Ok();
        }
    }
}
