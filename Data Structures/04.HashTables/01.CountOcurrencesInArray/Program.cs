namespace _01.CountOcurrencesInArray
{
    using System;
    using System.Collections.Generic;
    /*
     Write a program that counts in a given array of 
     double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
     
    Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    -2.5  2 times
    3  4 times
    4  3 times
*/
    class Program
    {
        static void Main(string[] args)
        {

            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Dictionary<double, int> occurences = new Dictionary<double, int>();

            foreach (var number in array)
            {
                if(occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences.Add(number, 1);
                }
            }
        
            //iterate over dictionary
            foreach (var item in occurences)
            {
                Console.WriteLine("{0} --> {1} time/s", item.Key, item.Value);
            }
        }
    }
}
