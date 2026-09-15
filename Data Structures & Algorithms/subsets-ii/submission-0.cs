public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        List<List<int>> results = new List<List<int>>();
        BT(0, nums, new List<int>(),results);
        return results;
    }

    public void BT(int index, int[] nums, List<int> currentSet, List<List<int>> results) {
        if (index == nums.Length) {
            results.Add(new List<int>(currentSet));
            return;
        }
        int currentValue = nums[index];
        currentSet.Add(currentValue);
        BT(index + 1, nums, currentSet, results);
        currentSet.RemoveAt(currentSet.Count - 1);
        while (index + 1 < nums.Length && nums[index] == nums[index + 1]) {
            index++;
        }
        BT(index + 1, nums, currentSet, results);
    }
}
