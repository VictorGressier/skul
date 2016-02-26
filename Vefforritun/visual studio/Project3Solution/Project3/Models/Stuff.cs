using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3.Models
{
	public class Stuff
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Available { get; set; }
		public float Price { get; set; }
		public int Category { get; set; }

		internal static void ForEach(Func<object, Stuff> p)
		{
			throw new NotImplementedException();
		}
	}
}