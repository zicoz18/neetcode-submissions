public class Solution {
    public string LongestPalindrome(string s) {
        // Well, first thing that comes to my mind is using pointers like
        // longest palindrome could be the whole string and it can be represented as one pointer for palindrome's middle and then one variable to hold one side length of it
        // So, if abbba is the string, the longest palindrome would be the whole string 
        // We would describe that palindrome as: pointer = 2, oneSideLength = 2, so it includes 
        // [pointer - oneSideLength, pointer + oneSideLength];
        // Well, I guess that was a wrong way to think about it, cause the middle of the palindrom can technically be the in between of two chars, so like "aa"'s pointer is neither 0 nor 1, its 0.5 and oneSideLength is 1, but it makes it weird now. So, lets just have leftPointer and rightPointer to represent a palindrom
        // What I can do is, start from the middle of ths string, check the max len I can get from there and then move both ways to try to find a shorter one
        // But I believe this is not DP, so probably there is another approach I should find
        // Maybe, question is, can we extend the palindrom by adding a new char to the string

        int longestPalindromeLeftPointer = -1;
        int longestPalindfromRightPointer = -1;
        int longestPalindromeLength = 0;

        for (int palindromMiddle = 0; palindromMiddle < s.Length; palindromMiddle++) {
            {
                int leftPointer = palindromMiddle;
                int rightPointer = palindromMiddle;
                while (leftPointer - 1 >= 0 && rightPointer + 1 < s.Length) {
                    if (s[leftPointer - 1] == s[rightPointer + 1]) {
                        leftPointer--;
                        rightPointer++;
                    } else {
                        break;
                    }
                }
                int currentPalindromeLength = rightPointer - leftPointer + 1;
                if (currentPalindromeLength > longestPalindromeLength) {
                    longestPalindromeLength = currentPalindromeLength;
                    longestPalindromeLeftPointer = leftPointer;
                    longestPalindfromRightPointer = rightPointer;
                }
            }

            {
                if (palindromMiddle == 0) continue;
                int leftPointer = palindromMiddle - 1;
                int rightPointer = palindromMiddle;
                if (s[leftPointer] != s[rightPointer]) continue;
                while (leftPointer - 1 >= 0 && rightPointer + 1 < s.Length) {
                    if (s[leftPointer - 1] == s[rightPointer + 1]) {
                        leftPointer--;
                        rightPointer++;
                    } else {
                        break;
                    }
                }
                int currentPalindromeLength = rightPointer - leftPointer + 1;
                if (currentPalindromeLength > longestPalindromeLength) {
                    longestPalindromeLength = currentPalindromeLength;
                    longestPalindromeLeftPointer = leftPointer;
                    longestPalindfromRightPointer = rightPointer;
                }
            }
        }

        return s.Substring(longestPalindromeLeftPointer, longestPalindromeLength);
    }
}
