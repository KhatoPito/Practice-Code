
using System;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//Implement Trie (Prefix Tree) (C# solution)

/*
 * A trie node should contains the character, its children and the flag that marks if it is a leaf node. 
 * You can use this diagram to walk though the Java solution.
 * 
 * 
 For reference please refer the link:
 http://www.programcreek.com/2014/05/leetcode-implement-trie-prefix-tree-java/
     */

namespace Trie_Implementation
{
    public class TriNode
    {
        internal char Character;
        internal Dictionary<char, TriNode> Children = new Dictionary<char, TriNode>();
        internal bool IsLeaf;

        public TriNode()
        {
            
        }

        public TriNode(char c)
        {
            Character = c;
        }
    }

    public class Tri
    {
        private readonly TriNode _root;

        public Tri()
        {
            _root = new TriNode();
        }

        // Inserts a word into the trie.
        public void InsertWord(string word)
        {
            var children = _root.Children;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                TriNode t;

                if (children.ContainsKey(c))
                    t = children[c];
                else
                {
                    t = new TriNode(c);
                    children.Add(c,t);
                }

                children = t.Children;

                if (i == word.Length - 1)
                      t.IsLeaf = true;
            }
        }

        // Returns if the word is in the trie.
        public bool SearchWord(string word)
        {
            Dictionary<char, TriNode> children = _root.Children;
            TriNode triNode = null;

            foreach (var c in word)
            {
                if (children.ContainsKey(c))
                {
                    triNode = children[c];
                    children = triNode.Children;
                }
                else
                {
                    triNode = null;
                    break;
                }
            }

            return triNode != null && triNode.IsLeaf;
        }
    }

    public class TriProgram
    {
        static void Main(string[] args)
        {
            Tri tri = new Tri();
            tri.InsertWord("Hello");
            tri.InsertWord("Bet");
            tri.InsertWord("Bell");
            tri.InsertWord("Ant");
            var result = tri.SearchWord("California");

            Console.ReadLine();
        }
    }
}
