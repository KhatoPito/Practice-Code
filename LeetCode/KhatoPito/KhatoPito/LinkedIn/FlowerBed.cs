using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.LinkedIn
{
    public  class FlowerBedTest
    {
        public void FlowerBed()
        {
            int[] flowerbed = new int[] { 0, 0, 1, 0, 0 };
            int n = 1;
            int i = 0, count = 0;

            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    --n;
                }

                i++;
            }
        }


    }
}
