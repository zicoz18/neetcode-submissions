public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        for (int stringIndex = 0; stringIndex < strs.Length; stringIndex++  ) {
            string currentString = strs[stringIndex];
            char[] charArray = currentString.ToCharArray();
            Array.Sort(charArray);
            string sortedString = new string(charArray);
            if (dict.TryGetValue(sortedString, out List<string> listOfStrings)) {
                listOfStrings.Add(currentString);
            } else {
                dict[sortedString] = new List<string>();
                dict[sortedString].Add(currentString);
            }
        }

        List<List<string>> anagramList = new List<List<string>>();
        foreach(KeyValuePair<string, List<string>> keyValuePair in dict) {
            anagramList.Add(keyValuePair.Value);
        }
        return anagramList;
    }
}
