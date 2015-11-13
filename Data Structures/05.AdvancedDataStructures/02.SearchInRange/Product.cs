namespace _02.SearchInRange
{
    using System;

    public class Product : IComparable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            var product = (Product)obj;

            return product.Price.CompareTo(this.Price);
        }
    }
}
