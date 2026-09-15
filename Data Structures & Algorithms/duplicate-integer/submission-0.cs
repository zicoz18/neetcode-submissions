public class Solution {
    public bool hasDuplicate(int[] nums) {
        Dictionary<int, bool> hasSeenDictionary = new Dictionary<int, bool>();
        for (int i = 0; i < nums.Length; i++) {
            int currentValue = nums[i];
            if (hasSeenDictionary.ContainsKey(currentValue)) {
                return true;
            }
            hasSeenDictionary[currentValue] = true;
        }
        return false;
    }
}