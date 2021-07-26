using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaAPI.Entities;
using CinemaAPI.Exceptions;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Type = System.Type;

namespace CinemaAPI.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAll();
        void AddMovie(CreateMovieDto dto);
        void EditMovie(int id, EditMovieDto dto);
        void AddMovieToCinema(int id, MovieDto dto);
        void Delete(int id);
    }

    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(CinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            newMovie.Types = new List<Entities.Type>() { type } ?? newMovie.Types;
            newMovie.KindOfMovies = new List<KindOfMovie>() { kindOfMovie } ?? newMovie.KindOfMovies;

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
                movieToEdit.Age = age ?? new Age() { AgeRange = dto.Age };

                var emission = _dbContext.Emissions.FirstOrDefault(e => e.StateOfIssue.Equals(dto.Emission));
                movieToEdit.Emission = emission ?? new Emission() { StateOfIssue = dto.Emission };
            }

            _dbContext.SaveChanges();


        }

        public void AddMovieToCinema(int id, MovieDto dto)
        {
            var cinema = _dbContext.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema is null)
            {
                throw new NotFoundException("Can't find this cinema!");
            }

            var film = _dbContext.Movies.FirstOrDefault(f => f.Id == dto.Id);
            if (film is null)
            {
                throw new NotFoundException("Not found this film");
            }

            if (cinema.Movies is null)
            {
                cinema.Movies = new List<Movie>() { film };
            }
            else
            {
                cinema.Movies.Add(film);
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (movie is null) throw new NotFoundException("Movie not found!");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();


        }
    }
}
