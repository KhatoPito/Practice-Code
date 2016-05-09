using System;
using System.IO;

namespace Solution
{

    class Solution
    {

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

        public static void AddNode(ref Node rootNode, Node node)
        {
            if (rootNode == null || node == null)
                throw new InvalidDataException("Invalid data supplied.");

            Node currentNode = node, parentNode = rootNode;
            bool isRight = false, isLeft = false;


            while (parentNode != null)
            {
                Node tempParentNode = parentNode;
                // if parent is larger then new node, set it left child
                if (parentNode.data > node.data)
                {
                    parentNode = parentNode.left;
                    isLeft = true;
                    isRight = false;
                }
                // if parent is smaller then new node, set it as right child
                else if (parentNode.data < node.data)
                {
                    parentNode = parentNode.right;
                    isLeft = false;
                    isRight = true;
                }

                if (isLeft)
                {
                    tempParentNode.left = currentNode;
                }
                else if (isRight)
                {
                    tempParentNode.right = currentNode;
                }

                rootNode = tempParentNode;
            }
        }

        public static int FindNodeDistance(Node rootNode, int firstNodeData, int secondNodeData)
        {
            if (rootNode == null)
                return -1;

            if (firstNodeData <= 0 || secondNodeData <= 0)
                throw new InvalidDataException("Invalid data supplied.");

            int leftCount = 0, rightCount = 0;
            Node leftNodePath = rootNode, rightNodePath = rootNode;

            // this loop is to find node1 distance from common ancestor 
            while (leftNodePath != null)
            {
                if (leftNodePath.data > firstNodeData)
                {
                    leftNodePath = leftNodePath.left;
                    ++leftCount;
                }
                else if (leftNodePath.data < firstNodeData)
                {
                    leftNodePath = leftNodePath.right;
                    ++leftCount;
                }
                else
                {
                    break;
                }
            }

            // this loop is to find node2 distance from common ancestor 
            while (rightNodePath != null)
            {
                if (rightNodePath.data > secondNodeData)
                {
                    rightNodePath = rightNodePath.left;
                    rightCount++;
                }
                else if (rightNodePath.data < secondNodeData)
                {
                    rightNodePath = rightNodePath.right;
                    rightCount++;
                }
                else
                {
                    break;
                }
            }

            // total of left + right is going to be distance           
            return leftCount + rightCount;
        }

        // this recursion function will find out common ancestor among two provided node values
        public static Node FindCommonAncestor(Node rootNode, int firstNodeData, int secondNodeData)
        {
            if (rootNode == null)
                return rootNode;

            if (firstNodeData <= 0 || secondNodeData <= 0)
                throw new InvalidDataException("Invalid data supplied.");

            // if both nodes are greater than root - they are on right side
            if (rootNode.data < firstNodeData && rootNode.data < secondNodeData)
            {
                return FindCommonAncestor(rootNode.right, firstNodeData, secondNodeData);
            }
            // if both nodes are less than root - they are on left side
            else if (rootNode.data > firstNodeData && rootNode.data > secondNodeData)
            {
                return FindCommonAncestor(rootNode.left, firstNodeData, secondNodeData);
            }
            else //else we found the common ancestor
            {
                return rootNode;
            }
        }

        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */

            Node nodeObj = new Node(4);
            AddNode(ref nodeObj, new Node(2));
            AddNode(ref nodeObj, new Node(1)); // node A to find distance
            AddNode(ref nodeObj, new Node(3)); // node B to dins distance

            int node1 = 1, node2 = 3;
            // going through the code and doing a dry run with the given input

            Node commonNode = FindCommonAncestor(nodeObj, node1, node2);
            int distance = FindNodeDistance(commonNode, node1, node2);

            Console.WriteLine("Distance between two nodes -- node {0} and node {1} is {2}", node1, node2, distance);
            Console.ReadLine();
        }
    }
}