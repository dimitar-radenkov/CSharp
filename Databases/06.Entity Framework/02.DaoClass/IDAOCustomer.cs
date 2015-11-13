using _01.EntityFramework;
namespace _02.DaoClass
{
    public interface IDAOCustomer
    {
        void Add(Customer customer);

        void Remove(Customer customer);
        void Remove(string customerId);

        void Update(Customer oldCustomer, Customer newCustomer);
        void Update(string customerId, Customer newCustomer);
    }
}
