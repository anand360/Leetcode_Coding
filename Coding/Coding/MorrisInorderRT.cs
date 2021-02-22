public class MorrisInorderRT{
    public static void Run(TreeNode root){
        if(root == null){
            return;
        }

        while (root != null)
        {
            if(root.left == null){
                System.Console.WriteLine(root.val);
                root = root.right;
            }
            else{
                var pred = root.left;
                while(pred.right != null && pred.right != root){
                    pred = pred.right;
                }

                if(pred.right == null){
                    pred.right = root;
                    root = root.left;
                }else{
                    pred.right = null;
                    System.Console.WriteLine(root.val);
                    root = root.right;
                }
            }
        }
    }
}