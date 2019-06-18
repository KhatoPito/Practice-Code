using System;
using System.Collections.Generic;

namespace KhatoPito.Graphs.DepthFirstSearch
{
    public class Depth_First_Search_Practice
    {
        public class Node<T>
        {
            public T data;
            public HashSet<Node<T>> neighbours;

            public Node(T data)
            {
                this.data = data;
                neighbours = new HashSet<Node<T>>();
            }

            internal void AddNeighbours(Node<T> node)
            {
                neighbours.Add(node);
            }
        }

        public class DFSGraph<T>
        {
           public HashSet<T> DepthFirstSearch(Node<T> node) 
            {
                var visited = new HashSet<T>();
                var stack = new Stack<Node<T>>();

                stack.Push(node);

                while (stack.Count > 0)
                {
                    var vertex = stack.Pop();
                    Console.Write(" - " + vertex.data);

                    foreach (var neighbour in vertex.neighbours)
                    {
                        if (!visited.Contains(neighbour.data))
                        {
                            stack.Push(neighbour);
                            visited.Add(neighbour.data);
                        }
                    }
                }

                return visited;
            }

        }

        public class Program
        {
            public static void Main()
            {
                var node1 = new Node<int>(1);
                var node2 = new Node<int>(2);
                var node3 = new Node<int>(3);
                var node4 = new Node<int>(4);
                var node5 = new Node<int>(5);
                var node6 = new Node<int>(6);
                var node7 = new Node<int>(7);

                node4.AddNeighbours(node1);
                node4.AddNeighbours(node2);
                node1.AddNeighbours(node3);
                node2.AddNeighbours(node1);
                node2.AddNeighbours(node3);
                node2.AddNeighbours(node6);
                node2.AddNeighbours(node5);
                node3.AddNeighbours(node6);
                node6.AddNeighbours(node7);
                node5.AddNeighbours(node7);

                DFSGraph<int> g = new DFSGraph<int>();
                g.DepthFirstSearch(node4);
                // o/p will be 4 2 5 7 6 3 1 

                Console.ReadLine();
            }
        }

    }
}
