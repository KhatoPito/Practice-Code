using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfLeftAndRightSubtree
{
 /*
   In a binary tree change each node's value(except leaf node) as the sum of left and right subtree's value.
            Constructed binary tree is:
                    1
                 /      \
                2        3
              /  \        \
             4   5        8
                        /    \
                       6       7
    
   After sum stored is in each node, binary tree is:
                   35
                 /    \
                9     21
              /  \       \
             4   5       13
                        /   \
                       6     7 
   */

    class SumOfLeftAndRightSubtree
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

        /// <summary>
        ///    Convert a given tree to a tree where every node contains sum of values of
        ///     nodes in left and right sub trees in the original tree
        /// </summary>
        int SumLeftRightLeafNode(Node root)
        {
            // Base case
            if (root == null)
                return 0;

            // Store the old value
            int old_node_value = root.data;

            // Recursively call for left and right subtrees and store the sum as
            // new value of this node
            int sum = SumLeftRightLeafNode(root.left) + SumLeftRightLeafNode(root.right);

            // Return the sum of values of nodes in left and right subtrees and
            // old_value of this node
            return old_node_value + sum;
        }
    }

}