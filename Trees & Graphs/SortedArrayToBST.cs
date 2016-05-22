using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Given an array where elements are sorted in ascending order,
 convert it to a height balanced BST.
 */
namespace SortedArrayToBST
{
    public class TreeNode
    {
        private int val;
        internal TreeNode Left;
        internal TreeNode Right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class SortedArrayToBst
    {
        public static TreeNode SortedArray(int[] array)
        {
            if(array == null || array.Length == 0)
                return null;

            return ConverSortedArrayToBst(array, 0, array.Length - 1);
        }

        public static TreeNode ConverSortedArrayToBst(int[] array, int start, int end)
        {
            if (end < start)
                return null;

            int mid = (start + end)/2;
            TreeNode rootNode = new TreeNode(array[mid]);
            rootNode.Left = ConverSortedArrayToBst(array, start, mid - 1);
            rootNode.Right = ConverSortedArrayToBst(array, mid + 1, end);

            return rootNode;
        }
    }

    class SortedArrayToBST
    {
        static void Main(string[] args)
        {
            var tree = SortedArrayToBst.SortedArray(new int []{1,2,3,4,5,6,7});
            Console.ReadLine();
        }
    }
}
