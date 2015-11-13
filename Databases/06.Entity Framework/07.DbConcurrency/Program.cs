namespace _07.DbConcurrency
{
    using _01.EntityFramework;
    using System;

    /*
     Try to open two different data contexts and perform 
     * concurrent changes on the same records. What will 
     * happen at SaveChanges()? How to deal with it?

     */
    class Program
    {
        static NorthwindEntities entities1 = new NorthwindEntities();
        static NorthwindEntities entities2 = new NorthwindEntities();


        static void Main(string[] args)
        {

            //before change
            Console.WriteLine("Before changes...");
            Console.WriteLine("conn 1 : {0}", entities1.Contacts.Find(1).CompanyName);
            Console.WriteLine("conn 2 : {0}", entities2.Contacts.Find(1).CompanyName);
            entities1.Contacts.Find(1).CompanyName = "big boss 11";
            entities1.SaveChanges();

            Console.WriteLine("After connection1 make changes");
            Console.WriteLine("conn 1 : {0}", entities1.Contacts.Find(1).CompanyName);
            Console.WriteLine("conn 2 : {0}", entities2.Contacts.Find(1).CompanyName);

            entities2.Contacts.Find(1).CompanyName = "big boss 22";           
            entities2.SaveChanges();

            Console.WriteLine("After connection2 make changes");
            Console.WriteLine("conn 1 : {0}", entities1.Contacts.Find(1).CompanyName);
            Console.WriteLine("conn 2 : {0}", entities2.Contacts.Find(1).CompanyName);
        }
    }
}
