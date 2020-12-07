// Serialize and Deserialize Binary Tree

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class TreeNode
{
    public string val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(string x) { val = x; }

    public static TreeNode Init()
    {
        var root = new TreeNode("1");
        root.left = new TreeNode("2");
        root.right = new TreeNode("3");
        root.right.left = new TreeNode("4");
        root.right.right = new TreeNode("5");

        return root;
    }
}

public class SerDelBSTnBT
{
    public static string Serialize(TreeNode root)
    {
        if (root == null)
        {
            return "";
        }

        var sb = new StringBuilder();
        var q = new Queue<TreeNode>();

        q.Enqueue(root);
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var el = q.Dequeue();
                if (el == null)
                {
                    sb.Append("# ");
                }
                else
                {
                    sb.Append(el.val).Append(" ");
                    q.Enqueue(el.left);
                    q.Enqueue(el.right);
                }
            }
        }

        return sb.ToString().TrimEnd(' ');
    }

    public static TreeNode Deserialize(string data)
    {
        if (data == null)
        {
            return null;
        }

        var els = data.Split(' ');
        if (data.Length == 1 && els[0] == "#")
        {
            return null;
        }
        var q = new Queue<TreeNode>();
        var root = new TreeNode(els[0]);

        q.Enqueue(root);

        for (int i = 1; i < els.Length; i++)
        {
            var el = q.Dequeue();
            if (els[i] != "#")
            {
                el.left = new TreeNode(els[i]);
                q.Enqueue(el.left);
            }
            if (els[++i] != "#")
            {
                el.right = new TreeNode(els[i]);
                q.Enqueue(el.right);
            }
        }

        return root;
    }
}