using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Graphs
{
    public class GraphPractice
    {
        public class Graph
        {
            public int Vertices;
            public Dictionary<int, HashSet<int>> AdjacencyList = new Dictionary<int, HashSet<int>>();
            public Graph(int vertices)
            {
                this.Vertices = vertices;
                for(int i = 1; i <= vertices; i++)
                    AdjacencyList.Add(i, new HashSet<int>());
            }

            public void AddEdge(int source, int target)
            {
                if (AdjacencyList.ContainsKey(source) && AdjacencyList.ContainsKey(target))
                {
                    AdjacencyList[source].Add(target);
                    AdjacencyList[target].Add(source);
                }
            }
        }

        public HashSet<int> BreadthFirstSearch(Graph g, int start)
        {
            var visited = new HashSet<int>();
            if (!g.AdjacencyList.ContainsKey(start))
                return visited;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if(visited.Contains(vertex))
                    continue;

                visited.Add(vertex);
                foreach (var neighbor in g.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
            // this will contain all the visited nodes 
            return visited;
        }

        public class Program
        {
            public static void Main()
            {
                Graph g = new Graph(10);
                g.AddEdge(1, 2);
                g.AddEdge(1, 3);
                g.AddEdge(2, 4);
                g.AddEdge(3, 5);
                g.AddEdge(3, 6);
                g.AddEdge(4, 7);
                g.AddEdge(5, 5);

                GraphPractice obj = new GraphPractice();
                obj.BreadthFirstSearch(g, 1);
                Console.ReadLine();
            }
        }
    }
}
