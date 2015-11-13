namespace _03.Trie
{
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Add("here should be really long long text...");

            List<string> matches = trie.Match("rea", 5);
        }
    }
}
