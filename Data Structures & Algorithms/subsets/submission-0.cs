public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        Rec(nums, 0, new List<int>(), result);
        return result;
    }

    private void Rec(int[] nums, int start, List<int> current, List<List<int>> result) {
        result.Add(new List<int>(current));          // snapshot, not reference

        for (int i = start; i < nums.Length; i++) {
            current.Add(nums[i]);
            Rec(nums, i + 1, current, result);        // i + 1, never revisit
            current.RemoveAt(current.Count - 1);      // backtrack
        }
    }
}