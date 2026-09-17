public class Solution {
    public int CountSubstrings(string s) {
        int palindromeCounter = 0;
        for (int palindromMiddle = 0; palindromMiddle < s.Length; palindromMiddle++) {
            {
                int leftPointer = palindromMiddle;
                int rightPointer = palindromMiddle;
                palindromeCounter++;
                while (leftPointer - 1 >= 0 && rightPointer + 1 < s.Length) {
                    if (s[leftPointer - 1] == s[rightPointer + 1]) {
                        leftPointer--;
                        rightPointer++;
                        palindromeCounter++;
                    } else {
                        break;
                    }
                }
            }

            {
                if (palindromMiddle == 0) continue;
                int leftPointer = palindromMiddle - 1;
                int rightPointer = palindromMiddle;
                if (s[leftPointer] != s[rightPointer]) continue;
                palindromeCounter++;
                while (leftPointer - 1 >= 0 && rightPointer + 1 < s.Length) {
                    if (s[leftPointer - 1] == s[rightPointer + 1]) {
                        leftPointer--;
                        rightPointer++;
                        palindromeCounter++;
                    } else {
                        break;
                    }
                }
            }
        }
        return palindromeCounter;
    }
}
