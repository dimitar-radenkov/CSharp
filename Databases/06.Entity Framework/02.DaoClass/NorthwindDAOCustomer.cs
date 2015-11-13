namespace _02.DaoClass
{
    using _01.EntityFramework;
    using _02.DaoClass;
    using System;
    public class NorthwindDAOCustomer : IDAOCustomer
    {
        private NorthwindEntities entities;

        public void Add(Customer customer)
        {
            using (this.entities = new NorthwindEntities())
            {
                this.entities.Customers.Add(customer);
                this.entities.SaveChanges();
                Console.WriteLine("New Record has been added.");
            }
        }

        public void Remove(Customer customer)
        {
            using (this.entities = new NorthwindEntities())
            {
                this.Remove(customer.CustomerID);
            }
        }

        public void Remove(string customerId)
        {
            using (this.entities = new NorthwindEntities())
            {
                var customerToRemove = this.entities.Customers.Find(customerId);
                this.entities.Customers.Remove(customerToRemove);
                this.entities.SaveChanges();
                Console.WriteLine("A record has been removed.");
            }
        }

        public void Update(Customer oldCustomer, Customer updatedCustomer)
        {
            using (this.entities = new NorthwindEntities())
            {
                this.Update(oldCustomer.CustomerID, updatedCustomer);
            }
        }

        public void Update(string customerId, Customer updatedCustomer)
        {
            using (this.entities = new NorthwindEntities())
            {
                var customerToUpdate =
                    this.entities.Customers.Find(customerId);

                customerToUpdate.CompanyName = updatedCustomer.CompanyName;
                customerToUpdate.ContactName = updatedCustomer.ContactName;
                customerToUpdate.ContactTitle = updatedCustomer.ContactTitle;
                customerToUpdate.Address = updatedCustomer.Address;
                customerToUpdate.City = updatedCustomer.City;
                customerToUpdate.Region = updatedCustomer.Region;
                customerToUpdate.PostalCode = updatedCustomer.PostalCode;
                customerToUpdate.Country = updatedCustomer.Country;
                customerToUpdate.Phone = updatedCustomer.Phone;
                customerToUpdate.Fax = updatedCustomer.Fax;

                customerToUpdate.Orders = updatedCustomer.Orders;
                customerToUpdate.CustomerDemographics = updatedCustomer.CustomerDemographics;

                this.entities.SaveChanges();
                Console.WriteLine("Record has been updated.");
            }
        }
    }
}
