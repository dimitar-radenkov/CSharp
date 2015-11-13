namespace _02.ExtractOddOccurences
{
    using System;
    using System.Collections.Generic;

    /*
     Write a program that extracts from a given sequence 
     of strings all elements that present in it odd 
     number of times. Example:
     
    {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

     
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Dictionary<string, int> occurences = new Dictionary<string, int>();
            foreach (var number in array)
            {
                if (occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences.Add(number, 1);
                }
            }

            //iterate over dictionary
            Console.Write("{ ");
            foreach (var item in occurences)
            {       
                if (item.Value % 2 != 0)
                {
                    Console.Write(" {0} ", item.Key);
                }
            }
            Console.WriteLine(" }");
        }
    }
}
