using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class CinemaDbContext : DbContext
    {
        private readonly string _connectionString =
            "Data Source=192.168.239.129,1433;Database=CinemaNewDb;User ID=emergency;Password=Bercik1267@";

        

        public DbSet<KindOfMovie> KindOfMovies { get; set; }
        public DbSet<Emission> Emissions { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Age> Ages { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Showing> Showings { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KindOfMovie>()
                .Property(kom => kom.Projections)
                .IsRequired();

            modelBuilder.Entity<Emission>()
                .Property(e => e.StateOfIssue)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Director>()
                .Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Director>()
                .Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Type>()
                .Property(t => t.NameType)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
