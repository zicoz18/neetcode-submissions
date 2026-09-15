public class Solution {
    public bool IsAnagram(string stringOne, string stringTwo) {
        if (stringOne.Length != stringTwo.Length) return false; 
        int stringLength = stringOne.Length;
        Dictionary<char, int> stringOneOccurenceDict = new Dictionary<char, int>();
        Dictionary<char, int> stringTwoOccurenceDict = new Dictionary<char, int>();
        for (int i = 0; i < stringLength; i++) {
            char charOne = stringOne[i];
            char charTwo = stringTwo[i];
            if (!stringOneOccurenceDict.ContainsKey(charOne)) stringOneOccurenceDict[charOne] = 0;
            stringOneOccurenceDict[charOne]++;
            if (!stringTwoOccurenceDict.ContainsKey(charTwo)) stringTwoOccurenceDict[charTwo] = 0;
            stringTwoOccurenceDict[charTwo]++;
        }
        int stringOneKeyCount = stringOneOccurenceDict.Count;
        int stringTwoKeyCount = stringTwoOccurenceDict.Count;
        if (stringOneKeyCount != stringTwoKeyCount) return false;
        foreach (KeyValuePair<char, int> stringOneKeyValuePair in stringOneOccurenceDict) {
            if (stringTwoOccurenceDict.TryGetValue(stringOneKeyValuePair.Key, out int stringTwoValue)){
                if (stringTwoValue != stringOneKeyValuePair.Value) {
                    return false;
                }
            } else {
                return false;
            }
        }
        return true;
    }
}
