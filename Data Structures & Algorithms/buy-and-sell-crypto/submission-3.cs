public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        int sellPrice = prices[0];
        int buyPrice = prices[0];
        for (int i = 1; i < prices.Length; i++) {
            int currentPrice = prices[i];
            if (buyPrice > currentPrice) {
                int prevProfit = sellPrice - buyPrice;
                if (prevProfit > maxProfit) {
                    maxProfit = prevProfit;
                }
                buyPrice = currentPrice;
                sellPrice = currentPrice;
            } else if (sellPrice < currentPrice ) {
                sellPrice = currentPrice;
                int profit = sellPrice - buyPrice;
                if (profit > maxProfit) {
                    maxProfit = profit;
                }
            }

        }
        return maxProfit;
    }
}
