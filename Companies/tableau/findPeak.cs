/*
Find a peak element
Given an array of integers.
Find a peak element in it. An array element is peak if it is NOT smaller than its neighbors. 
For corner elements, we need to consider only one neighbor.
For example, for input array {5, 10, 20, 15}, 20 is the only peak element. 
For input array {10, 20, 15, 2, 23, 90, 67}, there are two peak elements: 20 and 90. Note that we need to return any one peak element.


  162. Find Peak Element
  Given an input array nums, where nums[i] ≠ nums[i+1], find a peak element and return its index.
  The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
  You may imagine that nums[-1] = nums[n] = -∞.

  Example 1:
  Input: nums = [1,2,3,1]
  Output: 2
  Explanation: 3 is a peak element and your function should return the index number 2.

  Example 2:
  Input: nums = [1,2,1,3,5,6,4]
  Output: 1 or 5 
  Explanation: Your function can return either index number 1 where the peak element is 2, 
               or index number 5 where the peak element is 6.
*/

public class Solution {
    public int FindPeakElement(int[] nums) {
        
        int l = 0;
        int r = nums.Length-1;
        
        while(l < r)
        {
            int mid = l + (r-l)/2;
            
            if(nums[mid] > nums[mid + 1])
            {
                r = mid;
            }
            else
            {
                l = mid+1;
            }            
        }
        
        return l;
        
    }
}


// Alternative solution

/*
    public int FindPeakElement(int[] nums) {
        
        for(int i =0; i< nums.Length -1 ; i++)
        {
            if(nums[i] > nums[i+1])
                return i;            
        }
        
        return nums.Length - 1;
    }

*/



