using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolApp
{
    class School
    {

        private string name;
        private List<Student> students = new List<Student>();

        public School(string n)
        {
            name = n;
        }

        public void addStudent(Student stud)
        {
            students.Add(stud);
        }

        public override string ToString()		
        {
			Console.Write("School: ");
            Console.WriteLine(name);

            Console.Write("Number of students: ");
            Console.WriteLine(students.Count);

            foreach (Student stud in students)
            {
                Console.WriteLine(stud);
            }

            return ""; //Gæti gert nýjann streng með öllu innihaldi í stað að skrifa i console, og skilað honum í return en fannst snyrtilegra að gera þetta svona
		}
	}
}
