 /** https://leetcode.com/problems/nested-list-weight-sum-ii/submissions/
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public int DepthSumInverse(IList<NestedInteger> nestedList) {       
        int depth = findDepth(nestedList);
        return depthsum(nestedList, depth);        
    }
    
    public int findDepth(IList<NestedInteger> nestedList)
    {
        if(nestedList == null || nestedList.Count == 0) return 0;
        int max = 0;
        foreach(var n in nestedList)           
        {           
            if(n.IsInteger())
               max = Math.Max(max,1); 
            else
               max = Math.Max(max, findDepth(n.GetList()) + 1);
        }
        
        return max;
    }
    
    public int depthsum(IList<NestedInteger> nestedList, int depth)
    {
         int sum = 0;   
         if(nestedList == null || nestedList.Count == 0) return sum;
        
        foreach(var n in nestedList)           
        {           
            if(n.IsInteger())
                sum+= n.GetInteger() * depth;            
            else
                sum += depthsum(n.GetList(), depth-1);
        }
        
        return sum;        
    }
}
