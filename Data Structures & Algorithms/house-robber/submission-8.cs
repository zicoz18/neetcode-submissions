public class Solution {
    public int Rob(int[] nums) {
        // I guess there gotta be a decision tree
        // Not sure what exactly is the decision tho
        // Rob the current house or not?
        // If you rob the house, you increment by 2
        // if you dont rob the house, you increment by 1

        // I guess this makes sense, but I believe I will again have problem with time limit
        // So, I gotta implement some memoization
        int[] robs = new int[nums.Length];
        for (int i = 0 ; i < robs.Length; i++) {
            robs[i] = -1;
        }
        return DT(0, nums, robs);
    }

    public int DT(int index, int[] nums, int[] robs) {
        if (index >= nums.Length) return 0;
        if (robs[index] != -1) return robs[index];
        int currentHouseMoneyRobbed = nums[index];
        int robCurrentIndex = currentHouseMoneyRobbed + DT(index + 2, nums, robs);
        int skipCurrentIndex = DT(index + 1, nums, robs);
        int maxForCurrentIndex = Math.Max(robCurrentIndex, skipCurrentIndex);
        robs[index] = maxForCurrentIndex;
        return maxForCurrentIndex;
    }
}
