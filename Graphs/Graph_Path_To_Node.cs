using System;
using System.Collections.Generic;

namespace KhatoPito.Graphs
{
    public class GraphPractice
    {
        #region Graph 
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
        #endregion Graph 

        public List<int> BFS_Graph_Path_To_Node(Graph g, int start, int finish)
        {
            var visited = new HashSet<int>();
            var path = new Dictionary<int, int>();
            var vertex = start;

            if (!g.AdjacencyList.ContainsKey(vertex))
                return null;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                vertex = queue.Dequeue();

                if (vertex == finish)
                    break;

                foreach (var neighbor in g.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        path.Add(neighbor, vertex);
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            //If all nodes are explored and the destination node hasn't been found.
            if (vertex != finish)
                throw new Exception("No feasible path.");

            List<int> directions = new List<int> {finish};

            for (var i = finish; i != start; )
            {
                i = path[i];
                directions.Add(i);
            }
            
            directions.Reverse();

            //7-5-8-9-10
            return directions;
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
                g.AddEdge(5, 7);
                g.AddEdge(5, 8);
                g.AddEdge(5, 6);
                g.AddEdge(8, 9);
                g.AddEdge(9, 10);

                GraphPractice obj = new GraphPractice();
                obj.BFS_Graph_Path_To_Node(g,7,10);
                Console.ReadLine();
            }
        }
    }
}
