public class Solution {
    struct MissingValueAndIndex {
        public int missingValue;
        public int index;
    };
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, MissingValueAndIndex> valueToMissingValueAndIndexDict = new Dictionary<int, MissingValueAndIndex>();
        for (int i = 0; i < nums.Length; i++) {
            int value = nums[i];
            int missingValue = target - value;
            if (valueToMissingValueAndIndexDict.TryGetValue(missingValue, out MissingValueAndIndex val)) {
                return new int[2] {val.index, i};
            }
            valueToMissingValueAndIndexDict[value] = new MissingValueAndIndex {missingValue = missingValue, index = i};
        }
        return new int[2] {-1, -1};
    }
}
