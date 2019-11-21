//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using KhatoPito.ArrayPractice;
//using KhatoPito.StringPractice;
//using static Sample_GraphPracticeDFSBFS.SamplePractice_DFS_BFS;

//namespace KhatoPito
//{
//    public class Solution
//    {

//        public static void Main()
//        {
//            //LongestPalindromicSubstring sol = new LongestPalindromicSubstring();
//            //Console.WriteLine(sol.FindMedianSortedArrays(new int[] { -5, 3, 6, 12, 15 }, new int[] { -12, -10, -6, -3, 4, 10 }));

//            //Solution43 solution = new Solution43();
//            //Console.WriteLine(solution.Multiply("9133", "0"));
//            //Console.ReadLine();

//            //Console.WriteLine(StringPatternMatch.strmatch("hello Crr", "hell?"));

//            //Console.WriteLine(BestTimeToBuyAndSellStock.MaxProfit(new int[ ] {}));
//            //Console.WriteLine(BestTimeToBuyAndSellStock.MaxProduct(new int[] { -2, 3, -4 }));
//            //Console.WriteLine(FindThreeSum.ThreeSum(new int[] { }));
//            //Console.WriteLine(MinimumWindowSubstring.MinWindow("ADOBECODEBANC", "ABC"));
//            //Console.WriteLine(IsPalindrome.CheckPalindrome("A man, a plan, a canal: Panama"));
//            //Console.WriteLine(LongestUniqueSubString.FindLongestUniqueSubString("aab"));
//            //Console.WriteLine(StringCharacterReplacement.CharacterReplacement("ABAB",1));
//            //Console.WriteLine(Anagrams.CheckIfStringsAnagrams("Bharat", "Barhat"));
//            //Console.WriteLine(Anagrams.GroupAnagrams(new string[]{"eat", "tea", "tan", "ate", "nat", "bat"}));
//            //Console.WriteLine(ValidParentheses.IsValid("{}[()]"));
//            //Console.WriteLine(PalindromicSubstrings.PalindromesWithExpand("aaa"));
//            //Console.WriteLine(LongestPalindromicSubstring.LongestPalindromeSubstring("forgeeksskeegfor"));
//            //Console.WriteLine(MatchPattern.Match("ab1c".ToCharArray(), "ab'\'d''c".ToCharArray()));
//            //Console.WriteLine(MatchPattern.Match("ab1c".ToCharArray(), "ab'\'d''c".ToCharArray()));
//             //Console.ReadLine();


//            GraphPractice_DFS_BFS treeObj = new GraphPractice_DFS_BFS();

//            #region Create Tree
//            GraphPractice_DFS_BFS.Node nodeObj = new GraphPractice_DFS_BFS.Node(25);
//            GraphPractice_DFS_BFS.AddNode(nodeObj, new GraphPractice_DFS_BFS.Node(16));
//            GraphPractice_DFS_BFS.AddNode(nodeObj, new GraphPractice_DFS_BFS.Node(20));
//            GraphPractice_DFS_BFS.AddNode(nodeObj, new GraphPractice_DFS_BFS.Node(15));
//            GraphPractice_DFS_BFS.AddNode(nodeObj, new GraphPractice_DFS_BFS.Node(36));
//            GraphPractice_DFS_BFS.AddNode(nodeObj, new GraphPractice_DFS_BFS.Node(30));
//            #endregion Create Tree

//            GraphPractice_DFS_BFS.BFS_Traverse(nodeObj);
//            Console.WriteLine("");
//            GraphPractice_DFS_BFS.DFS_Traverse(nodeObj);


//            Console.ReadLine();

//        }

//    }


//}
