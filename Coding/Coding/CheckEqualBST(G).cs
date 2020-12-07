public class CheckEqualBST
{
    public static bool Run(TreeNode p, TreeNode q){
        if(p == null || q == null){
            return false;
        }

        var pIt = new BSTIterator(p);
        var qIt = new BSTIterator(q);
        while (pIt.HasNext() && qIt.HasNext())
        {
            if(pIt.Next() != qIt.Next()){
                return false;
            }
        }

        return !pIt.HasNext() && !qIt.HasNext();
    }   
}