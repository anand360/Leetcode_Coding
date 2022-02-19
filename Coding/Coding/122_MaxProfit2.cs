// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

public class MaxProfit2 {
    public int Run(int[] prices) {
        if(prices == null || prices.Length == 0)
        {
            return 0;
        }
        
        int profit = 0;
        
        for(int i = 1;i < prices.Length; i++)
        {
            int oneDayProfit = prices[i] - prices[i-1];
            if(oneDayProfit > 0)
            {
                profit += oneDayProfit;
            }
        }
        
        return profit;
    }
}