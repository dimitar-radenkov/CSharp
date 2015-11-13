namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private const string ErrorMessage = "Key doesn't exists.";
        private MultiDictionary<K1, T> dictionary1;
        private MultiDictionary<K2, T> dictionary2;

        public BiDictionary()
        {
            this.dictionary1 = new MultiDictionary<K1, T>(true);
            this.dictionary2 = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            this.dictionary1.Add(key1, value);
            this.dictionary2.Add(key2, value);
        }

        public void Remove(K1 key1, K2 key2)
        {
            this.dictionary1.Remove(key1);
            this.dictionary2.Remove(key2);
        }

        public ICollection<T> Find(K1 key)
        {
            if (this.dictionary1.ContainsKey(key))
            {
                return this.dictionary1[key];
            }

            throw new ArgumentException(ErrorMessage);
        }

        public ICollection<T> Find(K2 key)
        {
            if (this.dictionary2.ContainsKey(key))
            {
                return this.dictionary2[key];
            }

            throw new ArgumentException(ErrorMessage);
        }

        public ICollection<T> Find(K1 key1, K2 key2)
        {
            if (this.dictionary1.ContainsKey(key1) && 
                this.dictionary2.ContainsKey(key2))
            {
                var value1 = this.dictionary1[key1];
                var value2 = this.dictionary2[key2];
         
                var set = new Set<T>(value1);
                var set2 = new Set<T>(value2);

                var union = set.Union(set2);

                return union;
            }

            throw new ArgumentException(ErrorMessage);
        }
    }
}
