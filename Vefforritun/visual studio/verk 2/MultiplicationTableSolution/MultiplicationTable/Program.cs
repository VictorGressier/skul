using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
	class Program
	{
		static void Main(string[] args)
		{
			int choice = Convert.ToInt32(args[0]);

			Console.WriteLine("<DOCTYPE html>");
			Console.WriteLine("<html>");
			Console.WriteLine("\t<head>");
			Console.WriteLine("\t\t<title>Multiplication Table</title>");
			Console.WriteLine("\t</head>");
			Console.WriteLine("\t<body>");
			Console.WriteLine("\t\t<h1>Multiplication Table</h1>");
			Console.WriteLine("\t\t<table>");
			Console.Write("\t\t\t<caption style=\"white-space:nowrap;\">Multiplication table for number: ");
			Console.Write(choice);
			Console.WriteLine("</caption>");
			for(int i = 1; i<11; i++)
			{
				Console.WriteLine("\t\t\t<tr>");
				Console.Write("\t\t\t\t<td>");
				Console.Write(i);
				Console.WriteLine("</td>");
				Console.Write("\t\t\t\t<td>");
				Console.Write(i*choice);
				Console.WriteLine("</td>");
				Console.WriteLine("\t\t\t</tr>");
			}
			Console.WriteLine("\t\t</table>");
			Console.WriteLine("\t</body>");


			Console.WriteLine("</html>");
			Console.ReadKey();
		}
	}
}
