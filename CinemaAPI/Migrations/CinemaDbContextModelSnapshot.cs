﻿// <auto-generated />
using System;
using CinemaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaAPI.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaAPI.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Age", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRange")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ages");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("NameCinema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CreatedById");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Emission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateOfIssue")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Emissions");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("NameHall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("CinemaAPI.Entities.KindOfMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AddFee")
                        .HasColumnType("bit");

                    b.Property<double>("FeeAmount")
                        .HasColumnType("float");

                    b.Property<string>("Projections")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KindOfMovies");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgeId")
                        .HasColumnType("int");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int?>("EmissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PremiereDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgeId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("EmissionId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Showing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfShow")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HallId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Showings");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Users.DetailsAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DetailsAccounts");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DetailsAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailsAccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CinemaMovie", b =>
                {
                    b.Property<int>("CinemasId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CinemasId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CinemaMovie");
                });

            modelBuilder.Entity("KindOfMovieMovie", b =>
                {
                    b.Property<int>("KindOfMoviesId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("KindOfMoviesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("KindOfMovieMovie");
                });

            modelBuilder.Entity("MovieType", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("MovieType");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Cinema", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.HasOne("CinemaAPI.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("CinemaAPI.Entities.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("Adress");

                    b.Navigation("Contact");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Hall", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Cinema", null)
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Movie", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Age", "Age")
                        .WithMany("Movies")
                        .HasForeignKey("AgeId");

                    b.HasOne("CinemaAPI.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId");

                    b.HasOne("CinemaAPI.Entities.Emission", "Emission")
                        .WithMany("Movies")
                        .HasForeignKey("EmissionId");

                    b.Navigation("Age");

                    b.Navigation("Director");

                    b.Navigation("Emission");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Showing", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId");

                    b.HasOne("CinemaAPI.Entities.Hall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallId");

                    b.HasOne("CinemaAPI.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.Navigation("Cinema");

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Users.User", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Users.DetailsAccount", "DetailsAccount")
                        .WithMany()
                        .HasForeignKey("DetailsAccountId");

                    b.HasOne("CinemaAPI.Entities.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailsAccount");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CinemaMovie", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Cinema", null)
                        .WithMany()
                        .HasForeignKey("CinemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAPI.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KindOfMovieMovie", b =>
                {
                    b.HasOne("CinemaAPI.Entities.KindOfMovie", null)
                        .WithMany()
                        .HasForeignKey("KindOfMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAPI.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieType", b =>
                {
                    b.HasOne("CinemaAPI.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaAPI.Entities.Type", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaAPI.Entities.Age", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("CinemaAPI.Entities.Emission", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
