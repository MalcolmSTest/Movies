using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
	[Produces("application/json")]
	[Route("api/Movies/[action]")]
	public class MoviesController : Controller
	{
		private readonly IMovieService movieService;

		public MoviesController(IMovieService movieService)
		{
			this.movieService = movieService;
		}

		// GET api/Movies/Find
		[HttpGet]
		[ActionName("Find")]
		public IActionResult Find(string title, int yearOfRelease, string genres)
		{
			// Validate input
			IEnumerable<string> genresArray = string.IsNullOrWhiteSpace(genres) ? new string[0] : genres.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(genre => genre.Trim());

			if (string.IsNullOrEmpty(title) && yearOfRelease <= 0 && genresArray.Count() == 0)
			{
				// Return 400 if no criteria given or criteria invalid
				return BadRequest();
			}

			var movies = this.movieService.Find(title, yearOfRelease, genresArray);

			if (!movies.Any())
			{
				return NotFound();
			}

			//TODO: Create a binder to do this
			var responseModel = movies.Select(@model => new MovieResponseModel
			{
				Id = @model.Id,
				Title = @model.Title,
				YearOfRelease = @model.YearOfRelease,
				RunningTime = @model.RunningTime,
				AverageRating = Math.Round(@model.AverageRating * 2) / 2
			});

			return Ok(responseModel);
		}

		// GET api/Movies/Top
		[HttpGet]
		[ActionName("Top")]
		public IActionResult Top(int? id)
		{
			// Validate input
			if (id.HasValue && id.Value <= 0)
			{
				// Return 400 if criteria invalid
				return BadRequest();
			}

			var movies = this.movieService.GetTop(id);

			if (!movies.Any())
			{
				return NotFound();
			}

			//TODO: Create a binder to do this
			var responseModel = movies.Select(@model => new MovieResponseModel
			{
				Id = @model.Id,
				Title = @model.Title,
				YearOfRelease = @model.YearOfRelease,
				RunningTime = @model.RunningTime,
				AverageRating = Math.Round(@model.AverageRating * 2) / 2
			});

			return Ok(responseModel);
		}

		// POST api/Movies/Rate
		[HttpPost]
		[ActionName("Rate")]
		public IActionResult Rate([FromForm]int movieId, [FromForm]int userId, [FromForm]int rating)
		{
			// Validate input
			if (movieId <= 0 || userId <= 0 || rating < 1 || rating > 5)
			{
				// Return 400 if criteria invalid
				return BadRequest();
			}

			bool success = this.movieService.SaveRating(movieId, userId, rating);

			if (success == false)
			{
				return NotFound();
			}

			return Ok();
		}
	}
}