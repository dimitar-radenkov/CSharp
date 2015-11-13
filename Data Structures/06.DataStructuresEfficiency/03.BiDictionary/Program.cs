namespace _03.BiDictionary
{
    using System;

    /*
     * 
     * Implement a class BiDictionary<K1,K2,T> that allows
     * adding triples {key1, key2, value} and fast search
     * by key1, key2 or by both key1 and key2. Note: 
     * multiple values can be stored for given key.
     * 
     * */
    class Program
    {
        static void Main(string[] args)
        {
            var biDictionary = new BiDictionary<string, int, decimal>();

            biDictionary.Add("mitko", 5, 10);
            biDictionary.Add("mitko", 11, 10);
            biDictionary.Add("pesho", 5, 20);

            var value = biDictionary.Find(5);

            Console.WriteLine(biDictionary.Find(5));
            Console.WriteLine(biDictionary.Find("mitko", 5));
            Console.WriteLine(biDictionary.Find(11));

        }
    }
}
