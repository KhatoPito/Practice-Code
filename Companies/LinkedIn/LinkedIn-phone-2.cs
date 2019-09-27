/*     


       3    K
           /\____
     2    G      Q
         /\      /\
     1  C  H    M  Y
        /\       \
     0  B D       B
        
   
   FALLING LEAVES
   
    BDHBY
    CM
    GQ
    K
    
    
    
*/

public class HelloWorld {


    IList<IList<char>> resultList; 

    class Node
    {
        Node right;
        Node left;
        char val;

        Node(char c)
        {
            this.c = val;
        }     
    }
        
    public HelloWorld()
    {
        resultList = new List<List<char>>();
        
    }

    
    public IList<IList<char>> FindLeaves(Node root)
    {
        HelperFindLeaves(root);
        return resultList;        
    }
    
    
    // ResultList
    // 0 -> {B, D, H, B,  Y   }
    // 1 -> {C, M,  }
    // 2 -> {G, Q}
    // 3 >  {K }
    
    
    // Test Cases 
    // use case 1: Emptry - Null
    // User case 2: Left Nodes only
    // User case 3: Right Nodes only
    // User case 4: Only Root
    // 
    
    
    int HelperFindLeaves(Node root)
    {
        // base condition
        if(node == null) return -1;
        
        // find th height of leaf 
        int height = 1 + Math.Max(HelperFindLeaves(root.left), HelperFindLeaves(root));
        
        
        if(resltList.Count < height + 1) resultList.Add(new List<char>);
        
        resiltList[height].Add(root.val);
                
        
        return height; 
    }
    
}


