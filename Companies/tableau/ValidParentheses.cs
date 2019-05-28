/*
  Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

  An input string is valid if:

  Open brackets must be closed by the same type of brackets.
  Open brackets must be closed in the correct order.
  Note that an empty string is also considered valid.

  Example 1:

  Input: "()"
  Output: true
  Example 2:

  Input: "()[]{}"
  Output: true
  Example 3:

  Input: "(]"
  Output: false
  Example 4:

  Input: "([)]"
  Output: false
  Example 5:

  Input: "{[]}"
  Output: true

*/

public class Solution {
  private  Dictionary<char, char> mappings;

       public bool IsValid(string s)
        {
            mappings = new Dictionary<char, char> {{')', '('}, {'}', '{'}, {']', '['}};
            char[] brackets = s.ToCharArray();
            Stack<char> stack = new Stack<char>();

            if (!string.IsNullOrEmpty(s))
            {
                if (brackets.Length % 2 != 0)
                    return false;

                for (int i = 0; i < brackets.Length; i++)
                {
                    char ch = brackets[i];

                    if (mappings.ContainsKey(ch))
                    {
                        char topElement = stack.Count != 0 ? stack.Pop() : '#';

                        if (topElement != mappings[ch])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        stack.Push(ch);

                    }           
                }
            }

            return stack.Count == 0;
        }
}
