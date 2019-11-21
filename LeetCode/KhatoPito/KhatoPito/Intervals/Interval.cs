using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Intervals
{
    public static class IntervalSolution
    {
        //public class Interval
        //{

        //   internal int start;
        //   internal int end;
        //    public Interval(int start, int end)
        //    {
        //        this.start = start;
        //        this.end = end;
        //    }

        //}

        public static bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length < 2)
                return false;

            var result = intervals.AsEnumerable().OrderBy(a => a[0]).ToList();


            for (int i = 1; i < intervals.Length - 1; i++)
            {
                var start = result[i-1][0];
                var next = result[1][i];
                if (start < next) return false;
            }

            return true;

        }
    }
}
