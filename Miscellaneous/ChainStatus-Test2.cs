
/*


Description
We use special generator to produce chains of elements. Don't ask why we need them, we're not sure that somebody knows the answer for this question. A chain is represented by a string of name-address pairs. So the first element is the name of a pair and the second one (address) is pointing to the name of a next pair. E.g.
BEGIN-3;4-2;3-4;2-END # GOOD
77-END;BEGIN-8;8-11;11-77 # GOOD


In examples above we can pass trough the chains from the 'BEGIN' to the 'END' without missing any single pair. In the first case we moved from 'BEGIN' to 3, from 3 to 4, from 4 to 2, from 2 to 'END'. In the second case we moved from 'BEGIN' to 8, from 8 to 11, from 11 to 77, from 77 to 'END'. 

Our generator was producing only good chains, but something went wrong and now it generates random chains and we are not sure if it's a good chain or a bad one. E.g. 
BEGIN-3;4-3;3-4;2-END # BAD
77-END;BEGIN-8;8-77;11-11 # BAD

In the first case the 'END' is unreachable because we have a loop between 3 and 4. 
In the second case we can reach the 'END' but we missed one pair (11-11). 
We know that for a BAD chain the generator first produces a GOOD chain but after that it may replace existing address in some pairs with an address from another pair. It never replaces an address in a pair to an addresses which isn't present in original chain. 

You can help us by writing a program that investigates the input and finds GOOD and BAD chains.
Input

Your program should read lines from standard input. Each line is a chain. The pairs are separating by semicolon, the names and the address are separating by dash. The number of pairs in a chain is in range [1, 500]. The addresses are integers in range [2, 10000].

Output
Print out the status of the chain (GOOD or BAD).

Test 1
Input
4-2;BEGIN-3;3-4;2-END

Expected Output
GOOD

Test 2
Input
4-2;BEGIN-3;3-4;2-3

Expected Output
BAD

*/


using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication5
{
    public enum Status
    {
        GOOD = 0,
        BAD = 1
    };

    class ChainStatus
    {

        static Status ReturnChainStatus(string input)
        {
            bool status = false;

            if (string.IsNullOrEmpty(input))
                throw new InvalidDataException("input string is not valid.");


            Dictionary<string, string[]> chainDictionary = new Dictionary<string, string[]>();
            string[] sampleInput = input.Split(';');

            foreach (var sample in sampleInput)
            {
                var key = sample.Split('-');
                if (!chainDictionary.ContainsKey(key[0]))
                    chainDictionary.Add(key[0], key);
            }

            var value = chainDictionary["BEGIN"];

            if (value == null)
                return Status.BAD;

            status = FindEndFromDict(value, chainDictionary, chainDictionary.Count -1);


            return status ? Status.GOOD : Status.BAD;
        }

        public static bool FindEndFromDict(string[] values, Dictionary<string, string[]> chainDictionary, int length)
        {
            if (values[1] == "END" && chainDictionary.Count == 0)
                return true;

            if (chainDictionary.Count == 0 || length <= 0)
                return false;

            string[] foundItem;
            if(chainDictionary.ContainsKey(values[1]))
                foundItem = chainDictionary[values[1]];
            else
                return false;
            
            var searchItem = foundItem; // itme to look for again in dict

            // remove begin from Dictionary 
            if (chainDictionary.ContainsKey("BEGIN"))
                chainDictionary.Remove("BEGIN");

            chainDictionary.Remove(foundItem[0]);

            length = length - 1;
            return FindEndFromDict(searchItem, chainDictionary, length);
        }

        public static void Main(string[] args)
        {
            //string sample = "77-END;BEGIN-8;8-11;11-77";
            string sample = "4-2;BEGIN-3;3-4;2-END";

            Status status = ReturnChainStatus(sample);

            Console.WriteLine("The status of the chain is : " + status.ToString());


            Console.Read();

        }
    }
}
