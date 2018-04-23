using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Model
{
	public class Genre
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public List<MovieGenre> MovieGenres { get; set; }
	}
}
