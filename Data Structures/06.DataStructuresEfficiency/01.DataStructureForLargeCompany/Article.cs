namespace _02.DataStructureForLargeCompany
{
    using System;

    public class Article : IComparable
    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Article(string barcode, 
            string vendor, 
            string title, 
            decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",
                this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(object obj)
        {
            Article article = obj as Article;

            return article.Price.CompareTo(this.Price);
        }
    }
}
