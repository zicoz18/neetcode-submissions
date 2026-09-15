public class MinStack {
    // USE TWO STACK, ONE HOLDING THE CURRENT MIN
    LinkedList<int> minStack;
    LinkedList<int> stack;


    public MinStack() {
        minStack = new LinkedList<int>();
        stack = new LinkedList<int>();
    }
    
    public void Push(int val) {
        stack.AddLast(val);
        if (minStack.Count == 0) {
            minStack.AddLast(val);
        } else {
            int currentMin = minStack.Last.Value;
            if (val < currentMin) {
                currentMin = val;
            } 
            minStack.AddLast(currentMin);
        }
    }
    
    public void Pop() {
        stack.RemoveLast();
        minStack.RemoveLast();
    }
    
    public int Top() {
        return stack.Last.Value;
    }
    
    public int GetMin() {
        return minStack.Last.Value;
    }
}
