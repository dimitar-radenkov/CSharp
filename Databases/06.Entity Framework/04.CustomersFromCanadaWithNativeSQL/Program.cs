namespace _04.CustomersFromCanadaWithNativeSQL
{
    using _01.EntityFramework;
    using System;

    /*
     Implement previous by using native SQL query 
     * and executing it through the DbContext.
    */
    class Program
    {
        static void Main(string[] args)
        {
            var entities = new NorthwindEntities();
            using (entities)
            {
                string nativeSQLQuery =
                  "SELECT * " +
                  "FROM [northwind].[dbo].[Orders] o " +
                  "JOIN [northwind].[dbo].[Customers] c " +
                  "ON o.CustomerID = c.CustomerID " +
                    "WHERE o.ShipCountry = 'Canada' AND " +
                    "o.ShippedDate >= '1997' AND " +
                    "o.ShippedDate < '1998'";

                var customers =
                    entities.Database.SqlQuery<Customer>(nativeSQLQuery);

                foreach (var item in customers)
                {
                    Console.WriteLine(" {0} {1}",
                        item.CustomerID, item.CompanyName);
                }
            }
        }
    }
}
