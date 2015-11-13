namespace _03.ExtractArtistFromCatalogueWithXPath
{
    using System;
    using System.Xml.XPath;
    using Wintellect.PowerCollections;

    /*
     
     Write program that extracts all different artists 
     which are found in the catalog.xml. 
     For each author you should print the number of 
     albums in the catalogue using XPath.

     */
    class Program
    {
        static string FilePath = "../../Catalogue.xml";
        static MultiDictionary<string, string> albums = new MultiDictionary<string, string>(true);

        static void Main(string[] args)
        {
            string xpath = "/catalogue/album/artist | /catalogue/album/name";

            XPathDocument document = new XPathDocument(FilePath);
            XPathNavigator navigator = document.CreateNavigator();
            XPathExpression expression = navigator.Compile(xpath);
            XPathNodeIterator it = navigator.Select(expression);

            while (it.MoveNext())
            {
                string album = it.Current.InnerXml;
                it.MoveNext();
                string artist = it.Current.InnerXml;

                albums.Add(artist, album);
            }

            //print artist - albums
            foreach (var item in albums)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.ToString());
            }
        }
    }
}
