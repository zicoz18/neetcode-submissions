public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0) return 0;
        Dictionary<char, int> charFreq = new Dictionary<char, int>();
        int maxSubStringLen = 0;
        int leftPointer = 0;
        int rightPointer = 0;
        // int currentSubstringLen = 0;
        while (rightPointer != s.Length) {
            char rightChar = s[rightPointer];
            if (charFreq.ContainsKey(rightChar) && charFreq[rightChar] != 0) {
                charFreq[rightChar]++;
                // currentSubstringLen++;
                while (charFreq[rightChar] != 1) {
                    char leftChar = s[leftPointer];
                    charFreq[leftChar]--;
                    // currentSubstringLen--;
                    leftPointer++;
                } 
            } else {
                charFreq[rightChar] = 1;
                // currentSubstringLen++;
            }
            int currentSubLen = rightPointer - leftPointer + 1;
            if (currentSubLen > maxSubStringLen) {
                maxSubStringLen = currentSubLen;
            }
            rightPointer++;
        }
        return maxSubStringLen;
    }
}
