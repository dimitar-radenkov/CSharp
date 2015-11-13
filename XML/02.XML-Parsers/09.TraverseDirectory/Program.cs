namespace _09.TraverseDirectory
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using Wintellect.PowerCollections;

    /**
     * 
     * Write a program to traverse given directory and write 
     * to a XML file its contents together with all 
     * subdirectories and files. Use tags <file> and <dir> 
     * with appropriate attributes. For the generation of the 
     * XML document use the class XmlWriter.
     * 
     */

    class Program
    {
        static string FilePath = @"..\..\Tree.xml";
        static string directoryLocation = @"C:\mongodb";

        static MultiDictionary<string, string> dirs = new MultiDictionary<string, string>(true);

        static void TraverseDir()
        {
            string currentDir = directoryLocation;
            var files = Directory.GetFiles(currentDir);

            foreach (var file in files)
	        {
                dirs.Add(currentDir, file);
	        }          

            foreach (var item in Directory.GetDirectories(currentDir))
            {
                currentDir = item;
                files = Directory.GetFiles(currentDir);

                foreach (var file in files)
                {
                    dirs.Add(currentDir, file);
                }    
            }
        }

        static void Main(string[] args)
        {
            //traverse project directory
            TraverseDir();

            XmlTextWriter writer = new XmlTextWriter(FilePath, Encoding.UTF8);
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("DirectoryTree");
                foreach (var item in dirs)
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("name", item.Key);
                    writer.WriteStartElement("files");
                    foreach (var file in item.Value)
                    {
                        writer.WriteStartElement("file");
                        writer.WriteAttributeString("name", file);
                        writer.WriteEndElement();
                    }                   
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();             
            }
        }
    }
}
