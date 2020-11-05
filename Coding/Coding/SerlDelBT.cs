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

public class SerlDelBT
{
    public List<string> st { get; set; }
    public SerlDelBT()
    {
        st = new List<string>();
    }

    public List<string> Serialize(TreeNode root)
    {
        var res = new List<string>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            var el = q.Dequeue();
            res.Add(el.val);

            if (el.left == null && el.val != "null")
            {
                q.Enqueue(new TreeNode("null"));
            }
            else if (el.left != null)
            {
                q.Enqueue(el.left);
            }

            if (el.right == null && el.val != "null")
            {
                q.Enqueue(new TreeNode("null"));
            }
            else if (el.right != null)
            {
                q.Enqueue(el.right);
            }
        }

        return res;
    }

    public TreeNode DeSerialize(List<string> s)
    {
        TreeNode root = null;
        var q = new Queue<TreeNode>();
        int cIndex = 1;

        root = new TreeNode(s[0]);
        q.Enqueue(root);

        for (int i = 1; i < s.Count; i++)
        {
            cIndex = BuildBT(root, s[i], q, cIndex);
        }

        return root;
    }

    private static int BuildBT(TreeNode root, string s, Queue<TreeNode> q, int cIndex)
    {
        var node = new TreeNode(s);
        if (root == null)
        {
            root = new TreeNode(s);
        }

        else if (q.Peek().left == null && cIndex == 1)
        {
            if (s != "null")
            {
                q.Peek().left = node;
            }

            cIndex = cIndex + 1;
        }

        else if (q.Peek().right == null && cIndex == 2)
        {
            if (s != "null")
            {
                q.Peek().right = node;
            }

            q.Dequeue();
            cIndex = cIndex - 1;
        }

        if (s != "null")
            q.Enqueue(node);

        return cIndex;
    }
}