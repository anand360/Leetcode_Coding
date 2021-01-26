public class DNSTrie{
    public bool IsLeaf { get; set; }
    public string IpAddress { get; set; }
    public DNSTrie[] Children { get; set; }
}
public class ForwardDNSCache{
    public DNSTrie NewNode(){
        var trie = new DNSTrie();
        trie.IsLeaf = false;
        trie.IpAddress = string.Empty;
        trie.Children = null;

        return trie;
    }

    public void Insert(DNSTrie root, string url, string IpAddress){
        var pcrawl = root;

        for (int i = 0; i < url.Length; i++)
        {
            var index = url[i]-'a';
            if (pcrawl.Children[index] == null)
            {
                pcrawl.Children[index] = NewNode();
            }

            pcrawl = pcrawl.Children[index];
        }

        pcrawl.IsLeaf = true;
        pcrawl.IpAddress = IpAddress;
    }

    public string SearchDNS(DNSTrie root, string url){
        var pcrawl = root;

        for (int i = 0; i < url.Length; i++)
        {
            var index = url[i]-'a';
            if (pcrawl.Children[index] == null)
            {
                return null;
            }

            pcrawl = pcrawl.Children[index];
        }

        if(pcrawl.IsLeaf && pcrawl.Children == null){
            return pcrawl.IpAddress;
        }

        return null;
    }
}