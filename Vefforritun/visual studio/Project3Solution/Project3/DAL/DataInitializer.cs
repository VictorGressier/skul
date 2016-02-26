using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3.DAL
{
	public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			var items = new List<Stuff>
			{
				new Stuff
				{
					Name = "Bottled water",
					Description = "Fine Icelandic water cleaned and bottled",
					Available = 130,
					Category = 4,
					Price = 120
				},

				new Stuff
				{
					Name = "Benq computer screen",
					Description = "One of the fines computer screens out there, 11\" and has 3D features Included",
					Available = 26,
					Category = 2,
					Price = 80000
				},

				new Stuff
				{
					Name = "Lord of the Rings Trioligy(Movie)",
					Description = "Very famous adventure movie triology about the world of middle earth",
					Available = 50,
					Category = 1,
					Price = 7000
				},

				new Stuff
				{
					Name = "Lord of the Rings Trioligy(Books)",
					Description = "Very famous adventure movie triology about the world of middle earth",
					Available = 56,
					Category = 0,
					Price = 4000
				},

				new Stuff
				{
					Name = "Murrey Lawn mover",
					Description = "One of the fines lawn mover out there, 30 hp disel motor.",
					Available = 12,
					Category = 3,
					Price = 60000
				},

				new Stuff
				{
					Name = "Buzz Lightyear Toy",
					Description = "Toy from the famous Toy story movie",
					Available = 24,
					Category = 5,
					Price = 3000
				},

				new Stuff
				{
					Name = "DC Shoes",
					Description = "DC shoes from the size 35-46",
					Available = 30,
					Category = 6,
					Price = 12000
				},

				new Stuff
				{
					Name = "Underarmor Shorts",
					Description = "Underarmor shorts from the size XS-XL",
					Available = 36,
					Category = 7,
					Price = 9000
				},

				new Stuff
				{
					Name = "Toyo tires",
					Description = "Toyo tires, nailed and unnailed",
					Available = 40,
					Category = 8,
					Price = 35000
				}
		};

			items.ForEach(s => context.Items.Add(s));
			context.SaveChanges();


			//Categories
			//0 "Books & Audible".
			//1 "Movies, Music & Games".
			//2 "Electronics & Computers".
			//3 “Home, Garden & Tools”.
			//4 “Beauty, Health & Grocery”.
			//5 “Toys, Kids & Baby”.
			//6 “Clothing, Shoes & Jewelry”.
			//7 “Sport & Outdoors”.
			//8 “Automotive & Industrial”
			//9 “All Categories”

		}
	}
}