using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
  Implement a basic calculator to evaluate a simple expression string.

  The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.

  Example 1:

  Input: "3+2*2"
  Output: 7
  Example 2:

  Input: " 3/2 "
  Output: 1
  Example 3:

  Input: " 3+5 / 2 "
  Output: 5
  Note:

  You may assume that the given expression is always valid.
  Do not use the eval built-in library function.
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

            char op = '+';
            int num = 0;

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
                        case '+':
                            stack.Push(num);
                            break;

                        case '-':
                            stack.Push(-num);
                            break;

                        case '/':
                            stack.Push(stack.Pop() / num);
                            break;

                        case '*':
                            stack.Push(stack.Pop() * num);
                            break;

                    }

                    op = c;
                    num = 0;
                }
            }

            int total = 0;
            while (stack.Count != 0)
            {
                total += stack.Pop();
            }


            return total;
        }
    }
}
