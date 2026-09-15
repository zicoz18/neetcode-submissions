public class Solution {
    public int FindDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            bool isAdded = set.Add(currentNum);
            if (!isAdded) return currentNum;
        }
        return -1;
    }
}
