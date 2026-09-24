public class Solution {
    int UNSET = -2;
    int INVALID = -1;

    public int Jump(int[] nums) {
        int[] minJumpCountToReach = new int[nums.Length]; 
        for (int i = 0; i < nums.Length; i++) {
            minJumpCountToReach[i] = UNSET;
        }
        DT(nums, minJumpCountToReach, 0, 0);
        return minJumpCountToReach[nums.Length - 1];
    }

    public void DT(int[] nums, int[] minJumpCountToReach, int index, int currentJumpCount) {
        if (index >= nums.Length) {
            return;
        }
        if (index == nums.Length - 1) {
            if (minJumpCountToReach[index] == UNSET || minJumpCountToReach[index] == INVALID) {
                minJumpCountToReach[index] = currentJumpCount;    
            } else {
                minJumpCountToReach[index] = Math.Min(currentJumpCount, minJumpCountToReach[index]);
            }
        }
        if (minJumpCountToReach[index] == UNSET || minJumpCountToReach[index] == INVALID) {
            minJumpCountToReach[index] = currentJumpCount;
        } else {
            return;
            minJumpCountToReach[index] = Math.Min(currentJumpCount, minJumpCountToReach[index]);
            if (currentJumpCount < minJumpCountToReach[index]) {
                currentJumpCount = minJumpCountToReach[index];
                return;
            }
        }
        int maxJump = nums[index];
        if (maxJump == 0) return;
        for (int jump = maxJump; jump >= 1; jump--) {
            DT(nums, minJumpCountToReach, index + jump, currentJumpCount + 1);
        }
    }
}
