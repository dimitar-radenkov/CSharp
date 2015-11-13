namespace _02.ExtractArtistsFromCatalogue
{
    using System;
    using System.Xml;
    using Wintellect.PowerCollections;

    /*
     Write program that extracts all different artists 
     which are found in the catalog.xml. For each author 
     you should print the number of albums in the catalogue.
     Use the DOM parser and a hash-table.
     */
    class Program
    {
        static string FilePath = "../../Catalogue.xml";
        static MultiDictionary<string, string> albums = new MultiDictionary<string, string>(true);
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(FilePath);

            XmlNode root = xml.DocumentElement;

            foreach (XmlNode item in root.ChildNodes)
            {
                string artist = item["artist"].InnerText;
                string album = item["name"].InnerText;

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
