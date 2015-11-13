namespace _02.DaoClass
{
    using _01.EntityFramework;
    /*   
     Create a DAO class with static methods 
     * which provide functionality for inserting, 
     * modifying and deleting customers. Write a testing class.    
     */
    class Program
    {
        static void Main(string[] args)
        {
            IDAOCustomer daoCustomer = new NorthwindDAOCustomer();

            var mitko = new Customer();
            mitko.CustomerID = "DNR";
            mitko.CompanyName = "Radenkov Solitions";
            mitko.ContactName = "Dimitar Radenkov";
            mitko.ContactTitle = "owner";
            mitko.Address = "Sofia, Bulgaria 1000";
            mitko.City = "Sofia";
            mitko.PostalCode = "696969";
            mitko.Country = "Bulgaria";
            mitko.Phone = "0888 888 888";
            mitko.Fax = "020202020";

            var mitkoUpdated = new Customer();
            mitkoUpdated.CustomerID = "DNR";
            mitkoUpdated.CompanyName = "Radenkov Company";
            mitkoUpdated.ContactName = "Dimitar Radenkov";
            mitkoUpdated.ContactTitle = "owner";
            mitkoUpdated.Address = "Varna, Bulgaria 1000";
            mitkoUpdated.City = "Varna";
            mitkoUpdated.PostalCode = "696969";
            mitkoUpdated.Country = "Bulgaria";
            mitkoUpdated.Phone = "0888 888 888";
            mitkoUpdated.Fax = "020202020";

            daoCustomer.Add(mitko);
            daoCustomer.Remove(mitko);

            daoCustomer.Add(mitko);
            daoCustomer.Update(mitko, mitkoUpdated);
        }
    }
}
