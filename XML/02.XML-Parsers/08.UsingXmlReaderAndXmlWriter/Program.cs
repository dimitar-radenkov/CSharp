namespace _08.UsingXmlReaderAndXmlWriter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using Wintellect.PowerCollections;

    /**
     * 
     * Write a program, which (using XmlReader and XmlWriter) 
     * reads the file catalog.xml and creates the file album.xml, 
     * in which stores in appropriate way the names of all albums
     * and their authors.
     * 
     */
    class Program
    {
        static string FilePath = "../../Catalogue.xml";
        static string NewXmlFilePath = "../../Artist.xml";
        static MultiDictionary<string, string> albums = new MultiDictionary<string, string>(true);
        
        static void ReadNamesAndArtist()
        {
            using (XmlReader reader = XmlReader.Create(FilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "album"))
                    {
                        reader.ReadToFollowing("name");
                        string name = reader.ReadElementString();
                        reader.ReadToFollowing("artist");
                        string artist = reader.ReadElementString();

                        albums.Add(artist, name);
                    }
                }
            }
        }

        static void WriteAppropriateXml()
        {
            XmlTextWriter writer = 
                new XmlTextWriter(NewXmlFilePath, Encoding.UTF8);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("artists");

                foreach (var item in albums)
	            {
		            writer.WriteStartElement("artist");
                    writer.WriteElementString("name", item.Key);
                    var storedAlbums = item.Value;
                    writer.WriteStartElement("albums");
                    foreach (var albumName in storedAlbums)
                    {
                        writer.WriteElementString("name", albumName);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
	            }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        
        static void Main(string[] args)
        {
            ReadNamesAndArtist();

            WriteAppropriateXml();         
        }
    }
}
