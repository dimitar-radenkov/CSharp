namespace _05.HashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /*
     Implement the data structure "set" in a class 
     * HashedSet<T> using your class HashTable<K,T> 
     * to hold the elements. Implement all 
     * standard set operations like Add(T), Find(T),
     * Remove(T), Count, Clear(), union and intersect.
    */

    class Program
    {
        private static void PrintEnumerable(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.Write(" {0}", item);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            HashedSet<int> set = new HashedSet<int>();
            List<int> collection = new List<int>() { 2, 4, 5 };

            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);

            PrintEnumerable(set);
            Console.WriteLine("Find(10) : {0}", set.Find(10));
            Console.WriteLine("Count : {0}", set.Count);

            var union = set.Union(collection);
            Console.WriteLine("Union : ");
            PrintEnumerable(union);

            var interset = set.Intersect(collection);
            Console.WriteLine("Intersect : ");
            PrintEnumerable(interset);
            
        }
    }
}
