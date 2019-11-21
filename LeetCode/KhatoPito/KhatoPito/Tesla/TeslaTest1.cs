using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Tesla
{
    public static class TeslaTest1
    {
        public static int[] solution(int N)
        {
            var array = new List<int>();
            return  solution(N, array);
        }

        public static int[] solution(int N, List<int> array)
        {
            if (N == 0)
            {
                return array.ToArray();
            }

            int result = N;
            var neg = 0;

            for (int i = 0; i < N; i++)
            {
                neg -=neg;


                result += i;
                array.Add(i);
                solution(result, array);
            }

            return null;
        }


        
    }
}
