namespace _05.RetrieveImages
{
    using System.Data.SqlClient;
    using System.IO;
    class Program
    {     
        private static SqlConnection dbCon =
                new SqlConnection(SQLSettings.Default.connectionString);

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            const int HeaderLength = 78;
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, HeaderLength, fileContents.Length - HeaderLength);
            }
        }
        
        static void Main(string[] args)
        {
            using (dbCon)
            {
                dbCon.Open();

                string queryGetPictures = 
                                    @"SELECT Picture, CategoryName
                                        FROM [northwind].[dbo].[Categories]";

                SqlCommand sqlGetImages =
                    new SqlCommand(queryGetPictures, dbCon);

                var reader = sqlGetImages.ExecuteReader();

                while (reader.Read())
                {
                    byte[] imageArray = (byte[]) reader["Picture"];
                    string pictureName = (string) reader["CategoryName"];

                    while (reader.Read())
                    {
                        var imageFromDB = (byte[])reader["Picture"];
                        var fileName = (string)reader["CategoryName"];
                        fileName = fileName.Replace("/", string.Empty);
                        WriteBinaryFile(fileName + ".jpg", imageFromDB);

                        System.Console.WriteLine("Image {0} saved successfully.", fileName);
                    }
                }
            }
        }
    }
}
