public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        for (int i = 0; i < prices.Length - 1; i++) {
            int potentialBuyPrice = prices[i];
            for (int j = i + 1; j < prices.Length; j++) {
                int potentialSellPrice = prices[j];
                int profit = potentialSellPrice - potentialBuyPrice;
                if (profit > maxProfit) {
                    maxProfit = profit;
                }
            }
        }
        return maxProfit;
    }
}
