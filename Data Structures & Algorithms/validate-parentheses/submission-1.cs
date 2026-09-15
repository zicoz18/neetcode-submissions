public class Solution {
    public bool IsValid(string s) {
        Stack<char> p = new Stack<char>();
        for (int i = 0; i < s.Length; i++){
            char currentChar = s[i];
            if (currentChar == '(' || currentChar == '{' || currentChar == '[') {
                p.Push(currentChar);
            } else {
                // Since it can only consist of 6 chars, we know that current char is a closing one
                bool didPop = p.TryPop(out char poppedChar);
                if (!didPop) return false;
                bool isValid = (currentChar == ')' && poppedChar == '(') || (currentChar == '}' && poppedChar == '{') || (currentChar == ']' && poppedChar == '[');
                if (!isValid) return false; 
            }
        }
        if (p.Count != 0) return false;
        return true; 
    }
}
