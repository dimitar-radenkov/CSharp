namespace _09.Transactions
{
    using _01.EntityFramework;
    using System;
    using System.Linq;

    /*
     Create a method that places a new order in the Northwind database.
     * The order should contain several order items. Use transaction to 
     * ensure the data consistency.
     */
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities entities = new NorthwindEntities();

            using (entities)
            {
                using (var dbContextTransaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = new Order();
                        order.CustomerID = "Mitko";
                        order.EmployeeID = 4;

                        entities.Orders.Add(order);
                        entities.SaveChanges();

                        Order retrievedOrder = entities
                                        .Orders
                                        .Where(o => o.CustomerID == "MITKO" && o.EmployeeID == 4)
                                        .FirstOrDefault();

                        Console.WriteLine(retrievedOrder.CustomerID);
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
