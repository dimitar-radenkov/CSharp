namespace _02.UsingToList
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {
        private static void GetEmployees()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var db = new AcademyDB();
            var employees = db.Employees.ToList();

            var addresses =
                (from e in employees
                select e.Address).ToList();

            var towns =
                (from a in addresses
                 select a.Town).ToList();

            var sofiaCities =
                (from t in towns
                where t.Name == "Sofia"
                select t).ToList();

            sw.Stop();
            Console.WriteLine("NOT OPTIMIZED {0} ", sw.Elapsed);
        }

        private static void GetEmployeesOptimized()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var db = new AcademyDB();
            var employees = db.Employees;

            var addresses =
                (from e in employees
                 select e.Address);

            var towns =
                (from a in addresses
                 select a.Town);

            var sofiaCities =
                (from t in towns
                 where t.Name == "Sofia"
                 select t).ToList();

            sw.Stop();
            Console.WriteLine("OPTIMIZED {0} ", sw.Elapsed);
        }

        static void Main(string[] args)
        {
            GetEmployees();
            GetEmployeesOptimized();
        }
    }
}
