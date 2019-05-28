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
