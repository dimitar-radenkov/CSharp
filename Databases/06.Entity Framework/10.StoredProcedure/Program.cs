
namespace _10.StoredProcedure
{
    using _01.EntityFramework;
    using System;
    using System.Data.SqlClient;


    class Program
    {
        static DateTime Start = new DateTime(1997, 1, 1);
        static DateTime End = new DateTime(1999, 1, 1);
        static string CompanyName = "Wilman Kala";

        static void Main(string[] args)
        {
            NorthwindEntities entities = new NorthwindEntities();

            using (entities)
            {
                decimal income = entities.GetTotalIncome(Start, End, CompanyName);
                Console.WriteLine(income);
            }
        }
    }
}
