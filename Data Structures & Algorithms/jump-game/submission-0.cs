public class Solution {
    public enum STATE {
        NOT_INITIALIZED,
        NOT_REACHED,
        REACHED
    }

    public bool CanJump(int[] nums) {
        STATE[] memo = new STATE[nums.Length]; // using 0 as not calculated, 1 as did not reach, 2 as reached
        return DT(nums, 0, memo);
    }

    public bool DT(int[] nums, int index, STATE[] memo) {
        if (index >= nums.Length) return false;
        if (index == nums.Length - 1) return true;
        if (memo[index] != 0) {
            if (memo[index] == STATE.NOT_REACHED) {
                return false;
            } else {
                return true;
            };
        } else {
            int maxJump = nums[index];
            if (maxJump == 0) {
                memo[index] = STATE.NOT_REACHED;
                return false;
            }
            bool reachedTheEnd = false;
            for (int jump = 1; jump <= maxJump; jump++) {
                reachedTheEnd = reachedTheEnd || DT(nums, index + jump, memo); // if any single one of these return true, we should return true, otherwiser return false
                if (reachedTheEnd) break;
            }
            memo[index] = reachedTheEnd ? STATE.REACHED : STATE.NOT_REACHED;
            return reachedTheEnd;
        }

    }
}
