using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MovieGenre>()
				.HasKey(movieGenre => new { movieGenre.MovieId, movieGenre.GenreId });

			modelBuilder.Entity<MovieGenre>()
				.HasOne(movieGenre => movieGenre.Movie)
				.WithMany(movie => movie.MovieGenres)
				.HasForeignKey(movieGenre => movieGenre.MovieId);

			modelBuilder.Entity<MovieGenre>()
				.HasOne(movieGenre => movieGenre.Genre)
				.WithMany(genre => genre.MovieGenres)
				.HasForeignKey(movieGenre => movieGenre.GenreId);

			modelBuilder.Entity<MovieUserRating>()
				.HasKey(movieUserRating => new { movieUserRating.MovieId, movieUserRating.UserId });

			modelBuilder.Entity<MovieUserRating>()
				.HasOne(movieUserRating => movieUserRating.Movie)
				.WithMany(movie => movie.MovieUserRatings)
				.HasForeignKey(movieUserRating => movieUserRating.MovieId);

			modelBuilder.Entity<MovieUserRating>()
				.HasOne(movieUserRating => movieUserRating.User)
				.WithMany(user => user.MovieUserRatings)
				.HasForeignKey(movieUserRating => movieUserRating.UserId);
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<MovieGenre> MovieGenres { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<MovieUserRating> MovieUserRatings { get; set; }
	}
}
