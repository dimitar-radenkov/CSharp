namespace _02.DataStructureForLargeCompany
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BigCompanyDS
    {
        private const bool AllowDuplicates = true;
        private OrderedMultiDictionary<decimal, Article> articlesList;

        public BigCompanyDS()
        {
            this.articlesList = new OrderedMultiDictionary<decimal, Article>(AllowDuplicates);
        }

        public void Add(Article item)
        {
            this.articlesList.Add(item.Price, item);
        }

        public void Delete(Article item)
        {
            this.articlesList.Remove(item.Price);
        }

        public ICollection<Article> GetArticlesInRange(decimal from, decimal to)
        {
            bool inclusive = true;
            var collection = this.articlesList.Range(from, inclusive, to, inclusive);

            return collection.Values; 
        }
    }
}
