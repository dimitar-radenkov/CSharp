namespace _08.ExtendEmployee
{
    using _01.EntityFramework;
    using System;
    using System.Linq;

    /*By inheriting the Employee entity class 
     * create a class which allows employees to access
     * their corresponding territories as property of 
     * type EntitySet<T>.*/
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities entities = new NorthwindEntities();

            using (entities)
            {
                Employee employee = entities.Employees.First(); ;
                foreach (var territory in employee.Territories)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }         
            }
        }
    }
}
