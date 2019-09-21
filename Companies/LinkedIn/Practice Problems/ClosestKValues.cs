using System;
using System.Collections.Generic;

namespace Sample_Code
{
    public class TreeClosestKValues
    {
        public IList<int> ClosestKValues(Node root, double target, int k)
        {
            var res = new List<int>();
            FindKValues(root, target, k, res);

            foreach (var item in res)
            {
                Console.Write(item + " - ");
            }

            return res;
        }


        public void FindKValues(Node root, double target, int k, List<int> res)
        {
            if (root == null) return;

            if (root != null)
            {
                FindKValues(root.left, target, k, res);

                if (res.Count < k)
                    res.Add(root.data);
                else
                {
                    if (Math.Abs(target - root.data) < Math.Abs(target - res[0]))
                    {
                        // Key Poin is - removing from front and when we add it goes to back 
                        // so {1,2} - when we do removeAt(0) - > {2} then we add res.Add(res.Data) -> {2,3}
                        res.RemoveAt(0);
                        res.Add(root.data);
                    }
                }

                FindKValues(root.right, target, k, res);
            }
        }

        static void Main(string[] args)
        {
            TreeClosestKValues treeObj = new TreeClosestKValues();

            Node nodeObj = new Node(4);
            nodeObj.left = new Node(2);
            nodeObj.right = new Node(5);
            nodeObj.left.left = new Node(1);
            nodeObj.left.right = new Node(3);

            treeObj.ClosestKValues(nodeObj, 3.1, 2);
            Console.ReadLine();
        }

        public class Node
        {
            internal Node left;
            internal Node right;
            internal int data;

            internal Node(int data)
            {
                this.data = data;
            }
        }

        #region AddNode
        static public void AddNode(Node parentNode, Node node)
        {
            Node currentNode = node, tempParentNode = parentNode;
            bool leftFlag = false, rightFlag = false;

            while (parentNode != null)
            {
                if (parentNode != null && parentNode.data > node.data)
                {
                    tempParentNode = parentNode;
                    parentNode = parentNode.left;
                    leftFlag = true;
                    rightFlag = false;
                }

                if (parentNode != null && parentNode.data < node.data)
                {
                    tempParentNode = parentNode;
                    parentNode = parentNode.right;
                    leftFlag = false;
                    rightFlag = true;
                }

            }

            if (leftFlag)
                tempParentNode.left = node;

            if (rightFlag)
                tempParentNode.right = node;
        }
        #endregion AddNode
    }
}
