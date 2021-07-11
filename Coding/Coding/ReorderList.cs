// https://leetcode.com/problems/reorder-list/


public class ReorderList{
    public static void Run(Node head){
        if(head == null || head.Next == null){
            return;
        }

        var slow = head; 
        var fast = head.Next;
        // find mid of LL
        while(fast != null){
            fast = fast.Next;
            if(fast != null){
                fast = fast.Next;
            }
            else{break;}

            slow = slow.Next;
        }

        var head1 = head;
        var head2 = slow.Next;
        slow.Next = null;

        // reverse
        head2 = Reverse(head2);

        // merge
        while(head2 != null){
            var h1 = head1.Next;
            var h2 = head2.Next;

            head1.Next = head2;
            if(h1 != null)
            head2.Next = h1;

            head1 = h1;
            head2 = h2;
        }
    }

    private static Node Reverse(Node head){
        if(head == null){
            return null;
        }
        
        var cur = head;
        Node prev = null;

        while(cur != null){
            var temp = cur.Next;
            cur.Next = prev;
            prev = cur;

            cur = temp;
        }

        return prev;
    }
}