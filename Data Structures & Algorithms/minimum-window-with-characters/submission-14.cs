public class Solution {
    // Start at 15:40
    // OOB: Out of bounds
    public string MinWindow(string s, string t) {
        if (t.Length > s.Length) return "";
        // build freqMap for t
        // build freqMap for current window
        // for searching s, left pointer starts at 0, right pointer starts at 0
        // if currentWindow does not include freqMap of t, increment rightPointer (check OOB)
        // if currentWindow does already include freqMap of t, try incrementing leftPointer
        // Oh btw, before incrementing leftPointer, check minSubstring and if length of current one is less than the min one, replace it
        // After leftPointer gets incremeneted, if it still inclides freqMap of f, go ahead and do it again
        // So basically, incremenet leftPointer till it does not include freqMap of t
        Dictionary<char, int> tFreqMap = new Dictionary<char, int>();
        for (int i = 0; i < t.Length; i++) {
            char currentChar = t[i];
            if (tFreqMap.ContainsKey(currentChar)) {
                tFreqMap[currentChar]++;
            } else {
                tFreqMap[currentChar] = 1;
            }
        }

        // string minSubString = s;
        int minSubStringStartingIndex = -1;
        int minSubStringLength = s.Length + 1;
        // bool hasFoundAtLeastOnce = false;

        int leftPointer = 0;
        Dictionary<char, int> windowFreqMap = new Dictionary<char, int>();
        for (int rightPointer = 0; rightPointer < s.Length; rightPointer++) {
            char rightChar = s[rightPointer];
            // Console.WriteLine("LeftPointer: "+ leftPointer);
            // Console.WriteLine("RightPointer: "+ rightPointer);
            if (windowFreqMap.ContainsKey(rightChar)) {
                windowFreqMap[rightChar]++;
            } else {
                windowFreqMap[rightChar] = 1;
            }
            while ((DoesInclude(windowFreqMap, tFreqMap) && leftPointer <= rightPointer)) {
                /*
                Console.WriteLine("LeftPointer: "+ leftPointer);
                Console.WriteLine("RightPointer: "+ rightPointer);
                Console.WriteLine("INCLUDE");
                Console.WriteLine("Window dict");
                LogDict(windowFreqMap);
                Console.WriteLine("TFreq dict");
                LogDict(tFreqMap);
                */
                //if (!hasFoundAtLeastOnce) {
                //    hasFoundAtLeastOnce = true;
                //}
                int currentSubstringLength = rightPointer - leftPointer + 1;
                if (currentSubstringLength < minSubStringLength) {
                    // string currentValidSubstring = s.Substring(leftPointer, currentSubstringLength); 
                    minSubStringLength = currentSubstringLength;
                    minSubStringStartingIndex = leftPointer;
                }
                // move left pointer till it does not include OR it hits rightPoint? 
                char leftChar = s[leftPointer];
                windowFreqMap[leftChar]--;
                leftPointer++;
            }
        }

        if (minSubStringStartingIndex == -1) return "";
        return s.Substring(minSubStringStartingIndex, minSubStringLength);
    }

    public bool DoesInclude(Dictionary<char, int> d1, Dictionary<char, int> d2) {
        foreach (KeyValuePair<char, int> d2KVP in d2) {
            if (!d1.ContainsKey(d2KVP.Key)) return false;
            if (d2KVP.Value > d1[d2KVP.Key]) return false; 
        }
        return true;
    }

/*
    public void LogDict(Dictionary<char, int> d) {
        foreach (KeyValuePair<char, int> dkvp in d) {
            Console.WriteLine("Key: " + dkvp.Key + ", Value: " + dkvp.Value);
        }
    }
*/
}
