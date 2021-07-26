using CinemaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CinemaAPI.Exceptions;
using CinemaAPI.Models;
using Type = CinemaAPI.Entities.Type;

namespace CinemaAPI.Services
{
    public class CinemaServices : ICinemaServices
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CinemaServices(CinemaDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public IEnumerable<CinemaDto> GetAll()
        {
            var cinemas = _dbContext.Cinemas
                .Include(c => c.Movies)
                .Include(c => c.Adress)
                .Include(c => c.Halls)
                .ToList();

            var cinemasMap = _mapper.Map<List<CinemaDto>>(cinemas);

            return cinemasMap;


        }
        
    }

    public interface ICinemaServices
    {
        public IEnumerable <CinemaDto> GetAll();


    }
}
