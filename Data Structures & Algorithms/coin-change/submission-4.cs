public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = amount + 1;
        }
        dp[0] = 0;
        for (int a = 1; a < amount + 1; a++) {
            for (int c = 0; c < coins.Length; c++) {
                int coin = coins[c];
                if (a - coin >= 0) {
                    dp[a] = Math.Min(dp[a], 1 + dp[a - coin]);
                }
            }
        }   
        return dp[amount] == (amount + 1) ? -1 : dp[amount];
    }
}
