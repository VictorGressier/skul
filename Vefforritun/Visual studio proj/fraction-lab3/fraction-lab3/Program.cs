using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = string.Empty;
            string fractionA = string.Empty;
            string fractionB = string.Empty;
            do
            {
                Console.WriteLine("Enter +, -, * or / (q to quit)");
                action = Console.ReadLine();
                if (!(action == "q" || action == "Q"))
                {
                    Console.WriteLine("Enter the first fraction (example: 1/2):");
                    fractionA = Console.ReadLine();
                    Console.WriteLine("Enter the second fraction (example: 5/9):");
                    fractionB = Console.ReadLine();
                    Fraction A = new Fraction(fractionA);
                    Fraction B = new Fraction(fractionB);
                    Fraction result = new Fraction();
                    switch (action)
                    {
                        case "+":
                            result = A + B;
                            break;
                        case "-":
                            result = A - B;
                            break;
                        case "*":
                            result = A * B;
                            break;
                        case "/":
                            result = A / B;
                            break;
                    }
                    Console.WriteLine("The result is: " + result);
                }
            }
            while (!(action == "q" || action == "Q"));
        }
    }
}
