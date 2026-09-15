public class Solution {
    public int EvalRPN(string[] tokens) {
        // My thinking is that this is similar to assembly code right?
        // Like in EVM, its a stack based VM that pushed values on top of the stack and operands tend to pop values to use
        // This seems pretty similar to that idea
        // So, what I do plan to do is, iterate through the tokens,
        // For each element, if its just a value, push it on top of the stack
        // If it is an operand, pop top 2 values to be used for this operation and push the result on top of the stack
        // As a result, I should have the final result as the one and only value on the stack
        // Btw, I am not specifically handling the case where divider is 0, cause it was not mentioned, like should I throw an error? I am not so sure, so I will assume arithmetic errors are enough
        // Since, my solution will iterate throught the array, and do potentially operate 1-3 stack operations per element, I can call it O(N) time and O(logN) space? as we 
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < tokens.Length; i++) {
            string currentToken = tokens[i];
            if (int.TryParse(currentToken, out int number)) {
                stack.Push(number);
            } else {
                // Since we were unable to parse the string value to be an int, we are sure that this is an operator
                // I assume the reverse polish notation is valid in the sense that it does not place an operator without defining two operands, which is probably just the definition as well
                int num0 = stack.Pop();
                int num1 = stack.Pop();
                int resultNum;
                if (currentToken == "+") {
                    resultNum = num1 + num0;
                } else if (currentToken == "-") {
                    resultNum = num1 - num0;
                } else if (currentToken == "*") {
                    resultNum = num1 * num0;
                } else {
                    // What if num0 is 0?
                    resultNum = num1 / num0;
                }
                stack.Push(resultNum);
            }
        }
        int result = stack.Pop();
        return result;

    }
}
