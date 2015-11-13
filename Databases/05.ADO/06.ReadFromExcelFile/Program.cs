namespace _06.ReadFromExcelFile
{
    using System;
    using System.Data.OleDb;

    class Program
    {
        static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source=data/Scores.xlsx;"
                + "Extended Properties=\"Excel 12.0 XML;HDR=Yes\"";

        static OleDbConnection excelConnection = 
            new OleDbConnection(connectionString);

        static void Main(string[] args)
        {
            using(excelConnection)
            {
                excelConnection.Open();
            }

            string sqlQuery = "SELECT * FROM [Sheet1$]";
            var command = new OleDbCommand(sqlQuery, excelConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader[0];
                var score = reader[1];
                Console.WriteLine("{0} -> {1}", name, score);
            }            
        }
    }
}
