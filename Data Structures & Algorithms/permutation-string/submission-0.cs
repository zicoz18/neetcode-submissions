public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        // What I am thinking is, we gotta have a sliding window inside s2 with the size of s1.Length
        // We should create a freq map from s1
        // We should have a freq map for the sliding window as well
        // If we ever find out that freq map of sliding window is same as freq map of s1, then we should return true
        // If they are not the same, we push the sliding window once and decrement the freq of left char and incremenet the freq of right char
        // In this case, building s1 freq map is O(s1.Length)
        // Building freq map inside s2 is O(s2.Length) 
        // But if we check map equalness (O(s1.Length)) with each window then our total time would be O(s1.Length * s2.Length)

        // Build s1 freq map in s1.Length time
        Dictionary<char, int> s1Freq = new Dictionary<char, int>();
        for (int i = 0; i < s1.Length; i++) {
            char currentChar = s1[i];
            if (s1Freq.ContainsKey(currentChar)) {
                s1Freq[currentChar]++;
            } else {
                s1Freq[currentChar] = 1;
            }
        }
        Console.WriteLine("S1 freq dict: ");
        LogDict(s1Freq);


        int windowSize = s1.Length;

        Dictionary<char, int> s2WindowFreq = new Dictionary<char, int>();
        for (int i = 0; i < windowSize; i++) {
            char currentChar = s2[i];
            if (s2WindowFreq.ContainsKey(currentChar)) {
                s2WindowFreq[currentChar]++;
            } else {
                s2WindowFreq[currentChar] = 1;
            }
        }
        Console.WriteLine("Initially built S2 freq dict: ");
        LogDict(s2WindowFreq);
        if (areDictsSame(s1Freq, s2WindowFreq)) return true; 

        for (int windowLeftPointer = 1; windowLeftPointer < s2.Length - windowSize + 1; windowLeftPointer++) {
            // Remove char
            int removedIndex = windowLeftPointer - 1;
            char removedChar = s2[removedIndex];
            s2WindowFreq[removedChar]--;
            // Add new char
            int addedIndex = windowLeftPointer + windowSize - 1; // TODO:
            char addedChar = s2[addedIndex];
            if (s2WindowFreq.ContainsKey(addedChar)) {
                s2WindowFreq[addedChar]++;
            } else {
                s2WindowFreq[addedChar] = 1;
            }
            // Check if dicts are same
            Console.WriteLine("S2 freq dict after applying for index " + windowLeftPointer);
            LogDict(s2WindowFreq);
            if (areDictsSame(s1Freq, s2WindowFreq)) return true; 
        }
        return false;
    }

    public bool areDictsSame(Dictionary<char, int> d1, Dictionary<char, int> d2) {
        foreach (KeyValuePair<char, int> d1Pair in d1) {
            if (!d2.ContainsKey(d1Pair.Key)) return false;
            if (d2[d1Pair.Key] != d1Pair.Value) return false;
        }
        return true;
    }

    public void LogDict(Dictionary<char, int> d1) {
        foreach (KeyValuePair<char, int> d1Pair in d1) {
            Console.WriteLine("Key: " + d1Pair.Key + ", Value: " + d1Pair.Value);
        }
    }
}
