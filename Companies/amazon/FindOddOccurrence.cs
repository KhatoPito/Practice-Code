// Write a function that takes an array and size as a parameter. The array contains non-negative numbers. 
// Every number in the array appears an even number of times, except for one number that appears an odd number of times. 
// The function should return the number that appears an odd number of times. 
// Sample Input: [1, 7, 2, 1, 9, 7, 2, 9, 2]

// Time - O(N)
// Space - O(N)

public static int FindOddNumber(int[] array, bool xor)
{
    if(xor)
    {
        return FindOddNumberByXOR(array);
    }
    else
    {
        FindOddNumberByDict(array)
    }
    
    return -1;    
}


public static int FindOddNumberByXOR(int[] array)
{
    if(array == null || array.Length == 0)
    return -1;
    
    int result = 0;
    foreach(num in array)
    {
        result ^= num;

    }

    return result;
        
}

public static int FindOddNumberByDict(int[] array)
{
    if(array == null || array.Length == 0)
    return -1;
    
    var map  = new Dictionary<int, int>();
    
    foreach(num in array)
    {
        if(!map.ContainsKey(num))
        {
            map.Add(num, 1);
        }
        else
        {
            map[num] += 1;
        }
    }
    
    foreach(var num in map)
    {
        if(map[num] % 2 != 0)
        {
            return num;
        }
    }
    
    return -1;
        
}
