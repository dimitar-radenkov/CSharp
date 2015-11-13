namespace _05.HashedSet
{
    using _04.HashTable;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, T> hashtable;

        public int Count
        {
            get { return this.hashtable.Count; }
        }

        public HashedSet()
        {
            this.hashtable = new HashTable<T, T>();
        }

        public void Add(T value)
        {
            try
            {
                this.hashtable.Add(value, value);
            }
            catch (ArgumentException)
            {
                //key already exist. DO NOTHING...
            }
        }

        public bool Find(T value)
        {
            try
            {
                var item = this.hashtable.Find(value);
                return item != null;
            }
            catch (ArgumentException)
            {
                return false;
            }   
        }

        public void Remove(T value)
        {
            this.hashtable.Remove(value);
        }

        public void Clear()
        {
            this.hashtable.Clear();
        }

        public ICollection<T> Union(ICollection<T> collection)
        {
            List<T> union = new List<T>();
            foreach (var item in hashtable)
            {
                union.Add(item.Key);
            }

            foreach (var item in collection)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                }
            }

            return union;
        }

        public ICollection<T> Intersect(ICollection<T> collection)
        {
            List<T> intersect = new List<T>();
            foreach (var item in hashtable)
            {
                if (collection.Contains(item.Key))
                {
                    intersect.Add(item.Key);
                }
            }

            return intersect;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.hashtable)
            {
                yield return item.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
