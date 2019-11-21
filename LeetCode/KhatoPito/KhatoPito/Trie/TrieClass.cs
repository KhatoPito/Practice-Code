﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Heap
{

    public class TrieNode
    {
        internal char c;
        internal bool IsLeaf;
        internal Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();

        public TrieNode()
        {
        }

        public TrieNode(char c)
        {
            this.c = c;
        }
    }

    public class WordDictionary
    {

        private readonly TrieNode _root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {

            var children = _root.Children;
            TrieNode t;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (children.ContainsKey(c))
                {
                    t = children[c];
                }
                else
                {
                    t = new TrieNode(c);
                    children.Add(c, t);
                }

                children = t.Children;

                if (i == word.Length - 1)
                    t.IsLeaf = true;
            }


        }


        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {

            if (string.IsNullOrEmpty(word))
                return false;

            return SearchNode(word, 0, _root);
        }

        public bool SearchNode(string word, int index, TrieNode root)
        {

            TrieNode t = null;
            var children = root.Children;
            if (index == word.Length)
            {
                if (root.IsLeaf)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            char c = word[index];

            if (c == '.')
            {
                foreach (var item in root.Children)
                {
                    if (SearchNode(word, index + 1, root.Children[item.Key]))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                if (children.ContainsKey(c))
                {
                    t = children[c];
                    return SearchNode(word, index + 1, t);
                }
                else
                {
                    return false;
                }
            }

        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     *
        WordDictionary obj = new WordDictionary();
        obj.AddWord("bat");
        obj.AddWord("at");
        obj.AddWord("an");
        obj.AddWord("add");
        obj.AddWord("and");

//bool param_2 = obj.Search("a.d");
bool param_2 = obj.Search("a.d");
Console.WriteLine(param_2);
Console.ReadLine();
     */
}
