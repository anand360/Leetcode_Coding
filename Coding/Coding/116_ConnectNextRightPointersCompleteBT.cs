// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

public class ConnectNextRightPointersCompleteBT
{
    public static TreeNextNode Run(TreeNextNode root)
    {
        if(root == null){
            return root;
        }

        root.next = null;
        var p = root;
        while (p != null)
        {
            var q = p;
            while (q != null)
            {
                if (q.left != null)
                {
                    q.left.next = q.right;
                }
                if (q.right != null)
                {
                    q.right.next = q.next == null ? q.next : q.next.left;
                }

                q = q.next;
            }

            p = p.left;
        }

        return root;
    }
}