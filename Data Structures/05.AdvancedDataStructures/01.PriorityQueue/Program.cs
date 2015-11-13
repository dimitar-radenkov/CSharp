namespace _01.PriorityQueue
{
    using System;

    /*Implement a class PriorityQueue<T> based 
      on the data structure "binary heap".
    */
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Insert(1);
            queue.Insert(11);
            queue.Insert(22);
            queue.Insert(5);

            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Pop());
        }
    }
}
