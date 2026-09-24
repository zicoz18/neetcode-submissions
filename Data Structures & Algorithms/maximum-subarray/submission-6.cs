public class Solution {
    public int MaxSubArray(int[] nums) {
        // think like DP, start from most right element,
        // for that element what is the max
        // then, process the element on the left, given max for right part of is already calculated
        // current one's max value is either directly itself or right part + itself
        // update the value for the current one and get to process the next one on the left
        int[] maxs = new int[nums.Length];
        int max = -1;
        bool hasSet = false;
        DP(nums, nums.Length - 1, maxs, ref max, ref hasSet);
        return max;
    }

    public void DP(int[] nums, int index, int[] maxs, ref int max, ref bool hasSet) {
        if (index < 0) return;
        if (index >= nums.Length) return;
        if (!hasSet) {
            max = nums[index];
            hasSet = true;
        }
        if (index == nums.Length - 1) {
            maxs[index] = nums[index];
        } else {
            maxs[index] = Math.Max(nums[index] + maxs[index + 1], nums[index]);
        }
        if (maxs[index] > max) {
            max = maxs[index];
        }
        DP(nums, index - 1, maxs, ref max, ref hasSet);
    }
}
