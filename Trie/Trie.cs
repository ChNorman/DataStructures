public class TrieNode
{
    public bool IsWord{ get; set; }
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    
}

public class Trie {
    private readonly TrieNode _root;

    public Trie() {
        if (_root == null ){
          _root = new TrieNode();
        }
    }

    public void Insert(string word){
        var node = _root;
        foreach(var c in word){
            if(!node.children.ContainsKey(c))
                node.children[c] = new TrieNode();
            node = node.children[c];

        }

        node.IsWord = true;
    }

    public bool Search(string word){
        var node = _root;
        foreach(var c in word){
            if(!node.children.ContainsKey(c))
                return false;
            node = node.children[c];
        }

        return node.IsWord;
        
    }

    public bool StartsWith(string prefix){
        var node = _root;

        foreach(var c in prefix){
            if(node.children.ContainsKey(c))
                node = node.children[c];
            else  return false;
        }

        return true;

    }
}