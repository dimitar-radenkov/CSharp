namespace _06.GetSongTitlesWithXDocumentAndLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /**
     * 
     * Write a program, which using XDocument and LINQ query  
     * extracts all song titles from catalog.xml.
     * 
     */
    class Program
    {
        static string FilePath = "../../Catalogue.xml";

        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(FilePath);

            var songName =
                from song in doc.Descendants("song")
                select song.Element("title").Value;

            foreach (var item in songName)
            {
                Console.WriteLine(item);
            }
        }
    }
}
