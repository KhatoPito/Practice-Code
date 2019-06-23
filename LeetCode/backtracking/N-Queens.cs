public class Solution {
   public IList<IList<string>> qBoard = new List<IList<string>>(); 
    
    public int TotalNQueens(int n) 
    {
        int[,] board = new int[n,n];
        
        for(int i=0; i< n; i++)
            for(int j=0; j<n; j++)
                board[i,j]=0;
        
        SolveQueen(board, 0, n);
        return qBoard.Count;
    }
    
    
    public void SolveQueen(int[,] board, int col, int n)
    {
        if(col >= n) {
            qBoard.Add(GenerateqBoardList(board, n));
            return;
        }
        
        for(int i=0; i< n; i++)  //for each row, check placing of queen is possible or not
        {
            if(IsValid(board, i, col, n))
            {
               board[i,col] = 1;  /*if validate, place the queen at place (i, col)*/
               SolveQueen( board, col+1, n);  /*Go for the other columns recursively*/      
               board[i,col] = 0;    /*When no place is vacant remove that queen      */         
            }
        }
        
        return; //when no possible order is found         
    }
    
    public bool IsValid(int[,] board, int row, int col, int n)
    {
        //check whether there is queen in the left or not
        for(int i=0; i < col; i++) 
            if(board[row,i] == 1)  return false;
        
        //check whether there is queen in the left upper diagonal or not
        for(int i=row,j=col;i>=0 &&j>=0; i--,j--)
            if(board[i,j] == 1)  return false;            
 
        //check whether there is queen in the left lower diagonal or not
         for (int i=row, j=col; j>=0 && i<n; i++, j--)
            if (board[i,j] == 1)  return false;
        
        return true;        
    }
    
    public IList<string> GenerateqBoardList(int[,] board, int n)
    {
        List<string> list = new List<string>();       
        for(int i=0; i< n; i++)
        {             
            StringBuilder row = new StringBuilder();
            for(int j=0; j< n; j++)
            {
                if(board[i,j] == 1)
                    row.Append("Q");
                else
                    row.Append(".");                
            } 
            
            list.Add(row.ToString());
        }
        
        list.Reverse();        
        return list;
    }

}
