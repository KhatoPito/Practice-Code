using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* Problem
 * Given a binary tree, find the lowest common ancestor of two given nodes in the tree.
 * Each node contains a parent pointer which links to its parent.
 */

namespace Sample_Code
{
    /// <summary>
    ///  Lowest common ancestor problem.
    ///  Each node contains a parent pointer which links to its parent.
    /// </summary>
    class FindLCAWithParentNode
    {
        private int getHeight(Node node)
        {
            int height = 0;

            while (node.parent != null)
            {
                node = node.parent;
                height += 1;
            }

            return height;
        }

        private Node FindLCANodeUsingParentNode(Node node1, Node node2)
        {
            int Node1Height = 0, Node2Height = 0;

            Node1Height = getHeight(node1);
            Node2Height = getHeight(node2);


            int diff = Node1Height > Node2Height ? (Node1Height - Node2Height) : (Node2Height - Node1Height);

            if (Node1Height > Node2Height)
            {
                while (diff > 0)
                    node1 = node1.parent;
            }
            else
            {
                while (diff > 0)
                    node2 = node2.parent;
            }


            while (node1 != null && node2 != null)
            {
                if (node1 == node2)
                    return node1;

                node1 = node1.parent;
                node2 = node2.parent;
            }

            return null;
        }  
    }
}