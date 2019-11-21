using System.Collections.Generic;

namespace KhatoPito.Tree
{
    public class TreeSerialize
    {
        #region TreeNode Class
        public class TreeNode
        {
            internal TreeNode left;
            internal TreeNode right;
            internal int val;

            internal TreeNode(int val)
            {
                this.val = val;
            }
        }
        #endregion TreeNode Class

        #region AddNode
        public static void AddNode(TreeNode parentNode, TreeNode node)
        {
            TreeNode currentNode = node, tempParentNode = parentNode;
            bool leftFlag = false, rightFlag = false;

            while (parentNode != null)
            {
                if (parentNode != null && parentNode.val > node.val)
                {
                    tempParentNode = parentNode;
                    parentNode = parentNode.left;
                    leftFlag = true;
                    rightFlag = false;
                }

                if (parentNode != null && parentNode.val < node.val)
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
        #endregion AddNode

        public static string serialize(TreeNode root)
        {
            return reserialize(root, string.Empty).Trim(',');
        }

        public static string reserialize(TreeNode root, string tree)
        {
            if (root == null)
                tree += "#,";
            else
            {
                tree += root.val + ",";
                tree = reserialize(root.left, tree);
                tree = reserialize(root.right, tree);
            }

            return tree;
        }

        public static TreeNode Deserialize(string tree)
        {
            string[] treeArray = tree.Split(',');
            List<string> list = new List<string>(treeArray);
            int pos = 0;
            return Redeserialize(list, ref pos);
        }

        public static TreeNode Redeserialize(List<string> nodes, ref int pos)
        {
            if (nodes[pos++] == "#")
                return null;

            var root = new TreeNode(int.Parse(nodes[pos++]));
            root.left = Redeserialize(nodes, ref pos);
            root.right = Redeserialize(nodes, ref pos);

            return root;
        }
    }
}