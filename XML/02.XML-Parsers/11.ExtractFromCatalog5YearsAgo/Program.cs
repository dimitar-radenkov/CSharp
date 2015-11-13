namespace _11.ExtractFromCatalog5YearsAgo
{
    using System;
    using System.Xml.XPath;

    /**
     * 
     * Write a program, which extract from the file catalog.xml 
     * the prices for all albums, published 5 years ago or earlier. 
     * Use XPath query.
     * 
     */

    class Program
    {
        static string FileLocation = @"..\..\catalogue.xml";

        static void Main(string[] args)
        {

            string xpath = "/catalogue/album/year | /catalogue/album/price | /catalogue/album/name";

            XPathDocument document = new XPathDocument(FileLocation);
            XPathNavigator navigator = document.CreateNavigator();
            XPathExpression expression = navigator.Compile(xpath);
            XPathNodeIterator it = navigator.Select(expression);

            while (it.MoveNext())
            {
                string name = it.Current.InnerXml;
                it.MoveNext();
                int year = int.Parse(it.Current.InnerXml);
                it.MoveNext();
                decimal price = decimal.Parse(it.Current.InnerXml);
                
                int currentYear = DateTime.Now.Year;

                if ((currentYear - 5) >= year)
                {
                    Console.WriteLine("{0} ({1})- {2}", name, year, price);
                }
            }
        }
    }
}
