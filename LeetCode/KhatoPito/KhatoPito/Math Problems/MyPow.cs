using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Math_Problems
{
    public static class MyPowClass
    {
        public static double MyPow(double x, int n)
        {

            if (n == 0)
                return 1;

            double sum = x;
            double result = 1;



            for (int i = 0; i < Math.Abs(n); i++)
            {
                result *= sum;
            }

            return n < 0 ? 1 / result : result;

        }

    }
}
