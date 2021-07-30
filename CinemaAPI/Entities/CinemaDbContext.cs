using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CinemaAPI.Entities.Users;

namespace CinemaAPI.Entities
{
    public class CinemaDbContext : DbContext
    {

        private readonly string _connectionString;

        

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
        public DbSet<Role> Roles { get; set; }
        public DbSet<DetailsAccount> DetailsAccounts { get; set; }
        public DbSet<User> Users { get; set; }


        public CinemaDbContext(Connection connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

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

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            
                

            


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
