// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/

using System;
using System.Collections.Generic;

public class TreeNextNode
    {
        public int val;
        public TreeNextNode left;
        public TreeNextNode right;
        public TreeNextNode next;

        public TreeNextNode() { }

        public TreeNextNode(int _val)
        {
            val = _val;
        }

        public TreeNextNode(int _val, TreeNextNode _left, TreeNextNode _right, TreeNextNode _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

public class ConnectNextRightPointers
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
                    if (q.right != null)
                    {
                        q.left.next = q.right;
                    }
                    else
                    {
                        q.left.next = GetNextRight(q);
                    }
                }
                if (q.right != null)
                {
                    q.right.next = GetNextRight(q);
                }

                q = q.next;
            }

            if(p.left != null){
                p = p.left;
            }else if(p.right != null){
                p = p.right;
            }else{
                p = GetNextRight(p);
            }
        }

        return root;
    }

    private static TreeNextNode GetNextRight(TreeNextNode root)
    {
        var temp = root.next;
        while (temp != null)
        {
            if (temp.left != null)
            {
                return temp.left;
            }
            else if (temp.right != null)
            {
                return temp.right;
            }

            temp = temp.next;
        }

        return temp;
    }
}