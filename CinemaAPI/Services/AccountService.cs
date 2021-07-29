using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using CinemaAPI.Entities.Users;
using CinemaAPI.Exceptions;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CinemaAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _settings;

        public AccountService(CinemaDbContext dbContext, IPasswordHasher<User> hasher, AuthenticationSettings settings)
        {
            _dbContext = dbContext;
            _hasher = hasher;
            _settings = settings;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                RoleId = dto.RoleId
            };

            var hashedPassword = _hasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

        }

        public string JwtGenerate(LoginUserDto dto)
        {
            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);



            if (user is null)
            {
                throw new NotFoundException("Invalid user mail or password");
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new NotFoundException("Invalid user mail or password");
            }

            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtIssuer));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_settings.JwtExpireDay);


            var token = new JwtSecurityToken(_settings.JwtIssuer,
                _settings.JwtIssuer,
                claim,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }

    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string JwtGenerate(LoginUserDto dto);
    }
}
