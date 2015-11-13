namespace _05.GetOrdersByParams
{
    using _01.EntityFramework;
    using System;
    using System.Linq;

    /*
     Write a method that finds all the sales by 
     * specified region and period (start / end dates).
     */
    class Program
    {
        static string Region = "BC";
        static DateTime StartDate = new DateTime(1997, 1, 1);
        static DateTime EndDate = new DateTime(1999, 1, 1);

        static void Main(string[] args)
        {
            var entities = new NorthwindEntities();
            using (entities)
            {
                var orders =
                    from o in entities.Orders
                    where (o.OrderDate >= StartDate &&
                           o.OrderDate <= EndDate &&
                           o.ShipRegion == Region)
                    select o;

                foreach (var item in orders)
                {
                    Console.WriteLine(" {0} {1} {2}",
                        item.OrderID, item.ShipRegion, item.OrderDate);
                }
            }
        }
    }
}
