
using System;
using System.Collections.Generic;
using System.Text;

public class NAryTreeNode
{
    public int val { get; set; }
    public List<NAryTreeNode> Children { get; set; }

    public NAryTreeNode(int val)
    {
        this.val = val;
        Children = new List<NAryTreeNode>();
    }
}

public class SelDelNAry
{
    public static string Serialize(NAryTreeNode root)
    {
        if (root == null)
        {
            return "#";
        }

        var sb = new StringBuilder();
        SerializeUtil(root, sb);

        return sb.ToString().TrimEnd(',');
    }

    private static void SerializeUtil(NAryTreeNode root, StringBuilder sb)
    {
        if (root == null)
        {
            sb.Append("#").Append(",");
            return;
        }

        sb.Append(root.val).Append(",");

        var count = root.Children.Count;
        sb.Append(count).Append(",");

        foreach (var item in root.Children)
        {
            SerializeUtil(item, sb);
        }
    }

    public static NAryTreeNode Deserialize(string data)
    {
        if (data == null)
        {
            return null;
        }

        var nodes = data.Split(',');
        var q = new Queue<string>();
        foreach (var item in nodes)
        {
            q.Enqueue(item);
        }
        return DeserializeUtil(q);
    }

    private static NAryTreeNode DeserializeUtil(Queue<string> q)
    {
        if(q.Count == 0)
            return null;

        var el = Convert.ToInt32(q.Dequeue());
        var count = Convert.ToInt32(q.Dequeue());

        var root = new NAryTreeNode(el);
        for (int i = 0; i < count; i++)
        {
            root.Children.Add(DeserializeUtil(q));
        }

        return root;
    }
}