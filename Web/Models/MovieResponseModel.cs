using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
	public class MovieResponseModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int YearOfRelease { get; set; }
		public int RunningTime{ get; set; }
		public decimal AverageRating { get; set; }
	}
}
