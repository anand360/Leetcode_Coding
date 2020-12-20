using System.Collections.Generic;
using System.Linq;

public class NAryLevelOrder
{
    public static IList<IList<int>> Run(NAryTreeNode root){
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null){
            return result;
        }

        var q = new Queue<NAryTreeNode>();
        q.Enqueue(root);
        while(q.Count > 0){
            var size = q.Count;
            IList<int> row = new List<int>();
            
            for (int i = 0; i < size; i++)
            {
                var cur = q.Dequeue();
                row.Add(cur.val);
                var children = cur.Children;
                if(children != null && children.Any()){
                    foreach (var item in children)
                    {
                        q.Enqueue(item);
                    }
                }
            }

            result.Add(row);
        }                

        return result;
    }

    // DFS
    private List<List<int>> levelOrder(NAryTreeNode node, int level, List<List<int>> order){
        if (node == null){
            return order;
        }
        List<int> list = order.Count > level ?  order[level] : new List<int>();
        list.Add(node.val);
        if (order.Count <= level){
            order.Add(list);
        }
        foreach(var n in node.Children){
            levelOrder(n, level + 1, order);
        }
        return order;
    }
}