using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            School sch = new School("HR");
            sch.addStudent(new Student { name = "Nonni", age = 22 });
            sch.addStudent(new Student { name = "Sigga", age = 23 });
            Console.WriteLine(sch);
			Console.ReadKey();
        }

    }
}
