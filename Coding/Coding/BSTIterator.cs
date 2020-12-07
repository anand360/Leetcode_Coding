using System.Collections.Generic;

public class BSTIterator {
    private Stack<TreeNode> Stor { get ; set ; }

    public BSTIterator(TreeNode root) {
        Stor = new Stack<TreeNode>();
        LeftMostIt(root);
    }
    
    /** @return the next smallest number */
    public string Next() {
        var next = Stor.Pop();
        if(next.right != null){
            LeftMostIt(next.right);
        }
        
        return next.val;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return Stor.Count > 0;
    }
    
    private void LeftMostIt(TreeNode node){
        while(node != null){
            Stor.Push(node);
            node = node.left;
        }
    }
}