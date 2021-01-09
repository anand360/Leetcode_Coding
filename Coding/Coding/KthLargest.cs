using System.Collections.Generic;

public class KthLargest{
    private int K { get; set; }

    public List<int> MinHeap { get; set; }

    private int KthLargestVal;

    public KthLargest(int k, int[] nums)
    {
        this.K = k;
        MinHeap = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            Add(nums[i]);
        }
    }

    public int Add(int val) {
        MinHeap.Add(val);

        MinHeap.Sort();

        if(MinHeap.Count> K){
            MinHeap.RemoveAt(0);
        }

        KthLargestVal = MinHeap[0];  

        return KthLargestVal;      
    }
}


/* Using Priority Queue - Java
class KthLargest {
    final PriorityQueue<Integer> q;
    final int k;
    
    public KthLargest(int k, int[] nums) {
        this.k = k;
        q = new PriorityQueue<>(k+1);
        for (int n : nums)
            add(n);
    }
    
    public int add(int val) {
        q.offer(val);
        
        if(q.size() > k){
            q.poll();
        }
        
        return q.peek();
    }    
}
*/