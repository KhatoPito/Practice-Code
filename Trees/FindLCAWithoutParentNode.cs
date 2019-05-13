using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* Problem
 * A binary tree is given and two nodes of this tree is given, we have to find out the algorithm for
 * lowest common ancestor of the two given nodes. Common ancestor are the nodes which can be reached
 * from two nodes by following the parent links. Lowest common ancestor is the common ancestor which has the highest depth. */

// * Time complexity O(n)
//* Space complexity O(h)

namespace Sample_Code
{

    /// <summary>
    ///  Lowest common ancestor problem
    /// </summary>
    class FindLCAWithoutParentNode
    {

        public class Tree
        {
            #region Create Tree
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

            public static void AddNode(Node parentNode, Node node)
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
                {
                    tempParentNode.left = node;
                }

                if (rightFlag)
                {
                    tempParentNode.right = node;
                }
            }
            #endregion Create Tree

            private Node FindLCANode(Node rootNode, Node node1, Node node2)
            {

                if (rootNode == null) return null;
                if ((rootNode.data == node1.data) || (rootNode.data == node2.data)) return rootNode;

                Node leftNode = FindLCANode(rootNode.left, node1, node2);
                Node rightNode = FindLCANode(rootNode.right, node1, node2);

                if (leftNode != null && rightNode != null)
                    return rootNode;
                else if (rightNode != null)
                    return rightNode;
                else if (leftNode != null)
                    return leftNode;       

                return null;
            }

            public static void Main(string[] args)
            {
                Tree treeObj = new Tree();

                Node nodeObj = new Node(25);
                AddNode(nodeObj, new Node(16));
                AddNode(nodeObj, new Node(20));
                AddNode(nodeObj, new Node(15));
                AddNode(nodeObj, new Node(30));
                AddNode(nodeObj, new Node(36));
                AddNode(nodeObj, new Node(22));
                AddNode(nodeObj, new Node(18));

                Node tempNode = treeObj.FindLCANode(nodeObj, new Node(30), new Node(22));
                Console.WriteLine("The LCA is : " + tempNode.data);

                Console.ReadLine();
            }
        }

     
    }

}
