using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public void AddMovieToCinema(int cinemaId, int movieId);
        void Delete(int id);
        public MovieDto GetById(int id);
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
            newMovie.Types = type is null ? new List<Entities.Type>(){new Entities.Type(){NameType = dto.Types1}} : new List<Entities.Type>(){type};
            
            newMovie.KindOfMovies = kindOfMovie is null ? new List<KindOfMovie>() { new KindOfMovie(){Projections = dto.ProjectionName}} : new List<KindOfMovie>(){kindOfMovie};

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

        public void AddMovieToCinema(int cinemaId, int movieId)
        {
            var cinema = _dbContext.Cinemas.FirstOrDefault(c => c.Id == cinemaId);
            if (cinema is null)
            {
                throw new NotFoundException("Can't find this cinema!");
            }

            var film = _dbContext.Movies.FirstOrDefault(f => f.Id == movieId);
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

        public MovieDto GetById(int id)
        {
            var movie = _dbContext.Movies
                .Include(m => m.Age)
                .Include(m => m.Director)
                .Include(m => m.Emission)
                .Include(m => m.KindOfMovies)
                .Include(m => m.Types)
                .FirstOrDefault(m => m.Id == id);
            if (movie is null) throw new NotFoundException("Movie not found!");

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
