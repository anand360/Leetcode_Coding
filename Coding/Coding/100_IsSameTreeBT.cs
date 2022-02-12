// https://leetcode.com/problems/same-tree/

public class IsSameTree {
    public bool Run(TreeNode p, TreeNode q) {
        if(p == null && q == null){
            return true;
        }
        else if(p != null && q == null){
            return false;
        }
        else if(p == null && q != null){
            return false;
        }
        else{
            return (p.val == q.val && Run(p.left, q.left) && Run(p.right, q.right));
        }
    }
}