namespace _02.SearchInRange
{
    /*
     Write a program to read a large collection of products (name + price) 
     and efficiently find the first 20 products in the 
     price range [a…b]. Test for 500 000 products and 10 000 price searches.
     Hint: you may use OrderedBag<T> and sub-ranges.
    */

    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class Program
    {
        private static int ProductsCount = 500000; /*500 000*/
        private static int Searches = 10000; /*10 000*/
        private static int ProductToFind = 20;

        private static OrderedBag<Product> productsList;

        private static void GenerateLargeCollection()
        {
            productsList = new OrderedBag<Product>();

            //load products
            for (int i = 0; i < ProductsCount; i++)
            {
                productsList.Add(new Product(i.ToString(), i));
            }
        }

        private static IEnumerable<Product> GetProductInRange(decimal from, decimal to)
        {
            var productFrom = new Product(from.ToString(), from);
            var productTo = new Product(to.ToString(), to);

            var collection = productsList.Range(productFrom, true, productFrom, true);

            if (collection.Count > ProductToFind)
            {
                return collection.Take(ProductToFind);
            }

            return collection;
        }


        static void Main(string[] args)
        {
            GenerateLargeCollection();
            //perform searches

            decimal from = 500;
            decimal to = 1000;

            for (int i = 0; i < Searches; i++)
            {
                var wantedProducts = GetProductInRange(from + i, to + i);
            }
        }
    }
}
