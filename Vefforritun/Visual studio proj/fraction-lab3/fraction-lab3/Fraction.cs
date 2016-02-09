using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fraction_lab3
{
    class Fraction
    {
        public int Numerator;
        public int Denominator;

        public Fraction()
        {
        }

        public Fraction(string fraction)
        {
            // Ensure the format is correct (i.e. "numerator/denominator":
            int nSlashPos = fraction.IndexOf("/");
            if (nSlashPos == -1)
            {
				throw new ArgumentException();
            }
            Numerator = Convert.ToInt32(fraction.Substring(0, nSlashPos));
            Denominator = Convert.ToInt32(fraction.Substring(nSlashPos + 1));
            Normalize();
        }
        public void Normalize()
        {
            int a1 = 0;
            int b1 = 0;
            int a2 = 0;
            int f = 0;
            a1 = Numerator;
            b1 = Denominator;
            while (true)
            {
                if ((a2 = a1 % b1) == 0)
                {
                    f = b1;
                    break;
                }
                if ((b1 = b1 % a1) == 0)
                {
                    f = a1;
                    break;
                }
                a1 = a2;
            }
            Numerator /= f;
            Denominator /= f;
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }

        //Overloading operators in next lines
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.Numerator = (a.Numerator * b.Denominator)
            + (a.Denominator * b.Numerator);
            result.Denominator = a.Denominator * b.Denominator;
            result.Normalize();
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            if (a.Numerator > b.Denominator)
            {
                result.Numerator = (a.Numerator * b.Denominator) - (a.Denominator * b.Numerator);
                result.Denominator = a.Denominator * b.Denominator;
            }
            else
            {
                result.Numerator = (a.Denominator * b.Numerator) - (a.Numerator * b.Denominator);
                result.Denominator = a.Denominator * b.Denominator;
            }
            result.Normalize();
            return result;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.Numerator = (a.Numerator * b.Numerator);
            result.Denominator = a.Denominator * b.Denominator;
            result.Normalize();
            return result;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.Numerator = a.Numerator * b.Denominator;
            result.Denominator = a.Denominator * b.Numerator;
            result.Normalize();
            return result;
        }

    }
}
