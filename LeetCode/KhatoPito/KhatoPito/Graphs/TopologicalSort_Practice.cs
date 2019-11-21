using System;
using System.Collections.Generic;

namespace KhatoPito.Graphs
{
    public class TopologicalSortPractice
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

            public void AddNeighbours(Node<T> node)
            {
                neighbours.Add(node);
            }
        }

        public class DFSGraph<T>
        {
            List<Node<T>> nodes;
            public DFSGraph(List<Node<T>> nodes)
            {
                this.nodes = nodes;
            }

            public void TopologicalSort()
            {
                var visited = new HashSet<T>();
                var sortStack = new Stack<Node<T>>();

                foreach(var item in nodes)
                {
                    TopologicalSortUtil(item, visited, sortStack);
                }

                while (sortStack.Count != 0)
                {
                    Console.Write(" - " + sortStack.Pop().data);
                }
            }

            public void TopologicalSortUtil(Node<T> node, HashSet<T> visited, Stack<Node<T>> sortStack) 
            {
                if (!visited.Contains(node.data))
                {
                    visited.Add(node.data);

                    var neighbours = node.neighbours;

                    foreach (var neighbor in neighbours)
                    {
                        if (!visited.Contains(neighbor.data))
                        {
                            TopologicalSortUtil(neighbor, visited, sortStack);
                        }
                    }
                    sortStack.Push(node);
                }

            }

        }

        //public class Program
        //{
        //    public static void Main()
        //    {
        //        var node0 = new Node<int>(0);
        //        var node1 = new Node<int>(1);
        //        var node2 = new Node<int>(2);
        //        var node3 = new Node<int>(3);
        //        var node4 = new Node<int>(4);
        //        var node5 = new Node<int>(5);

        //        node5.AddNeighbours(node0);
        //        node5.AddNeighbours(node2);
        //        node4.AddNeighbours(node0);
        //        node4.AddNeighbours(node1);
        //        node2.AddNeighbours(node3);
        //        node3.AddNeighbours(node1);

        //        var list = new List<Node<int>>();
        //        list.Add(node0);
        //        list.Add(node1);
        //        list.Add(node2);
        //        list.Add(node3);
        //        list.Add(node4);
        //        list.Add(node5);


        //        DFSGraph<int> g = new DFSGraph<int>(list);
        //        g.TopologicalSort();

        //        Console.ReadLine();
        //    }
        //}

    }
}
