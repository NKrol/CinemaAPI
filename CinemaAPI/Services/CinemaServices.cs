using CinemaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public IEnumerable<MovieDto> GetAll()
        {
            var showings = _dbContext.Movies
                .Include(m => m.Director)
                .Include(m => m.Types)
                .Include(m => m.Age)
                .Include(m => m.Emission)
                .Include(m => m.KindOfMovies);


            var showingDtos = _mapper.Map<List<MovieDto>>(showings);

            return showingDtos;
        }

        public void AddMovie(CreateMovieDto dto)
        {
            var newMovie = _mapper.Map<Movie>(dto);

            var director = _dbContext.Directors.FirstOrDefault(d => d.FirstName.Equals(dto.DirectorFirstName) & d.LastName.Equals(dto.DirectorLastName));
            var type = _dbContext.Types.FirstOrDefault(t => t.NameType.Equals(dto.Types1));
            var kindOfMovie = _dbContext.KindOfMovies.FirstOrDefault(e => e.Projections.Equals(dto.ProjectionName));

            newMovie.Director = director ?? newMovie.Director;
            newMovie.Types = new List<Type>() {type} ?? newMovie.Types;
            newMovie.KindOfMovies = new List<KindOfMovie>() {kindOfMovie} ?? newMovie.KindOfMovies;

            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();

        }

        public void EditMovie(int id, EditMovieDto dto)
        {
            var movieToEdit = _dbContext
                .Movies
                .Include(m => m.Age)
                .Include(m => m.Emission)
                .FirstOrDefault(m => m.Id == id);
            if (movieToEdit is null)
            {
                throw new NotFoundException("Can't found that movie!");
            }
            
            if (movieToEdit != null)
            {
                var age = _dbContext.Ages.FirstOrDefault(a => a.AgeRange.Equals(dto.Age));
                movieToEdit.Title = dto.Title ?? movieToEdit.Title;
                movieToEdit.Age = age ?? new Age() {AgeRange = dto.Age};

                var emission = _dbContext.Emissions.FirstOrDefault(e => e.StateOfIssue.Equals(dto.Emission));
                movieToEdit.Emission = emission ?? new Emission() {StateOfIssue = dto.Emission};
            }

            _dbContext.SaveChanges();


        }
    }

    public interface ICinemaServices
    {
        public IEnumerable<MovieDto> GetAll();
        public void AddMovie(CreateMovieDto dto);
        void EditMovie(int id, EditMovieDto dto);
    }
}
