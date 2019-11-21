using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.AirBnbTest
{
    // https://github.com/allaboutjst/airbnb/blob/master/src/main/java/ten_wizards/TenWizards.java
    public class AirBnbTest
    {
        public class Wizard : IComparable<Wizard>
        {
            internal  int id;
            internal int dist;

            public Wizard(int id)
            {
                this.id = id;
                this.dist = int.MaxValue;
            }

            public int CompareTo(Wizard other)
            {
                return this.dist - other.dist;
            }
        }

        public List<int> getShortestPath(List<string> wizards)
        {
            int source = 0;
            int target = 10;

            var  intWizards = new List<List<int>>();

            foreach (var wizard in wizards)
            {
                List<int> entries = new List<int>();
                var strs = wizard.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                intWizards.Add(strs.Select(int.Parse).ToList());

            }


            // List<List<int>> wizards
            int n = intWizards.Count;
            int[] parents = new int[intWizards.Count];
            Dictionary<int, Wizard> map = new Dictionary<int, Wizard>();


            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
                map.Add(i, new Wizard(i));
            }

            map[source].dist = 0;
            Queue<Wizard> queue = new Queue<Wizard>();
            queue.Enqueue(map[source]);

            while (queue.Count > 0)
            {
                Wizard curr = queue.Dequeue();
                List<int> neighbors = intWizards[curr.id];
                foreach (var neighbor in neighbors)
                {
                    Wizard next = map[neighbor];
                    int weight = (int)Math.Pow(next.id - curr.id, 2);
                    if (curr.dist + weight < next.dist)
                    {
                        parents[next.id] = curr.id;
                        next.dist = curr.dist + weight;
                    }
                    queue.Enqueue(next);
                }
            }


           var res = new List<int>();
            int t = target;
            while (t != source)
            {
                res.Add(t);
                t = parents[t];
            }
            res.Add(source);

            res.Reverse();

            return res;
        }
    }
}
