public class PrefixTree {
    public class Trie {
        public Dictionary<char, Trie> map;

        public Trie() {
            map = new Dictionary<char, Trie>();
        }
    }
    // Lower case english letter count = 26
    // We will have a special character * for defining a word is registered that ends at that point
    // So, like since its saying Trie, I am imagining nested maps
    // With all maps having 27 keys, and to check if a word exists, we would go through the maps using characters and at the end require that * is initialized
    // For contains, its even easier, we do try to go till the end and if we can, there is some word that starts with it
    // When it comes to insert, for each char, we will check if a value exists for the char, if not create a map for that char and go into it with the next char. At the end, we will set some value for the * char as well
    Trie trie;
    char FINISHING_CHAR = '*';

    public PrefixTree() {
        trie = new Trie();
    }
    
    public void Insert(string word) {
        if (word.Length == 0) return;
        Trie node = trie;
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (node.map.TryGetValue(c, out Trie nestedNode)) {
                node = nestedNode;
            } else {
                node.map[c] = new Trie();
                node = node.map[c];
            }
        }
        if (!node.map.TryGetValue(FINISHING_CHAR, out Trie _))  {
            node.map[FINISHING_CHAR] = new Trie();
        }
    }
    
    public bool Search(string word) {
        if (word.Length == 0) return true;
        Trie node = trie;
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (node.map.TryGetValue(c, out Trie nestedNode)) {
                node = nestedNode;
            } else {
                return false;
            }
        }
        if (node.map.TryGetValue(FINISHING_CHAR, out Trie _)) {
            return true;
        }
        return false;
    }
    
    public bool StartsWith(string prefix) {
        if (prefix.Length == 0) return true;
        Trie node = trie;
        for (int i = 0; i < prefix.Length; i++) {
            char c = prefix[i];
            if (node.map.TryGetValue(c, out Trie nestedNode)) {
                node = nestedNode;
            } else {
                return false;
            }
        }
        return true;
    }
}
