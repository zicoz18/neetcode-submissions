public class Solution {
    public int NumDecodings(string s) {
        Dictionary<int, int> dp = new Dictionary<int, int>();
        dp[s.Length] = 1;
        return DT(0, s, dp);
    }

    public int DT(int i, string s, Dictionary<int, int> dp) {
            if (dp.ContainsKey(i)) {
                return dp[i];
            }
            if (i == s.Length) return 1;
            if (s[i] == '0') return 0;

            int res = DT(i + 1, s, dp);
            if (i < s.Length - 1) {
                if (s[i] == '1' ||
                   (s[i] == '2' && s[i + 1] < '7')) {
                    res += DT(i + 2, s, dp);
                }
            }
            dp[i] =res;
            return res;
        }
}
