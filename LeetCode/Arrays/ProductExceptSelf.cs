/*
  Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

  Example:

  Input:  [1,2,3,4]
  Output: [24,12,8,6]
  Note: Please solve it without division and in O(n).

  Follow up:
  Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)


Algorithm:
1) Construct a temporary array left[] such that left[i] contains product of all elements on left of arr[i] excluding arr[i].
2) Construct another temporary array right[] such that right[i] contains product of all elements on on right of arr[i] excluding arr[i].
3) To get prod[], multiply left[] and right[].

Time Complexity: O(n)
Space Complexity: O(n)
Auxiliary Space: O(n)
*/



public  int[] ProductExceptSelf(int[] nums)
{
    int[] result = new int[nums.Length];

    int[] t1 = new int[nums.Length];
    int[] t2 = new int[nums.Length];

    t1[0] = 1;
    t2[nums.Length - 1] = 1;

    //scan from left to right
    for (int i = 0; i < nums.Length - 1; i++)
    {
        t1[i + 1] = nums[i] * t1[i];
    }

    //scan from right to left
    for (int i = nums.Length - 1; i > 0; i--)
    {
        t2[i - 1] = t2[i] * nums[i];
    }

    //multiply
    for (int i = 0; i < nums.Length; i++)
    {
        result[i] = t1[i] * t2[i];
    }

    return result;
}
