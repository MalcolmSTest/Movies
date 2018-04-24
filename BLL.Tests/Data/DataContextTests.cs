using BLL.Data;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BLL.Tests.Data
{
	public class DataContextTests
	{
		[Fact]
		public void Add_writes_to_database()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
					.UseInMemoryDatabase(databaseName: "Add_writes_to_database")
					.Options;

			// Run the test against one instance of the context
			using (var context = new DataContext(options))
			{
				//var service = new BlogService(context);
				//service.Add("The Lord of the Rings: The Fellowship of the Ring");
				context.Movies.Add(new Movie
				{
					Title = "The Lord of the Rings: The Fellowship of the Ring"
				});
				context.SaveChanges();
			}

			// Use a separate instance of the context to verify correct data was saved to database
			using (var context = new DataContext(options))
			{
				Assert.Equal(1, context.Movies.Count());
				Assert.Equal("The Lord of the Rings: The Fellowship of the Ring", context.Movies.Single().Title);
			}
		}
	}
}
