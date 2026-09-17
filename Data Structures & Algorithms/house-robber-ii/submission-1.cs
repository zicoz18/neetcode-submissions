public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        int numCount = nums.Length;
        int[] memo0 = new int[numCount];
        int[] memo1 = new int[numCount];
        for (int i = 0 ; i < numCount; i++) {
            memo0[i] = -1;
            memo1[i] = -1;
        }
        return Math.Max(
            DT(0, nums.Skip(1).Take(numCount -1).ToArray(), memo0), 
            DT(0, nums.Take(numCount - 1).ToArray(), memo1)
        );
    }

    public int DT(int index, int[] nums, int[] memo) {
        if (index >= nums.Length) return 0;
        if (memo[index] != -1) return memo[index];
        int currentHouseMoneyRobbed = nums[index];
        int robCurrentIndex = currentHouseMoneyRobbed + DT(index + 2, nums, memo);
        int skipCurrentIndex = DT(index + 1, nums, memo);
        int maxForCurrentIndex = Math.Max(robCurrentIndex, skipCurrentIndex);
        memo[index] = maxForCurrentIndex;
        return maxForCurrentIndex;
    }
}
