namespace _03.CustomersFromCanada
{
    using _01.EntityFramework;
    using System;
    using System.Linq;

    /*
     Write a method that finds all customers 
     * who have orders made in 1997 and shipped to Canada.
     */

    class Program
    {
        static string Country = "Canada";
        static DateTime StartDate = new DateTime(1997, 1, 1);
        static DateTime EndDate = new DateTime(1998, 1, 1);

        static void Main(string[] args)
        {
            var entities = new NorthwindEntities();
            using (entities = new NorthwindEntities())
            {
                var allCustomers =
                  from o in entities.Orders
                  join c in entities.Customers
                  on o.CustomerID equals c.CustomerID
                  where (o.ShipCountry == Country &&
                         o.ShippedDate >= StartDate &&
                         o.ShippedDate < EndDate)
                  select c;

                foreach (var item in allCustomers)
                {
                    Console.WriteLine(" {0} {1}",
                        item.CustomerID, item.CompanyName);
                }
            }
        }
    }
}
