namespace _02.DataStructureForLargeCompany
{
    using System;
    /*
         * A large trade company has millions of articles,
         * each described by barcode, vendor, title and price. 
         * Implement a data structure to store them that allows
         * fast retrieval of all articles in given price range [x…y]. 
         * Hint: use OrderedMultiDictionary<K,T> 
         * from Wintellect's Power Collections for .NET. 
         */


    class Program
    {
        static void Main(string[] args)
        {
            var ds = new BigCompanyDS();
            ds.Add(new Article("1", "1", "1", 10));
            ds.Add(new Article("1", "1", "1", 10));
            ds.Add(new Article("2", "2", "2", 20));
            ds.Add(new Article("3", "3", "3", 30));
            ds.Add(new Article("4", "4", "4", 40));

            var articles = ds.GetArticlesInRange(10, 30);

            foreach (var item in articles)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
