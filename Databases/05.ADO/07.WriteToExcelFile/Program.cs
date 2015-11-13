namespace _07.WriteToExcelFile
{
    using System.Data.OleDb;

    class Program
    {
        static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source=data/Scores.xlsx;"
                + "Extended Properties=\"Excel 12.0 XML;HDR=Yes\"";

        static OleDbConnection excelConnection = new OleDbConnection(connectionString);

        private static int AddRecord(string name, int score)
        {
            var commandWriter = 
                new OleDbCommand("INSERT INTO [Sheet1$] VALUES (@name, @score)", excelConnection);

            commandWriter.Parameters.AddWithValue("@name", name);
            commandWriter.Parameters.AddWithValue("@score", score);

            return commandWriter.ExecuteNonQuery();
        }
        static void Main(string[] args)
        {
            using (excelConnection)
            {
                excelConnection.Open();
                int rowsAffected = AddRecord("Borislav Radenkov", 101);

                System.Console.WriteLine("Rows Affected : {0}", rowsAffected);
            }
        }
    }
}
