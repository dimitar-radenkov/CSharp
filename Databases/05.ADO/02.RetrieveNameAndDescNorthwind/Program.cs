namespace _02.RetrieveNameAndDescNorthwind
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon =
                new SqlConnection(SQLSettings.Default.connectionString);

            dbCon.Open();
            using (dbCon)
            {
                string sqlGetNameAndDescCategories = 
                        @"SELECT CategoryName, Description " +
                            "FROM [northwind].[dbo].[Categories]";

                SqlCommand command =
                    new SqlCommand(sqlGetNameAndDescCategories, dbCon);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} - {1}", 
                            reader["CategoryName"], reader["Description"]);
                    }
                }
            }
        }
    }
}
