public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> results = new List<List<int>>();
        Backtrack(nums, new bool[nums.Length], new List<int>(), results);
        return results;
    }

    public void Backtrack(int[] nums, bool[] isUsed, List<int> currentPermutation, List<List<int>> results) {
        if (currentPermutation.Count == nums.Length) {
            results.Add(currentPermutation.ToList());
            return;
        }
        // bool hasUsedANumber = false;
        for (int i = 0; i < nums.Length; i++) {
            int curNum = nums[i];
            bool isNumUsed = isUsed[i];
            if (!isNumUsed) {
                currentPermutation.Add(curNum);
                // Console.WriteLine(string.Join(", ", currentPermutation)); 
                isUsed[i] = true;
                // hasUsedANumber = true;
                Backtrack(nums, isUsed, currentPermutation, results);
                currentPermutation.RemoveAt(currentPermutation.Count - 1);
                isUsed[i] = false;
            }
        }
        // if (!hasUsedANumber) {
        //     results.Add(currentPermutation);
        // }
    }
}
