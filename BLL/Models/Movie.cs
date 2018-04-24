using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public int YearOfRelease { get; set; }
		[Required]
		public int RunningTime { get; set; }
		[Column(TypeName = "decimal(3, 2)")]
		public decimal AverageRating { get; set; }

		public List<MovieGenre> MovieGenres { get; set; }
		public List<MovieUserRating> MovieUserRatings { get; set; }
	}
}
