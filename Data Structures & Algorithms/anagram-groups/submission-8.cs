public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
        for (int stringIndex = 0; stringIndex < strs.Length; stringIndex++  ) {
            string currentString = strs[stringIndex];
            char[] charArray = currentString.ToCharArray();
            Array.Sort(charArray);
            string sortedString = new string(charArray);
            if (dict.TryGetValue(sortedString, out List<int> listOfIndexes)) {
                listOfIndexes.Add(stringIndex);
            } else {
                dict[sortedString] = new List<int>();
                dict[sortedString].Add(stringIndex);
            }
        }

        List<List<string>> anagramList = new List<List<string>>();
        foreach(KeyValuePair<string, List<int>> keyValuePair in dict) {
            List<int> indexList = keyValuePair.Value;
            List<string> stringList = new List<string>();
            for (int i = 0; i < indexList.Count; i++) {
                stringList.Add(strs[indexList[i]]);
            }
            anagramList.Add(stringList);
        }
        return anagramList;
    }
}
