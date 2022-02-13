
// https://leetcode.com/problems/merge-two-sorted-lists/

public class MergeTwoLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode Run(ListNode list1, ListNode list2)
    {
        if(list1 == null)
        {
            return list2;
        }

        if(list2 == null)
        {
            return list1;
        }

        ListNode head = new ListNode(0);
        ListNode cur = head;
        while (list1 != null || list2 != null)
        {
            int n1 = list1 == null ? int.MaxValue : list1.val;
            int n2 = list2 == null ? int.MaxValue : list2.val;

            if(n1 < n2)
            {
                cur.next = list1;
                list1 = list1.next;
            }
            else
            {
                cur.next = list2;
                list2 = list2.next;
            }

            cur = cur.next;
            cur.next = null;
        }

        return head.next;        
    }
}