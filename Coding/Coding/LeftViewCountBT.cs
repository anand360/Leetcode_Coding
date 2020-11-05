using System.Collections.Generic;

public class TNode{
    public int Data { get; set; }

    public TNode Left { get; set; }

    public TNode Right { get; set; }
}

public class LeftviewBT
{
    public static int Run(TNode root){
        if (root == null)
        {
            return 0;
        }

        var q = new Queue<TNode>();
        q.Enqueue(root);
        int count = 0;
        while (q.Count > 0)
        {
            var qc = q.Count;
            count++;
            while (qc > 0)
            {
                var el = q.Dequeue();
                if(el.Left != null){
                    q.Enqueue(el.Left);
                }

                if (el.Right != null)
                {
                    q.Enqueue(el.Right);
                }
                qc--;
            }
        }

        return count;
    }
}