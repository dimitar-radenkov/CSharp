namespace _10.TravereDirWithXDocument
{
    using System.IO;
    using System.Xml.Linq;
    using Wintellect.PowerCollections;

    /**
     * 
     * Rewrite the last exercises using XDocument, XElement and XAttribute.
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

            TraverseDir();
            XElement tree = new XElement("Tree");

            foreach (var item in dirs)
            {
                var dir = new XElement("dir",
                    new XAttribute("name", item.Key));
                    

                var files = new XElement("files");
                foreach (var file in item.Value)
                {
                    files.Add(new XElement("file",
                        new XAttribute("name", file)));
                }

                dir.Add(files);
                tree.Add(dir);
            }

            tree.Save(FilePath);
        }
    }
}
