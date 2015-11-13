namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    /*
    A text file students.txt holds information 
     * about students and their courses in the 
     * following format:

    Kiril  | Ivanov   | C#
    Stefka | Nikolova | SQL
    Stela  | Mineva   | Java
    Milena | Petrova  | C#
    Ivan   | Grigorov | C#
    Ivan   | Kolev    | SQL


	Using SortedDictionary<K,T> print the 
     * courses in alphabetical order and for 
     * each of them prints the students 
     * ordered by family and then by name:
     * 
    
    C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    Java: Stela Mineva
    SQL: Ivan Kolev, Stefka Nikolova

    */

    class Program
    {  
        private const int FIRSTNAME = 0;
        private const int LASTNAME = 1;
        private const int COURSE = 2;

        private static string FilePath = "../../files/students.txt";

        static SortedDictionary<string, SortedSet<Student>> studentsList =
            new SortedDictionary<string, SortedSet<Student>>();

        private static void LoadData()
        {
            var reader = new StreamReader(FilePath);
            using (reader)
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var parsedLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string course = parsedLine[COURSE].Trim();
                    var student = new Student(
                        parsedLine[FIRSTNAME].Trim(), 
                        parsedLine[LASTNAME].Trim());

                    if (!studentsList.ContainsKey(course))
                    {
                        studentsList[course] = new SortedSet<Student>(new StudnetComparer()) { student };
                    }
                    else
                    {
                        studentsList[course].Add(student);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            LoadData();

            foreach (var item in studentsList)
            {
                Console.WriteLine("{0} : {1}",
                    item.Key, string.Join(", ", item.Value));
            } 
        }
    }
}
