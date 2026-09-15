public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        // My intuition is we iterate the array, create like buckets for each character and for how many times they appear
        // After that, we try to process the task with highest count (to easily access this should we have a heap?) (Maybe not, as we will have to potentially try out n elements as the highest counts might not be able to processed)
        // After that, we have to process a new one, yet we cant process the one we have just processed, so we should have some kind of memory data structure to hold the latest n processed values
        // What we can do is, as we start processing the task, we put that in a queue and after we finish it we remove an element from the queue and as a result, we would have previous 3 elements processed and before trying to process the most frequent task, we can check if its already in the queue, if so, we are not allowed to process it so try the next one
        // Well, checking if something is in queue would cost O(n) each time, so maybe we can combine the linked list with a map? 
        // So like, when we add an element to the queue, we increment it's value inside the map, when we dequeue, we decrement it's value inside the map, as a result, map is holding the occurence data of queue in its memory, and allows us O(1) look ups for given characters, I believe this is great 
        // Hmmm we will actually have a max heap, and when we start processing we will remove that value from the heap, as it cant be processed and when we do the dequeue, we check if map has no longer that value, if there are none, we add this value back to the heap. But we gotta make sure that we add a version where it gets decremented, how can I handle that? 

        // Okay, this might be able to solve it, yet I am not sure if this will be efficient. Actually, lets start by solving it and then if there are problems related to that, we can think about that part. First, make it work, then make it great
        Dictionary<char, int> taskOccurenceMap = new Dictionary<char, int>();
        int uniqueCharCount = 0;
        for (int i = 0; i < tasks.Length; i++) {
            char currentTask = tasks[i];
            if (taskOccurenceMap.TryGetValue(currentTask, out int occurence))
            {
                taskOccurenceMap[currentTask] = occurence + 1;
            } else {
                taskOccurenceMap[currentTask] = 1;
                uniqueCharCount++;
            }
        }
        (char, int)[] maxHeapInitArr = new (char,int)[uniqueCharCount];
        int index = 0;
        foreach (KeyValuePair<char, int> kvPair in taskOccurenceMap) {
            maxHeapInitArr[index] = (kvPair.Key, kvPair.Value);
            index++;
        }

        PriorityQueue<char, int> maxHeap = new PriorityQueue<char, int>(maxHeapInitArr, Comparer<int>.Create((x, y) => y.CompareTo(x)));
        Queue<char> recentlyProcessedQueue = new Queue<char>();
        // Dictionary<char, int> recentlyProcessFrequenceMap = new Dictionary<char, int>();

        int capacity = n;
        int charProcessCount = 0;
        int accIdleProcessCount = 0;
        int idleProcessCount = 0;
        char idleProcessingChar = '*';
        char emptyChar = '-';
        bool hasReenteredHeap = false;

        while(charProcessCount < tasks.Length) {
            while(maxHeap.Count > 0) {
                hasReenteredHeap = true;
                accIdleProcessCount += idleProcessCount;
                idleProcessCount= 0;
                // TODO: Update the heap, to store the prioirty value inside the element
                char charToProcess = maxHeap.Dequeue(); // should get its priority to be able to decrement it
                taskOccurenceMap[charToProcess]--;
                // ADD IT TO PROCESSING DATA
                recentlyProcessedQueue.Enqueue(charToProcess);
                /*
                if (recentlyProcessFrequenceMap.TryGetValue(charToProcess, out inProcessCount)) {
                    recentlyProcessFrequenceMap[charToProcess] = inProcessCount + 1;
                } else {
                    recentlyProcessFrequenceMap[charToProcess] = 1;
                }
                */

                // CONSIDER THE PROCESSING IT DONE FOR THIS 
                char charThatCanBeReprocessed1 = emptyChar;
                if (recentlyProcessedQueue.Count == capacity + 1) {
                    charThatCanBeReprocessed1 = recentlyProcessedQueue.Dequeue();
                    // recentlyProcessFrequenceMap[charThatCanBeReprocessed1]--;
                }
                if (charThatCanBeReprocessed1 != emptyChar && charThatCanBeReprocessed1 != idleProcessingChar) {
                    if (taskOccurenceMap[charThatCanBeReprocessed1] != 0) {
                        maxHeap.Enqueue(charThatCanBeReprocessed1, taskOccurenceMap[charThatCanBeReprocessed1]);
                    }
                }
                charProcessCount++;
                // Console.WriteLine("Processed: " + charToProcess);
            } 
            // Console.WriteLine("Processing idle");
            char idleCharToProcess = idleProcessingChar;
            // Console.WriteLine("idle char to process: " + idleCharToProcess);
            // Console.WriteLine("Added idle char to the process queue");
            recentlyProcessedQueue.Enqueue(idleCharToProcess);
            char charThatCanBeReprocessed0 = emptyChar;
            if (recentlyProcessedQueue.Count == capacity + 1) {
                // Console.WriteLine("Queue is out of capacity, so dequeuing...");
                charThatCanBeReprocessed0 = recentlyProcessedQueue.Dequeue();
                // recentlyProcessFrequenceMap[charThatCanBeReprocessed0]--;
            }
            // Console.WriteLine("Whether dequeued or not, we hae this char: " + charThatCanBeReprocessed0);
            if (charThatCanBeReprocessed0 != emptyChar && charThatCanBeReprocessed0 != idleProcessingChar) {
                // Console.WriteLine("Since its not empty or idle, we gotta check if there are remaining processes: " + charThatCanBeReprocessed0);
                if (taskOccurenceMap[charThatCanBeReprocessed0] != 0) {
                    // Console.WriteLine("Yeap there was, gotta process it more times: " + taskOccurenceMap[charThatCanBeReprocessed0]);
                    maxHeap.Enqueue(charThatCanBeReprocessed0, taskOccurenceMap[charThatCanBeReprocessed0]);
                }
            }
            // Console.WriteLine("Processed IDLE");
            idleProcessCount++;
            hasReenteredHeap = false;
        }

        return charProcessCount + accIdleProcessCount + (hasReenteredHeap ? idleProcessCount : 0);

        // TRY processing idle for N rounds and reenter the while loop, if we cant enter then its done for sure





    }
}
