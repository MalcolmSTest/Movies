using BLL.Data;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Web.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new DataContext(
				serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
			{
				// Look for any movies.
				if (context.Movies.Any())
				{
					return;		// DB has been seeded
				}

				var user1 = new User();
				var user2 = new User();
				var user3 = new User();
				var user4 = new User();
				var user5 = new User();
				var user6 = new User();
				context.Users.Add(user1);
				context.Users.Add(user2);
				context.Users.Add(user3);
				context.Users.Add(user4);
				context.Users.Add(user5);
				context.Users.Add(user6);

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

				var movieUserRatings1 = new MovieUserRating
				{
					Movie = movieFellowshipOfTheRing,
					User = user1,
					Rating = 5
				};
				var movieUserRatings2 = new MovieUserRating
				{
					Movie = movieFellowshipOfTheRing,
					User = user2,
					Rating = 4
				};
				var movieUserRatings3 = new MovieUserRating
				{
					Movie = movieFellowshipOfTheRing,
					User = user3,
					Rating = 3
				};
				var movieUserRatings4 = new MovieUserRating
				{
					Movie = movieFellowshipOfTheRing,
					User = user4,
					Rating = 4
				};
				var movieUserRatings5 = new MovieUserRating
				{
					Movie = movieFellowshipOfTheRing,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieFellowshipOfTheRing.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieFellowshipOfTheRing);

				var movieAnUnexpectedJourney = new Movie
				{
					Title = "The Hobbit: An Unexpected Journey",
					YearOfRelease = 2012,
					RunningTime = 169
				};

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieAnUnexpectedJourney,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieAnUnexpectedJourney,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieAnUnexpectedJourney,
					Genre = genreFantasy
				});

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieAnUnexpectedJourney,
					User = user1,
					Rating = 5
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieAnUnexpectedJourney,
					User = user2,
					Rating = 4
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieAnUnexpectedJourney,
					User = user3,
					Rating = 3
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieAnUnexpectedJourney,
					User = user4,
					Rating = 4
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieAnUnexpectedJourney,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieAnUnexpectedJourney.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieAnUnexpectedJourney);

				var movieTheTwoTowers = new Movie
				{
					Title = "The Lord of the Rings: The Two Towers",
					YearOfRelease = 2002,
					RunningTime = 179
				};

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieTheTwoTowers,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieTheTwoTowers,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieTheTwoTowers,
					Genre = genreFantasy
				});

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieTheTwoTowers,
					User = user1,
					Rating = 4
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieTheTwoTowers,
					User = user2,
					Rating = 3
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieTheTwoTowers,
					User = user3,
					Rating = 5
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieTheTwoTowers,
					User = user4,
					Rating = 3
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieTheTwoTowers,
					User = user5,
					Rating = 3
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieTheTwoTowers.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieTheTwoTowers);

				var movieMarleyAndMe = new Movie
				{
					Title = "Marley & Me",
					YearOfRelease = 2008,
					RunningTime = 115
				};

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

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieMarleyAndMe,
					User = user1,
					Rating = 5
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieMarleyAndMe,
					User = user2,
					Rating = 4
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieMarleyAndMe,
					User = user3,
					Rating = 2
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieMarleyAndMe,
					User = user4,
					Rating = 4
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieMarleyAndMe,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieMarleyAndMe.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieMarleyAndMe);

				var movieReturnOfTheKing = new Movie
				{
					Title = "The Lord of the Rings: The Return of the King",
					YearOfRelease = 2003,
					RunningTime = 201
				};

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieReturnOfTheKing,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieReturnOfTheKing,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieReturnOfTheKing,
					Genre = genreFantasy
				});

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieReturnOfTheKing,
					User = user1,
					Rating = 5
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieReturnOfTheKing,
					User = user2,
					Rating = 4
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieReturnOfTheKing,
					User = user3,
					Rating = 2
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieReturnOfTheKing,
					User = user4,
					Rating = 4
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieReturnOfTheKing,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieReturnOfTheKing.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieReturnOfTheKing);

				var movieDesolationOfSmaug = new Movie
				{
					Title = "The Hobbit: The Desolation of Smaug",
					YearOfRelease = 2013,
					RunningTime = 161
				};

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieDesolationOfSmaug,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieDesolationOfSmaug,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieDesolationOfSmaug,
					Genre = genreFantasy
				});

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieDesolationOfSmaug,
					User = user1,
					Rating = 5
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieDesolationOfSmaug,
					User = user2,
					Rating = 4
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieDesolationOfSmaug,
					User = user3,
					Rating = 2
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieDesolationOfSmaug,
					User = user4,
					Rating = 4
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieDesolationOfSmaug,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieDesolationOfSmaug.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieDesolationOfSmaug);

				var movieBattleOfTheFiveArmies = new Movie
				{
					Title = "The Hobbit: The Battle of the Five Armies",
					YearOfRelease = 2014,
					RunningTime = 144
				};

				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieBattleOfTheFiveArmies,
					Genre = genreAdventure
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieBattleOfTheFiveArmies,
					Genre = genreDrama
				});
				context.MovieGenres.Add(new MovieGenre
				{
					Movie = movieBattleOfTheFiveArmies,
					Genre = genreFantasy
				});

				movieUserRatings1 = new MovieUserRating
				{
					Movie = movieBattleOfTheFiveArmies,
					User = user1,
					Rating = 5
				};
				movieUserRatings2 = new MovieUserRating
				{
					Movie = movieBattleOfTheFiveArmies,
					User = user2,
					Rating = 4
				};
				movieUserRatings3 = new MovieUserRating
				{
					Movie = movieBattleOfTheFiveArmies,
					User = user3,
					Rating = 2
				};
				movieUserRatings4 = new MovieUserRating
				{
					Movie = movieBattleOfTheFiveArmies,
					User = user4,
					Rating = 4
				};
				movieUserRatings5 = new MovieUserRating
				{
					Movie = movieBattleOfTheFiveArmies,
					User = user5,
					Rating = 5
				};
				context.MovieUserRatings.Add(movieUserRatings1);
				context.MovieUserRatings.Add(movieUserRatings2);
				context.MovieUserRatings.Add(movieUserRatings3);
				context.MovieUserRatings.Add(movieUserRatings4);
				context.MovieUserRatings.Add(movieUserRatings5);

				movieBattleOfTheFiveArmies.AverageRating = (decimal)(movieUserRatings1.Rating + movieUserRatings2.Rating + movieUserRatings3.Rating + movieUserRatings4.Rating + movieUserRatings5.Rating) / 5M;

				context.Movies.Add(movieBattleOfTheFiveArmies);

				context.SaveChanges();
			}
		}
	}
}
