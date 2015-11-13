namespace _04.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialSize = 16;

        private const double LoadFactorLimit = 75;

        private LinkedList<KeyValuePair<K, T>>[] array;

        private int count;

        private int CalculateHashcode(K key)
        {
            int hash = key.GetHashCode();
            int arrayPosition = Math.Abs(hash % this.array.Length);

            return arrayPosition;
        }

        private double GetLoadFactor()
        {
            int length = this.array.Length;
            double loadFactor = (double)((count * 100) / length);

            return loadFactor;
        }

        private void PerformDoubleArray()
        {
            var cachedArray = this.array;

            this.array = new LinkedList<KeyValuePair<K, T>>[2 * this.Capacity];

            this.Count = 0;
            foreach (var arrayItem in cachedArray)
            {
                if (arrayItem != null)
                {
                    foreach (var kvItem in arrayItem)
                    {
                        this.Add(kvItem.Key, kvItem.Value);
                    }
                }
            }
        }

        private bool ContainsKey(K key)
        {
            int hash = this.CalculateHashcode(key);
            bool hasKey = this.array[hash].Any(p => p.Key.Equals(key));

            return hasKey;
        }

        private KeyValuePair<K,T> GetPair(K key)
        {
            int hash = this.CalculateHashcode(key);
            var linkedlist = this.array[hash];
            foreach (var pair in linkedlist)
            {
                if (pair.Key.Equals(key))
                {
                    return pair;
                }
            }

            throw new ArgumentException("Not able to find key.");
        }

        public HashTable()
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[InitialSize];
            this.count = 0;
        }

        public int Count 
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public int Capacity
        {
            get { return this.array.Length; }
        }

        public void Add(K key, T value)
        {
            var keyvalue = new KeyValuePair<K, T>(key, value);

            int hash = this.CalculateHashcode(key);

            if (this.array[hash] == null)
            {
                var item = new LinkedList<KeyValuePair<K, T>>();           
                item.AddLast(keyvalue);
                this.array[hash] = item;
            }
            else
            {
                if (this.ContainsKey(key))
                {
                    throw new ArgumentException("Key already exist.");
                }

                this.array[hash].AddLast(keyvalue);
            }
            
            ++this.count;

            if (GetLoadFactor() >= LoadFactorLimit)
            {
                this.PerformDoubleArray();
            } 
        }

        public void Remove(K key)
        {
            int hash = this.CalculateHashcode(key);

            if (this.array[hash] == null)
            {
                throw new ArgumentException("Key doesn't exist.");
            }

            var pair = this.GetPair(key);
            this.array[hash].Remove(pair);

            --this.Count;
        }

        public void Clear()
        {
            this.array = new LinkedList<KeyValuePair<K, T>>[InitialSize];
            this.Count = 0;
        }

        public T Find(K key)
        {
            int hash = this.CalculateHashcode(key);

            if (this.array[hash] == null)
            {
                throw new ArgumentException("Key doesn't exist.");
            }

            var pair = this.GetPair(key);

            return pair.Value;
        }

        public T this[K key]
        {
            get { return this.Find(key); }
            set { this.Add(key, value); }
        }

        public ICollection<K> Keys()
        {
            List<K> keys = new List<K>();
            foreach (var item in this)
            {
                keys.Add(item.Key);
            }

            return keys;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var arrayItem in this.array)
            {
                if (arrayItem != null)
                {
                    foreach (var kvItem in arrayItem)
                    {
                        yield return kvItem;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
