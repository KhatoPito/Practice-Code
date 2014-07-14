using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMinValueProblem
{
    /*
     Problem - Design a stack that supports push, pop, and retrieving the minimum element in constant time.
    
     Solution - Keep a "duplicate" stack of "minimum of all values lower in the stack". 
                When you pop the main stack, pop the min stack too.
                When you push the main stack, push either the new element or the current min, whichever is lower. 
                getMinimum() is then implemented as just minStack.peek().
    
        Real stack        Min stack

         5  --> TOP        1
         1                 1
         4                 2
         6                 2
         2                 2
     
        After popping twice you get:

         Real stack        Min stack

         4                 2
         6                 2
         2                 2
   */

    public class MinValueStack<T>
    {
        private Stack<T> minStack = new Stack<T>();
        private Stack<T> realStack = new Stack<T>();
        private T _currentMin;
        private readonly IComparer<T> comparer = Comparer<T>.Default;


        public T CurrentMin
        {
            get
            {
                return _currentMin;
            }
            set
            {
                _currentMin = value;
            }
        }
        
        public void Push(T item)
        {
            if ((realStack.Count == 0) || ( comparer.Compare(CurrentMin,item) > 0))
            {
                _currentMin = item;
            }

            realStack.Push(item);
            minStack.Push(_currentMin); 
        }

        public T Pop()
        {
            minStack.Pop();
            return realStack.Pop();
        }

        public T GetMinStackValue()
        {
            if (minStack.Count != 0)
                return CurrentMin;
            else
                throw new InvalidOperationException("Stack is empty");
        
        
        
        }  
    }

    class Program
    {
        static void Main(string[] args)
        {
            MinValueStack<int> obj = new MinValueStack<int>();

            obj.Push(21);
            obj.Push(20);
            obj.Pop();
            Console.WriteLine("The smallest element is : " + obj.GetMinStackValue());

            obj.Push(12);
            obj.Push(10);
            Console.WriteLine("The smallest element is : " + obj.GetMinStackValue());
            obj.Push(3);
            obj.Push(13);
            Console.WriteLine("The smallest element is : " + obj.GetMinStackValue());

            
            Console.ReadLine();
        }
    }
}
