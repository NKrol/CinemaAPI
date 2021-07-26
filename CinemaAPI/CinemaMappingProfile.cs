using AutoMapper;
using CinemaAPI.Entities;
using CinemaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = CinemaAPI.Entities.Type;

namespace CinemaAPI
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<Showing, ShowingDto>()
                .ForMember(s => s.Tilte, m => m.MapFrom(c => c.Movie.Title))
                .ForMember(s => s.FirstNameDirector, m => m.MapFrom(c => c.Movie.Director.FirstName))
                .ForMember(s => s.LastNameDirector, m => m.MapFrom(c => c.Movie.Director.LastName))
                .ForMember(s => s.Types, m => m.MapFrom(c => c.Movie.Types.ToArray().Select(t => t.NameType)))
                .ForMember(s => s.Ages, m => m.MapFrom(c => c.Movie.Age.AgeRange))
                .ForMember(s => s.Emisson, m => m.MapFrom(c => c.Movie.Emission.StateOfIssue))
                .ForMember(s => s.Projections, m => m.MapFrom(c => c.Movie.KindOfMovies.Select(k => k.Projections)))
                .ForMember(s => s.PremiereDate, m => m.MapFrom(c => c.Movie.PremiereDate))
                .ForMember(s => s.NameCinema, m => m.MapFrom(c => c.Cinema.NameCinema))
                .ForMember(s => s.City, m => m.MapFrom(c => c.Cinema.Adress.City))
                .ForMember(s => s.Street, m => m.MapFrom(c => c.Cinema.Adress.Street))
                .ForMember(s => s.PostalCode, m => m.MapFrom(c => c.Cinema.Adress.PostalCode))
                .ForMember(s => s.Phone, m => m.MapFrom(c => c.Cinema.Contact.PhoneNumber))
                .ForMember(s => s.Email, m => m.MapFrom(c => c.Cinema.Contact.Email))
                .ForMember(s => s.NameHall, m => m.MapFrom(c => c.Cinema.Halls.Select(h => h.NameHall)))
                .ForMember(s => s.NumberOfSeats, m => m.MapFrom(c => c.Cinema.Halls.Select(h => h.NumberOfSeats)));

            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Director, s =>s.MapFrom(c => c.Director.FirstName + " " + c.Director.LastName))
                .ForMember(m => m.Types, s => s.MapFrom(c => c.Types.Select(t => t.NameType).ToList()))
                .ForMember(m => m.Age, s=> s.MapFrom(c => c.Age.AgeRange))
                .ForMember(m => m.Emission, s=> s.MapFrom(c => c.Emission.StateOfIssue))
                .ForMember(m => m.KindOfMovies, s => s.MapFrom(c => c.KindOfMovies.Select(k => k.Projections).ToList()));

            CreateMap<CreateMovieDto, Movie>()
                .ForMember(c => c.Director, s => s.MapFrom(m => new Director(){FirstName = m.DirectorFirstName, LastName = m.DirectorLastName}))
                .ForMember(c => c.KindOfMovies, s => s.MapFrom(m => new List<KindOfMovie>(){new KindOfMovie(){Projections = m.ProjectionName}}))
                .ForMember(c => c.Types, s => s.MapFrom(m => new List<Entities.Type>(){new Entities.Type(){NameType = m.Types1}}));

            CreateMap<EditMovieDto, Movie>()
                .ForMember(e => e.Age, s=> s.MapFrom(m => new Age(){AgeRange = m.Age}))
                .ForMember(e => e.Emission, s => s.MapFrom(m => new Emission(){StateOfIssue = m.Emission}));


            CreateMap<Cinema, CinemaDto>()
                .ForMember(d => d.City, s => s.MapFrom(c => c.Adress.City))
                .ForMember(d => d.Street, s => s.MapFrom(c => c.Adress.Street))
                .ForMember(d => d.Movies, s => s.MapFrom(c => c.Movies.Count))
                .ForMember(d => d.Halls, s => s.MapFrom(c => c.Halls.Count));

        }
    }
}
