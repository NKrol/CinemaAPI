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
    [Route("api/cinema")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaServices _cinemaServices;

        public CinemaController(ICinemaServices cinemaServices)
        {
            _cinemaServices = cinemaServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CinemaDto>> Get()
        {
            var cinemas = _cinemaServices.GetAll();

            return Ok(cinemas);
        }

    }
}
