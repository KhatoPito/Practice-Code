//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KhatoPito.Tesla
//{
//        public static class Solutions
//        {
//            public static string solution( this string message, int length)
//            {

//                var stringArray = message.Split(' ');

//                if (string.IsNullOrEmpty(message))
//                    return message;

//                if (length >= message.Length)
//                        return message;

//                int end = length;

//                for (int i = end; i > 0; i--)
//                {
//                    if (string.IsNullOrEmpty(message[i].ToString()))
//                    {
//                        break;
//                    }

//                    end--;
//                }

//                if (end == 0)
//                {
//                    end = length;
//                }

//            var result = message.Substring(0, end).Split(' ');


//            int j = 0; var finalAnswer = string.Empty;
//            foreach (var item in result)
//            {
//                if (item == stringArray[j++])
//                {
//                    finalAnswer = finalAnswer + " " + item;
//                }
//            }


//                return finalAnswer.Trim();
//            }
//        }

//    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhatoPito.Tesla
{
    public class Solutions
    {
        public string solution(string message, int K)
        {

            var stringArray = message.Split(' ');

            if (string.IsNullOrEmpty(message))
                return message;

            if (K >= message.Length)
                return message;

            int end = K;

            for (int i = end; i > 0; i--)
            {
                if (string.IsNullOrEmpty(message[i].ToString()))
                {
                    break;
                }

                end--;
            }

            if (end == 0)
            {
                end = K;
            }

            var result = message.Substring(0, end).Split(' ');


            int j = 0; var finalAnswer = string.Empty;
            foreach (var item in result)
            {
                if (item == stringArray[j++])
                {
                    finalAnswer = finalAnswer + " " + item;
                }
            }


            return finalAnswer.Trim();
        }
    }

}
