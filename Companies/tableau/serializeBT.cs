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

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));



/*
  https://leetcode.com/problems/serialize-and-deserialize-binary-tree/solution/
*/

