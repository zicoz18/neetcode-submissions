public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        Stack<int[]> stack = new Stack<int[]>(); // pair: [temp, index]
        stack.Push(new int [] {temperatures[0], 0});
        int[] result = new int[temperatures.Length];
        for (int i = 1; i < temperatures.Length; i++) {
            int currentTemp = temperatures[i];
            int peekTemp = stack.Peek()[0];
            while(currentTemp > peekTemp && stack.Count != 0) {
                int[] popped = stack.Pop();
                result[popped[1]] = i - popped[1];
                if (stack.TryPeek(out int[] tryPeekTemp)) {
                    peekTemp = tryPeekTemp[0];
                }
            }
            stack.Push(new int[] {currentTemp, i});
        }
        return result;
    }
}
