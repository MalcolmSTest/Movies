using BLL.Data;
using BLL.Models;
using BLL.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BLL.Tests.Data
{
	public class MovieServiceTests
	{
		[Fact]
		public void Find_EmptyFilter_ReturnsEmpty()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_EmptyFilter_ReturnsEmpty")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring",
					YearOfRelease = 2012,
					RunningTime = 169
				});
				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("", 0, new string[0]);

				Assert.Empty(movies);
			}
		}

		[Fact]
		public void Find_TitleFilter_ReturnsEmpty()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_TitleFilter_ReturnsEmpty")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				context.Movies.Add(new Movie
				{
					Title = "The Hobbit: An Unexpected Journey",
					YearOfRelease = 2012,
					RunningTime = 169
				});
				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("Lord", 0, new string[0]);

				Assert.Empty(movies);
			}
		}

		[Fact]
		public void Find_TitleFilter_ReturnsSingle()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_TitleFilter_ReturnsSingle")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring",
					YearOfRelease = 2001,
					RunningTime = 178
				});
				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("Lord", 0, new string[0]);

				Assert.Single(movies);
				Assert.Equal("The Lord of the Rings: The Fellowship of the Ring", movies.Single().Title);
			}
		}

		[Fact]
		public void Find_TitleFilter_ReturnsTwo()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_TitleFilter_ReturnsTwo")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Two Towers",
					YearOfRelease = 2002,
					RunningTime = 179
				});
				context.Movies.Add(new Movie
				{
					Title = "The Hobbit: An Unexpected Journey",
					YearOfRelease = 2012,
					RunningTime = 169
				});
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring",
					YearOfRelease = 2001,
					RunningTime = 178
				});
				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("Lord", 0, new string[0]);

				Assert.Equal(2, movies.Count());
				Assert.Equal("The Lord of the Rings: The Fellowship of the Ring", movies.First().Title);
				Assert.Equal("The Lord of the Rings: The Two Towers", movies.ElementAt(1).Title);
			}
		}

		[Fact]
		public void Find_YearFilter_ReturnsSingle()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_YearFilter_ReturnsSingle")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring",
					YearOfRelease = 2001,
					RunningTime = 178
				});
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Two Towers",
					YearOfRelease = 2002,
					RunningTime = 179
				});
				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("", 2001, new string[0]);

				Assert.Single(movies);
				Assert.Equal("The Lord of the Rings: The Fellowship of the Ring", movies.Single().Title);
			}
		}

		[Fact]
		public void Find_GenreFilter_ReturnsSingle()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Find_GenreFilter_ReturnsSingle")
					.Options;

			// Setup the test data
			using (var context = new DataContext(options))
			{
				var genreAdventure = new Genre
				{
					Name = "Adventure"
				};
				var genreDrama = new Genre
				{
					Name = "Drama"
				};
				var genreFantasy = new Genre
				{
					Name = "Fantasy"
				};
				var genreComedy = new Genre
				{
					Name = "Comedy"
				};
				var genreFamily = new Genre
				{
					Name = "Family"
				};
				context.Genres.Add(genreAdventure);
				context.Genres.Add(genreDrama);
				context.Genres.Add(genreFantasy);
				context.Genres.Add(genreComedy);
				context.Genres.Add(genreFamily);

				var movieFellowshipOfTheRing = new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring",
					YearOfRelease = 2001,
					RunningTime = 178
				};
				context.Movies.Add(movieFellowshipOfTheRing);

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieFellowshipOfTheRing,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieFellowshipOfTheRing,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieFellowshipOfTheRing,
					Genre = genreFantasy
				});

				var movieMarleyAndMe = new Movie
				{
					Title = "Marley & Me",
					YearOfRelease = 2008,
					RunningTime = 115
				};
				context.Movies.Add(movieMarleyAndMe);

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieMarleyAndMe,
					Genre = genreComedy
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieMarleyAndMe,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieMarleyAndMe,
					Genre = genreFamily
				});

				context.SaveChanges();
			}

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				var service = new MovieService(context);
				var movies = service.Find("", 0, new string[] { "Fantasy" });

				Assert.Single(movies);
				Assert.Equal("The Lord of the Rings: The Fellowship of the Ring", movies.First().Title);
			}
		}
	}
}
