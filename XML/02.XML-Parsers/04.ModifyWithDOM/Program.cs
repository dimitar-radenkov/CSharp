using System;
using System.Collections.Generic;
using System.Xml;
namespace _04.ModifyWithDOM
{
    class Program
    {
        /**
         * Using the DOM parser write a program to delete 
         * from catalog.xml all albums having price > 20.
         */

        static string FilePath = "../../Catalogue.xml";
        static string NewFilePath = "../../CatalogueNew.xml";
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            var rootNode = doc.DocumentElement;

            foreach (XmlNode item in rootNode)
            {
                string currentPrice = item["price"].InnerText;
                decimal price = decimal.Parse(currentPrice);

                if (price > 20)
                {
                    item.RemoveAll();
                }
            }

            doc.Save(NewFilePath);
        }
    }
}
