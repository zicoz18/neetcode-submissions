public class Solution {
    public bool IsPalindrome(string s) {
        int leftPointer = 0;
        int rightPointer = s.Length - 1;
        while (leftPointer < rightPointer) {
            char leftChar = char.ToLower(s[leftPointer]);
            char rightChar = char.ToLower(s[rightPointer]);
            if (!IsAlphanumeric(leftChar)) {
                leftPointer++;
                continue;
            } 
            if (!IsAlphanumeric(rightChar)) {
                rightPointer--;
                continue;
            }
            if (leftChar != rightChar) {
                return false;
            }
            leftPointer++;
            rightPointer--;
        }
        return true;
    }

    public bool IsAlphanumeric(char c) {
        return char.IsLetterOrDigit(c); 
    }
}
