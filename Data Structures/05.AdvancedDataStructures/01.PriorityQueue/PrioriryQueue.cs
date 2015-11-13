namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
    {
        private const int InitialSize = 4;
        private T[] array;
        private int size = 0;
        private Comparison<T> comparison;

        public PriorityQueue()
            : this(InitialSize, null)
        {
        }

        public PriorityQueue(Comparison<T> comparison)
            : this(InitialSize, comparison)
        {
        }

        public PriorityQueue(int capacity)
            : this(capacity, null)
        {
        }

        public PriorityQueue(int capacity, Comparison<T> comparison)
        {
            this.array = new T[capacity];
            this.comparison = comparison;

            if (comparison == null)
            {
                this.comparison = new Comparison<T>(Comparer<T>.Default.Compare);
            }
        }

        public int Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        ///
        /// Add an item to the heap
        ///
        public void Insert(T item)
        {
            if (size == array.Length)
            {
                this.Resize();
            }

            this.array[size] = item;

            //set this to UP if you want max heap
            this.HeapifyDown(size);
            this.size++;
        }

        ///
        /// Get the item of the root
        ///
        public T Peak()
        {
            return this.array[0];
        }

        ///
        /// Extract the item of the root
        ///
        public T Pop()
        {
            T item = this.array[0];
            this.size--;
            this.array[0] = this.array[size];

            //set this to DOWN if you want max heap
            this.HeapifyUp(0);
            return item;
        }

        private void Resize()
        {
            T[] resizedData = new T[array.Length * 2];
            Array.Copy(array, 0, resizedData, 0, array.Length);
            this.array = resizedData;
        }

        private void HeapifyUp(int childIdx)
        {
            if (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (this.comparison.Invoke(this.array[childIdx], this.array[parentIdx]) > 0)
                {
                    // swap parent and child
                    T t = this.array[parentIdx];
                    this.array[parentIdx] = this.array[childIdx];
                    this.array[childIdx] = t;
                    this.HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            int leftChildIdx = 2 * parentIdx + 1;
            int rightChildIdx = leftChildIdx + 1;
            int largestChildIdx = parentIdx;
            if (leftChildIdx < this.size && this.comparison.Invoke(this.array[leftChildIdx], this.array[largestChildIdx]) > 0)
            {
                largestChildIdx = leftChildIdx;
            }
            if (rightChildIdx < this.size && this.comparison.Invoke(this.array[rightChildIdx], this.array[largestChildIdx]) > 0)
            {
                largestChildIdx = rightChildIdx;
            }
            if (largestChildIdx != parentIdx)
            {
                T t = this.array[parentIdx];
                this.array[parentIdx] = this.array[largestChildIdx];
                this.array[largestChildIdx] = t;
                HeapifyDown(largestChildIdx);
            }
        }
    }
}
