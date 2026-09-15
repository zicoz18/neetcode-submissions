public class Solution {

    List<List<int>> res = new List<List<int>>();

    public void backtrack(int i, List<int> cur, int total, int[] nums, int target) {
        if (total == target) {
            res.Add(cur.ToList());
            return;
        }
        if (total > target || i >= nums.Length) return;

        cur.Add(nums[i]);
        backtrack(i , cur, total + nums[i], nums, target);
        cur.Remove(cur.Last());
        backtrack(i + 1, cur, total, nums, target);
    }



    public List<List<int>> CombinationSum(int[] nums, int target) {
        backtrack(0, new List<int>(), 0, nums, target);
        return res;
    }
}
