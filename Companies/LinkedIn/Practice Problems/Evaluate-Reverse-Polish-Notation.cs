/*
  Evaluate the value of an arithmetic expression in Reverse Polish Notation.

  Valid operators are +, -, *, /. Each operand may be an integer or another expression.

  Note:

  Division between two integers should truncate toward zero.
  The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.
  Example 1:

  Input: ["2", "1", "+", "3", "*"]
  Output: 9
  Explanation: ((2 + 1) * 3) = 9
  Example 2:

  Input: ["4", "13", "5", "/", "+"]
  Output: 6
  Explanation: (4 + (13 / 5)) = 6

*/


public class Solution {
    public int EvalRPN(string[] tokens) {

      var stack = new Stack<int>();

      for (int i = 0; i < tokens.Length; i++) {

          switch (tokens[i]) {
          case "+":
            stack.Push(stack.Pop() + stack.Pop());
            break;

          case "-":
            stack.Push(-stack.Pop() + stack.Pop());
            break;

          case "*":
            stack.Push(stack.Pop() * stack.Pop());
            break;

          case "/":
            int n1 = stack.Pop(), n2 = stack.Pop();
            stack.Push(n2 / n1);
            break;

          default:
            stack.Push(int.Parse(tokens[i]));
            break;
        }
      }

      return stack.Pop();
        
    }
}
