using CinemaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CinemaAPI.Authorization;
using CinemaAPI.Exceptions;
using CinemaAPI.Models;
using CinemaAPI.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Type = CinemaAPI.Entities.Type;

namespace CinemaAPI.Services
{
    public class CinemaServices : ICinemaServices
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly IAuthorizationService _authorizationService;

        public CinemaServices(CinemaDbContext dbContext, IMapper mapper, IUserContextService userContextService, IAuthorizationService authorizationService)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _authorizationService = authorizationService;
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


        public CinemaDto GetById(int id)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Movies)
                .Include(c => c.Adress)
                .Include(c => c.Halls)
                .FirstOrDefault(c => c.Id == id);

            if (cinema is null)
            {
                throw new NotFoundException("Can't find cinema with id: " + id);
            }

            var cinemaDto = _mapper.Map<CinemaDto>(cinema);

            return cinemaDto;
        }

        public void RemoveCinema(int id)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Halls)
                .FirstOrDefault(c => c.Id == id);

            if (cinema == null) throw new NotFoundException($"Can't find cinema with id: {id}");
            
            var authorizationResult =_authorizationService.AuthorizeAsync(_userContextService.User, cinema,
                new ResourceOperationRequirement(ResourceOperation.Delete));

            if (!authorizationResult.Result.Succeeded) throw new ForbidException();
            
            _dbContext.Cinemas
                .Remove(cinema);
            _dbContext.SaveChanges();
        }

        public void UpdateCinema(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Adress)
                .Include(c => c.Contact)
                .FirstOrDefault(c => c.Id == id);

            if (cinema == null) throw new NotFoundException($"Can't find cinema with id: {id}");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, cinema,
                new ResourceOperationRequirement(ResourceOperation.Update));

            if (!authorizationResult.Result.Succeeded) throw new ForbidException();

            cinema.NameCinema = cinemaDto.NameCinema ?? cinema.NameCinema;

            cinema.Adress.Street = cinemaDto.Street ?? cinema.Adress.Street;

            cinema.Contact.PhoneNumber = cinemaDto.PhoneNumber ?? cinema.Contact.PhoneNumber;

            cinema.Contact.Email = cinemaDto.Email ?? cinema.Contact.Email;

            _dbContext.SaveChanges();

        }

        public void UpdateHall(int id, int idHall, HallDto dto)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Halls)
                .FirstOrDefault(c => c.Id == id);
            if (cinema is null) throw new NotFoundException("Can't find this cinema!");
            

            var hallToEdit = cinema.Halls.FirstOrDefault(h => h.Id == idHall);

            if (hallToEdit is null) throw new NotFoundException("Can't find this hall in this Cinema!");
            

            hallToEdit.NameHall = dto.NameHall ?? hallToEdit.NameHall;
            if (dto.NumberOfSeats != 0) hallToEdit.NumberOfSeats = dto.NumberOfSeats;
            
            hallToEdit.Status = dto.Status ?? hallToEdit.Status;

            _dbContext.SaveChanges();

        }

        public int AddCinema(CreateCinemaDto dto)
        {
            var newCinema = _mapper.Map<Cinema>(dto);

            newCinema.CreatedById = _userContextService.GetId;
            _dbContext.Cinemas.Add(newCinema);
            _dbContext.SaveChanges();

            var id = newCinema.Id;

            return id;

        }

        public IEnumerable<MovieDto> GetMovieFromCinema(int cinemaId)
        {
            var movies = _dbContext.Cinemas
                .Include(c => c.Movies)
                .FirstOrDefault(c => c.Id == cinemaId)?
                .Movies
                .ToList();
            
            if (movies is null) throw new NotFoundException("Not found cinema!");
            
            return (from movie in movies
                select movie.Id
                into id
                select _dbContext.Movies.Include(m => m.Director)
                    .Include(m => m.Age)
                    .Include(m => m.KindOfMovies)
                    .Include(m => m.Types)
                    .Include(m => m.Emission)
                    .FirstOrDefault(m => m.Id == id)
                into movie1
                where movie1 is not null
                select _mapper.Map<MovieDto>(movie1)).ToList();

        }

        public IEnumerable<HallDto> GetHalls(int cinemaId)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Halls)
                .FirstOrDefault(c => c.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Cinema not found!");

            var halls = cinema.Halls.ToList();

            if (halls is null) throw new NotFoundException("Halls not found!");

            var hallsDto = _mapper.Map<List<HallDto>>(halls);

            return hallsDto;

        }

        public AdressDto GetAddress(int cinemaId)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Adress)
                .FirstOrDefault(c => c.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Cinema not found!");

            var address = cinema.Adress;

            if (address is null) throw new NotFoundException("The cinema did not add an address");

            var addressDto = _mapper.Map<AdressDto>(address);

            return addressDto;
        }

        public ContactDto GetContact(int cinemaId)
        {
            var cinema = _dbContext.Cinemas
                .Include(c => c.Contact)
                .FirstOrDefault(c => c.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Cinema not found!");

            var contact = cinema.Contact;

            var contactDto = _mapper.Map<ContactDto>(contact);

            return contactDto;
        }
    }

    public interface ICinemaServices
    {
        public IEnumerable<CinemaDto> GetAll();
        void UpdateHall(int id, int idHall, HallDto dto);
        public int AddCinema(CreateCinemaDto dto);
        public IEnumerable<MovieDto> GetMovieFromCinema(int cinemaId);

        public IEnumerable<HallDto> GetHalls(int cinemaId);

        public AdressDto GetAddress(int cinemaId);

        public ContactDto GetContact(int cinemaId);

        CinemaDto GetById(int id);
        void RemoveCinema(int id);
        void UpdateCinema(int id, UpdateCinemaDto cinemaDto);
    }
}
