namespace _07.CreateXmlFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    /**
     * 
     * In a text file we are given the name, address and 
     * phone number of given person (each at a single line).
     * Write a program, which creates new XML document,
     * which contains these data in structured XML format
     * 
     */

    class Program
    {
        static string TextFilename = "../../text.txt";
        static string XmlFilename = "../../person.xml";

        static int NAME = 0;
        static int ADDRESS = 1;
        static int PHONE = 2;

        static List<string> ReadFile()
        {
            List<string> lines = new List<string>();

            StreamReader reader = new StreamReader(TextFilename);
            using (reader)
            {             
                string line = reader.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            return lines;
        }

        static void Main(string[] args)
        {
            List<string> fileContextLineByLine = ReadFile();
            XmlTextWriter writer = new XmlTextWriter(XmlFilename, Encoding.UTF8);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();

                writer.WriteStartElement("person");
                writer.WriteElementString("name", fileContextLineByLine[NAME]);
                writer.WriteElementString("address", fileContextLineByLine[ADDRESS]);
                writer.WriteElementString("phone", fileContextLineByLine[PHONE]);
                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }
    }
}
