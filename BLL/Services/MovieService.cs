using BLL.Data;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
	public interface IMovieService
	{
		IEnumerable<Movie> Find(string title, int yearOfRelease, IEnumerable<string> genres);
		IEnumerable<Movie> GetTop(int? userId = null);
		bool SaveRating(int movieId, int userId, int rating);
	}

	public class MovieService : IMovieService
	{
		private DataContext context;

		public MovieService(DataContext context)
		{
			this.context = context;
		}

		public IEnumerable<Movie> Find(string title, int yearOfRelease, IEnumerable<string> genres)
		{
			if (string.IsNullOrEmpty(title) && yearOfRelease <= 0 && genres.Count() == 0)
			{
				return new Movie[0];
			}

			return this.context.Movies
				.Where(movie => (string.IsNullOrWhiteSpace(title) || movie.Title.Contains(title)) &&
								(yearOfRelease <= 0 || movie.YearOfRelease == yearOfRelease) &&
								(genres.Count() == 0 || movie.MovieGenres.Any(movieGenre => genres.Contains(movieGenre.Genre.Name))))
				.OrderBy(movie => movie.Title)
				.ToArray();
		}

		public IEnumerable<Movie> GetTop(int? userId = null)
		{
			if (userId.HasValue)
			{
				return this.context.MovieUserRatings
					.Where(movieUserRating => movieUserRating.UserId == userId.Value)
					.OrderBy(movieUserRating => movieUserRating.Movie.Title)
					.OrderByDescending(movieUserRating => movieUserRating.Rating)
					.Select(movieUserRating => movieUserRating.Movie)
					.Take(5)
					.ToArray();
			}

			return this.context.Movies
				.OrderBy(movie => movie.Title)
				.OrderByDescending(movie => movie.AverageRating)
				.Take(5)
				.ToArray();
		}

		public bool SaveRating(int movieId, int userId, int rating)
		{
			var user = this.context.Users.SingleOrDefault(u => u.Id == userId);

			if (user == null)
			{
				return false;
			}

			var movie = this.context.Movies.Include(m => m.MovieUserRatings).SingleOrDefault(m => m.Id == movieId);

			if (movie == null)
			{
				return false;
			}

			var movieUserRating = this.context.MovieUserRatings.SingleOrDefault(mur => mur.MovieId == movieId && mur.UserId == userId);

			if (movieUserRating == null)
			{
				// Save a new rating
				var ratingsCount = movie.MovieUserRatings.Count + 1;
				var ratingsSum = movie.MovieUserRatings.Sum(mur => mur.Rating) + rating;

				context.MovieUserRatings.Add(new MovieUserRating
				{
					Movie = movie,
					User = user,
					Rating = rating
				});

				movie.AverageRating = (decimal)ratingsSum / (decimal)ratingsCount;
			}
			else
			{
				// Update the existing rating
				movieUserRating.Rating = rating;

				var ratingsCount = movie.MovieUserRatings.Count;
				var ratingsSum = movie.MovieUserRatings.Sum(mur => mur.Rating);

				movie.AverageRating = (decimal)ratingsSum / (decimal)ratingsCount;
			}

			context.SaveChanges();

			return true;
		}
	}
}
