Deep copy a list of nodes (a graph)
https://www.geeksforgeeks.org/clone-an-undirected-graph/


/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/
public class Solution {
    public Node CloneGraph(Node node) {
        
        if(node == null) return null;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        
        var map = new Dictionary<Node, Node>();
        map.Add(node, new Node(node.val, new List<Node>()));

        while(queue.Count != 0)
        {
            Node qNode = queue.Dequeue();
            
            foreach(var neighbor in qNode.neighbors)
            {
                if(!map.ContainsKey(neighbor))
                {
                    map.Add(neighbor, new Node(neighbor.val, new List<Node>()));
                    queue.Enqueue(neighbor);
                }
                
                map[qNode].neighbors.Add(map[neighbor]);
                
            }            
        }
        
        return map[node];
    }    
}
