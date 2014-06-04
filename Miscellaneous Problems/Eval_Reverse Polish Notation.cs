using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, /. Each operand may be an integer or another expression.

Some examples:
  ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
  ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
*/

namespace evalRPN
{
	class evalRPN
	{
		static void Main(String[] args)
		{
			string[] tokens = new string[] {"44","13","5","/","+"};
			Console.WriteLine("The result is: " + EvalRPN(tokens));
			Console.ReadLine();
		}

		public static int EvalRPN(string[] tokens)
		{
			Stack<int> rpnStack = new Stack<int>();
			string[] rpnTokens = tokens;
			int num1, num2, value;

			for(int i = 0 ; i < rpnTokens.Length; i ++)
			{
				if(rpnTokens[i] == "*" || rpnTokens[i] == "+" || rpnTokens[i] == "-" || rpnTokens[i] == "/")
				{
					switch(rpnTokens[i])
					{
						case "*":
									 num1 =  rpnStack.Pop();
									 num2 = 	rpnStack.Pop();
									rpnStack.Push(num2*num1);
									break;
								
						case "-":    num1 =  rpnStack.Pop();
									 num2 = 	rpnStack.Pop();
									rpnStack.Push(num2-num1);
									break;		
					
						case "+":	num1 =  rpnStack.Pop();
									 num2 = 	rpnStack.Pop();
									rpnStack.Push(num2+num1);
									break;
			
						case "/": 	 num1 =  rpnStack.Pop();
									 num2 = rpnStack.Pop();
									rpnStack.Push(num2/num1);
									break;
						default:
								break;
					}
				}
				else if (int.TryParse(rpnTokens[i] + "", out value))
				{
					rpnStack.Push(Convert.ToInt16(rpnTokens[i]));
				}
			}

			return rpnStack.Pop();
		}
	}
}
