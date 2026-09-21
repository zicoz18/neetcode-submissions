public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        for (int i = 0; i < dp.Length; i++) {
            dp[i] = 1;
        }
        int max = -1;
        for (int i = nums.Length - 1; i >= 0; i--) {
            int num = nums[i];
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] < nums[j]) {
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    if (dp[i] > max) {
                        max = dp[i];
                    }
                }
            }
        }
        return max == -1 ? 1 : max;
    }
}
