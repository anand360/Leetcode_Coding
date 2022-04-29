// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

public class MaxProfit {
    public int Run(int[] prices) {
        if(prices == null || prices.Length == 0)
        {
            return 0;
        }
        
        int profit = 0;
        int buy = prices[0];
        
        for(int i = 1;i < prices.Length; i++)
        {
            if(prices[i] > buy)
            {
                if(profit < (prices[i] - buy))
                {
                    profit = prices[i] - buy;
                }
            }
            else
            {
                buy = prices[i];
            }
        }
        
        return profit;
    }
}