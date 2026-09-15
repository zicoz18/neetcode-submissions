public class WordDictionary {
    public class Trie {
        public Dictionary<char, Trie> children;

        public Trie() {
            children = new Dictionary<char, Trie>();
        }
    }

    Trie root;
    char ENDING_CHAR = '*';
    char SEARCH_CHAR = '.';

    public WordDictionary() {
        root = new Trie();
    }
    
    public void AddWord(string word) {
        Trie currentNode = root;
        foreach (char c in word) {
            if (currentNode.children.TryGetValue(c, out Trie nextNode)) {
                currentNode = nextNode;
            } else {
                currentNode.children[c] = new Trie();
                currentNode = currentNode.children[c];
            }
        }
        currentNode.children[ENDING_CHAR] = new Trie();
    }
    
    public bool Search(string word) {
        Trie currentNode = root;
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (c == SEARCH_CHAR) {
                return AnySearch(currentNode, word, i);
            } else {
                if (currentNode.children.TryGetValue(c, out Trie nextNode)) {
                    currentNode = nextNode;
                } else {
                    return false;
                }
            }
        }
        if (currentNode.children.TryGetValue(ENDING_CHAR, out Trie _)) return true;
        return false;
    }

    public bool AnySearch(Trie currentNode, string word, int index) {
        // Console.WriteLine("Called AnySearch with: word: " + word + ", at index: " + index);
        bool[] search = new bool[27];
        bool hasAny = false;
        while (index < word.Length) {
            char c = word[index];
            if (c == SEARCH_CHAR) {
                // Console.WriteLine("looking for a search withing these chars: "+ string.Join(", ", currentNode.children.Keys));
                foreach (char key in currentNode.children.Keys) {
                    if (key == ENDING_CHAR) continue;
                    if (currentNode.children.TryGetValue(key, out Trie nextNode)) {
                        hasAny = true;
                        // Console.WriteLine("char: " + key + ", c - 'a': " + (key - 'a'));
                        bool found = AnySearch(nextNode, word, index + 1);
                        // Console.WriteLine("result of (char: " + key + ", c - 'a': " + (key - 'a') + "): "+ found);
                        search[key - 'a'] = found;
                        // Console.WriteLine("search[]: " + string.Join(", ", search));
         
                    }
                }
                foreach (bool b in search) {
                    if (b) return true;
                }
                return false;
                return false;
            } else {
                if (currentNode.children.TryGetValue(c, out Trie nextNode)) {
                    currentNode = nextNode;
                } else {
                    return false;
                }
            }
            index++;
        }
        // Console.WriteLine("At the end of the word");
        if (currentNode.children.TryGetValue(ENDING_CHAR, out Trie _)) {
            if (!hasAny) return true;
            foreach (bool b in search) {
                if (b) return true;
            }
        }
        return false;
    }
}
