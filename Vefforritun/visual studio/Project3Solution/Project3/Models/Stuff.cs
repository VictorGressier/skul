﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project3.Models
{
	public class Stuff
	{
		public int ID { get; set; }

		public string Name { get; set; }
		[Required(ErrorMessage = "Name is required!")]

		public string Description { get; set; }

		public int Available { get; set; }

		public double Price { get; set; }

		public int Category { get; set; }

		internal static void ForEach(Func<object, Stuff> p)
		{
			throw new NotImplementedException();
		}
	}
}