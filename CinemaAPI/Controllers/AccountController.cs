using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using CinemaAPI.Entities.Users;
using CinemaAPI.Models;
using CinemaAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CinemaAPI.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IAccountService _service;

        public AccountController(CinemaDbContext dbContext, IPasswordHasher<User> hasher, IAccountService service)
        {
            _dbContext = dbContext;
            _hasher = hasher;
            _service = service;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginUserDto dto)
        {
            var token = _service.JwtGenerate(dto);

            return Ok(token);
        }

    }
}
