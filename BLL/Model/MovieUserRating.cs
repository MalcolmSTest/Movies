using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Model
{
	public class MovieUserRating
	{
		public int MovieId { get; set; }
		public Movie Movie { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		[Required]
		public int Rating { get; set; }
	}
}
