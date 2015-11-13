namespace _12.ExtractDataUsingLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /**
     * 
     * Write a program, which extract from the file 
     * catalog.xml the prices for all albums, published 
     * 5 years ago or earlier. Use XPath query.
     *  
     */
    class Program
    {
        static string FilePath = "../../Catalogue.xml";

        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(FilePath);

            var songName =
                from song in doc.Descendants("album")
                where int.Parse(song.Element("year").Value) < DateTime.Now.Year - 5
                select new
                {
                    Name = song.Element("name").Value,
                    Year = song.Element("year").Value
                };

            foreach (var item in songName)
            {
                Console.WriteLine("{0} - {1}",item.Name, item.Year);
            }
        }
    }
}
