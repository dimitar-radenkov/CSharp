namespace _04.HashTable
{
    using System;
    using System.Collections.Generic;

    /*Implement the data structure "hash table" in a 
     * class HashTable<K,T>. Keep the data in array 
     * of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[])
     * with initial capacity of 16. When the hash table load 
     * runs over 75%, perform resizing to 2 times larger capacity. 
     * Implement the following methods and properties: Add(key, value),
     * Find(key)value, Remove( key), Count, Clear(), this[], Keys. 
     * Try to make the hash table to support iterating over its elements with foreach.
     */

    class Program
    {
        private static void Print(HashTable<string, int> hashtable)
        {
            foreach (var item in hashtable)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            HashTable<string, int> hashtable = new HashTable<string,int>();

            hashtable.Add("1", 1);
            hashtable.Add("2", 2);
            hashtable.Add("3", 3);
            hashtable.Add("4", 4);
            hashtable.Add("5", 5);
            hashtable.Add("6", 6);
            hashtable.Add("7", 7);
            hashtable.Add("8", 8);
            hashtable.Add("9", 9);
            hashtable.Add("10", 10);
            hashtable.Add("11", 11);
            hashtable.Add("12", 12);
            hashtable.Add("13", 13);

            List<string> keys = (List<string>)hashtable.Keys();
            Console.WriteLine("Keys {0}",string.Join(", ",keys.ToArray()));

            Console.WriteLine("Count {0}", hashtable.Count);
            Print(hashtable);
            hashtable.Remove("1");
            Console.WriteLine("Count after remove element {0}", hashtable.Count);
            Console.WriteLine("Find key 2 : {0}", hashtable.Find("2"));

            hashtable["mitko"] = 25;
            Console.WriteLine("Use [] operator : {0}", hashtable["mitko"]);

            Console.WriteLine("Clear table");
            hashtable.Clear();
            Print(hashtable);          
        }
    }
}
