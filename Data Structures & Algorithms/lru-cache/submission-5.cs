public class LRUCache {
    private struct Update {
        public int key;
        public int val;
    }

    private int _capacity;
    private Dictionary<int, LinkedListNode<Update>> map;
    private LinkedList<Update> list;

    public LRUCache(int capacity) {
        map = new Dictionary<int, LinkedListNode<Update>>();
        list = new LinkedList<Update>();
        _capacity = capacity;
    }
    
    public int Get(int key) {
        // Console.WriteLine("Trying to get value for key: " + key);
        if (map.TryGetValue(key, out LinkedListNode<Update> updateNode) && updateNode != null) {
            // Console.WriteLine("Found value for key: " + key + ", value: " + updateNode.Value.val + ", so removing it from list and readding it");
            list.Remove(updateNode);
            list.AddLast(updateNode);
            return updateNode.Value.val;
        } else { 
            // Console.WriteLine("No value found for key: " + key);
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        LinkedListNode<Update> updateNode = new LinkedListNode<Update>(new Update{ key = key, val = value});
        // Console.WriteLine("Trying to put value for key: " + key + ", with value: " + value);
        if (map.TryGetValue(key, out LinkedListNode<Update> prevUpdateNode) && prevUpdateNode != null) {
            // Console.WriteLine("There was already a value for the key: " + prevUpdateNode.Value.val + ", so removing it from the list and adding the new update");
            list.Remove(prevUpdateNode);
            list.AddLast(updateNode);
            map[key] = updateNode;
        } else {
            // Console.WriteLine("There was no value for the key: " + key + ", so created a new node and added to the last of the list and updated the map to reference that ndoe");
            list.AddLast(updateNode);
            map[key] = list.Last;
            if (list.Count > _capacity) {
                LinkedListNode<Update> removedUpdateNode = list.First;
                // Console.WriteLine("Oops, looks like capacity exceeded, so gotta remove the first and null the reference for its key in the map, removed key: " + removedUpdateNode.Value.key + ", value: " + removedUpdateNode.Value.val);
                list.RemoveFirst();
                // I guess the Get() method would call `TryGetValue` and this would return null? Not sure about how it works
                map[removedUpdateNode.Value.key] = null;
            } 
        }
    }
}
