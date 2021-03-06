/*
  Calculate the value of the expression from a given string "1 + 2 * 7 - 9"  

*/

namespace KhatoPito.StringPractice
{
    public static class StringCalculator
    {
        public static int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            Stack<int> stack = new Stack<int>();
            char[] chars = s.ToCharArray();

            char op = '+'; int num = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if (char.IsDigit(c))
                {
                    num = num * 10 + c - '0';
                    if(i != chars.Length - 1)
                        continue;
                }

                if (!char.IsDigit(c) && c != ' ' || i == chars.Length -1 )
                {
                    switch (op)
                    {
                        case '+': stack.Push(num); break;
                        case '-': stack.Push(-num); break;
                        case '/': stack.Push(stack.Pop() / num); break;
                        case '*': stack.Push(stack.Pop() * num); break;
                    }
                    op = c;
                    num = 0;
                }
            }

            int total = 0;
            while (stack.Count != 0)
                total += stack.Pop();

            return total;
        }
    }
}
