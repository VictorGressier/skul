using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolApp
{
    class Student
    {
        public string name;
        public int age { get; }

        public override string ToString()
        {
            string str = "    ";
			string spaceing = ", ";
            str += name += spaceing += age;
            return str;
        }
    }
}
