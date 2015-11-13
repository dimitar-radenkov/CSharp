namespace _05.XmlReader
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /**
     * 
     * Write a program, which using XmlReader extracts 
     * all song titles from catalog.xml.
     * 
     */

    class Program
    {
        static string FilePath = "../../Catalogue.xml";
        static void Main(string[] args)
        {
            List<string> songNames = new List<string>();

            using (XmlReader reader = XmlReader.Create(FilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "song"))
                    {
                        reader.ReadToFollowing("title");
                        string title = reader.ReadElementString();
                        songNames.Add(title);
                    }
                }
            }

            Console.WriteLine("Songs : {0}",
                string.Join(", ", songNames));
        }
    }
}
