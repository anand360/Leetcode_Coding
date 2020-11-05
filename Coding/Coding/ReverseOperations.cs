public class Node
{
    public int Data { get; set; }

    public Node Next { get; set; }

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class ReverseOperations
{
    public static Node Run(Node head)
    {
        head = new Node(2);
        head.Next = new Node(8);
        head.Next.Next = new Node(1);
        head.Next.Next.Next = new Node(9);
        head.Next.Next.Next.Next = new Node(12);
        head.Next.Next.Next.Next.Next = new Node(16);

        if (head == null)
        {
            return null;
        }

        Node cur = head;

        Node prevOdd = null;
        while (cur != null)
        {
            Node headEven = null;

            // if (cur.Data % 2 != 0)
            // {
            //     prevOdd = new Node(cur.Data);
            // }

            while (cur != null && cur.Data % 2 == 0)
            {
                Node temp = new Node(cur.Data);
                temp.Next = headEven;
                headEven = temp;

                cur = cur.Next;
            }

            if (headEven != null)
            {
                if(prevOdd == null){
                    head = headEven;
                }else{
                    prevOdd.Next = headEven;
                }
                
                while (headEven.Next != null)
                {
                    headEven = headEven.Next;
                }
                headEven.Next = cur;
            }

            if (cur != null && cur.Data % 2 != 0)
            {
                prevOdd = cur;
            }

            if (cur != null)
                cur = cur.Next;
        }

        return head;
    }
}