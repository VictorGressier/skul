using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryApp
{
	class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CategoryID { get; set; }
		public decimal Price { get; set; }

		public override string ToString( )
		{
			return Name;
		}
	}

	class Category
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}

	class Program
	{
		public static IEnumerable<int> GetNumbers( )
		{
			int[] arrNumbers = { 10, 7, 4, 8, 3, 2, 11, 27, 55, 12, 10, 23};
			return arrNumbers;
		}

		public static IEnumerable<Product> GetProducts( )
		{
			List<Product> products = new List<Product>( );
			products.Add( new Product { Name = "Milk",           Price = 90,  CategoryID = 4, ID = 1 } );
			products.Add( new Product { Name = "Cheese",         Price = 130, CategoryID = 4, ID = 2 } );
			products.Add( new Product { Name = "Butter",         Price = 110, CategoryID = 4, ID = 3 } );

			products.Add( new Product { Name = "Apple juice",    Price = 230, CategoryID = 1, ID = 4 } );
			products.Add( new Product { Name = "Grape juice",    Price = 240, CategoryID = 1, ID = 5 } );
			products.Add( new Product { Name = "Beetroot juice", Price = 300, CategoryID = 1, ID = 6 } );
			products.Add( new Product { Name = "Carrot juice",   Price = 190, CategoryID = 1, ID = 7 } );
			products.Add( new Product { Name = "Ginger ale",     Price = 990, CategoryID = 1, ID = 8 } );

			products.Add( new Product { Name = "Oregano",        Price = 500, CategoryID = 2, ID = 9 } );
			products.Add( new Product { Name = "Salt",           Price = 550, CategoryID = 2, ID = 10 } );
			products.Add( new Product { Name = "Pepper",         Price = 490, CategoryID = 2, ID = 11 } );

			products.Add( new Product { Name = "Carrots",        Price = 300, CategoryID = 3, ID = 12 } );
			products.Add( new Product { Name = "Spinach",        Price = 250, CategoryID = 3, ID = 13 } );
			products.Add( new Product { Name = "Onion",          Price = 200, CategoryID = 3, ID = 14 } );
			products.Add( new Product { Name = "Garlic",         Price = 150, CategoryID = 3, ID = 15 } );
			products.Add( new Product { Name = "Tomatoes",       Price = 100, CategoryID = 3, ID = 16 } );

			return products;
		}

		public static IEnumerable<Category> GetCategories( )
		{
			List<Category> categories = new List<Category>( );

			categories.Add( new Category { ID = 1, Name = "Beverages" } );
			categories.Add( new Category { ID = 2, Name = "Condiments" } );
			categories.Add( new Category { ID = 3, Name = "Vegetables" } );
			categories.Add( new Category { ID = 4, Name = "Dairy products" } );

			return categories;
		}

		static void Main( string[] args )
		{

			// a)
			var result1 = (from num in GetNumbers()
						  orderby num ascending 
						  select num).FirstOrDefault();
			Console.WriteLine(result1);

			// b)
			var result2 = from num in GetNumbers()
						   where num%2 != 0
						   select num;
			Console.WriteLine(result2.Average());

			// c)
			var result3 = (from item in GetProducts()
						  orderby item.Price ascending
						  select item).FirstOrDefault();
			Console.WriteLine(result3);

			// d)
			var result4 = (from item in GetProducts()
						   where item.Price <= 120
						   orderby item.Price descending
						   select item).FirstOrDefault();
			Console.WriteLine(result4);

			// e)
			var result5 = (from item in GetProducts()
	//					   where item.Name[0] == 'G'
	//					   orderby item.Name ascending
						   join cat in GetCategories() 
						   on item equals  into 
						   select item);

			foreach (var item in result5)
			{
				Console.Write(item + ", ");
			}			


			Console.ReadKey();
		}
	}
}
