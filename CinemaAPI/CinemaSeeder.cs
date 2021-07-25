using CinemaAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI
{
    public class CinemaSeeder
    {
        private CinemaDbContext _context;

        public CinemaSeeder(CinemaDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Ages.Any())
                {
                    var ages = new List<Age>()
                    {
                        new Age()
                        {
                            AgeRange = "13+"
                        }
                    };
                    _context.Ages.AddRange(ages);
                    _context.SaveChanges();
                }
                if (!_context.KindOfMovies.Any())
                {
                    var kindofMovies = new List<KindOfMovie>()
                    {
                        new KindOfMovie()
                        {
                            Projections = "2D",
                            AddFee = false,
                            FeeAmount = 1.0
                        },
                        new KindOfMovie()
                        {
                            Projections = "3D",
                            AddFee = true,
                            FeeAmount = 1.2
                        }
                    };
                    _context.KindOfMovies.AddRange(kindofMovies);
                    _context.SaveChanges();
                }
                if (!_context.Types.Any())
                {
                    var types = new List<Entities.Type>()
                    {
                        new Entities.Type()
                        {
                            NameType = "Akcja"
                        },
                        new Entities.Type()
                        {
                            NameType = "Komedia"
                        }
                    };
                    _context.Types.AddRange(types);
                    _context.SaveChanges();
                }
                if (!_context.Emissions.Any())
                {
                    var emision = new Emission()
                    {
                        StateOfIssue = "Emitowany"
                    };
                    _context.Emissions.Add(emision);
                    _context.SaveChanges();
                }
                if (!_context.Movies.Any())
                {
                    var movies = GetMovies();
                    _context.Movies.AddRange(movies);
                    _context.SaveChanges();
                }
            }

        }

        private IEnumerable<Movie> GetMovies()
        {
            var types1 = _context.Types.FirstOrDefault(t => t.Id == 1);
            var types2 = _context.Types.FirstOrDefault(t => t.Id == 2);
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "BODYGUARD I ŻONA ZAWODOWCA",
                    Director = new Director()
                    {
                        FirstName = "Patrick",
                        LastName = "Hughes"
                    },
                    Types = new List<Entities.Type>(){
                        types1,types2 
                    },
                    Age = _context.Ages.FirstOrDefault(a => a.Id == 1),
                    Emission = _context.Emissions.FirstOrDefault(a => a.Id == 1),
                    KindOfMovies = new List<KindOfMovie>()
                    {
                        _context.KindOfMovies.FirstOrDefault(t => t.Id == 1)
                    },
                    PremiereDate = DateTime.Parse("2021-08-20 12:10:00")
                },
                new Movie()
                {
                    Title = "CRUELLA",
                    Director = new Director()
                    {
                        FirstName = "Craig",
                        LastName = "Gillespie"
                    },
                    Types = new List<Entities.Type>(){
                        types2
                    },
                    Age = _context.Ages.FirstOrDefault(a => a.Id == 1),
                    Emission = _context.Emissions.FirstOrDefault(a => a.Id == 1),
                    KindOfMovies = new List<KindOfMovie>()
                    {
                        _context.KindOfMovies.FirstOrDefault(t => t.Id == 1)
                    },
                    PremiereDate = DateTime.Parse("2021-08-21 12:10:00")
                }
            };
            return movies;
        }
    }
}
