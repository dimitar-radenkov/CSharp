namespace _01.GetAllEmployees
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            var database = new AcademyDB();
            var employees = database.Employees;

            sw.Start();            
            foreach (var item in employees)
            {
                Console.WriteLine("{0} {1} {2} ",
                    item.FirstName, item.MiddleName, item.LastName);
                Console.WriteLine(item.Department.Name);
                Console.WriteLine(item.Address.Town.Name);
                Console.WriteLine();
            }
            sw.Stop();
            var elapsedTime = sw.Elapsed;

            var employeesOptimized = 
                database.Employees.
                    Include("Department").
                    Include("Address");

            sw.Reset();
            sw.Start();       
            foreach (var item in employeesOptimized)
            {
                Console.WriteLine("{0} {1} {2} ",
                    item.FirstName, item.MiddleName, item.LastName);
                Console.WriteLine(item.Department.Name);
                Console.WriteLine(item.Address.Town.Name);
                Console.WriteLine();
            }
            sw.Stop();
            var elapsedOptimized = sw.Elapsed;

            Console.WriteLine("Without Include()");
            Console.WriteLine("TIME : {0}", elapsedTime.ToString());

            Console.WriteLine("With Include()");
            Console.WriteLine("TIME : {0}", elapsedOptimized.ToString());
        }
    }
}
