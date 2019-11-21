using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Codility
{
    public class NextPositiveNumber
    {
        public int firstMissingPositive(int[] A)
        {
            int n = A.Length;
            if (n == 0)
                return 1;
            int k = partition(A) + 1;
            int temp = 0;
            int first_missing_Index = k;
            for (int i = 0; i < k; i++)
            {
                temp = Math.Abs(A[i]);
                if (temp <= k)
                    A[temp - 1] = (A[temp - 1] < 0) ? A[temp - 1] : -A[temp - 1];
            }
            for (int i = 0; i < k; i++)
            {
                if (A[i] > 0)
                {
                    first_missing_Index = i;
                    break;
                }
            }
            return first_missing_Index + 1;
        }

        public int partition(int[] A)
        {
            int n = A.Length;
            int q = -1;
            for (int i = 0; i < n; i++)
            {
                if (A[i] > 0)
                {
                    q++;
                    swap(A, q, i);
                }
            }
            return q;
        }

        public void swap(int[] A, int i, int j)
        {
            if (i != j)
            {
                A[i] ^= A[j];
                A[j] ^= A[i];
                A[i] ^= A[j];
            }
        }
    }
}
