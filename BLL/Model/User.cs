using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Model
{
	public class User
	{
		public int Id { get; set; }


		public List<MovieUserRating> MovieUserRatings { get; set; }
	}
}
