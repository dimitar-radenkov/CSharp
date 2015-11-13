namespace _03.RetrieveProductCategoriesAndNames
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon =
                new SqlConnection(SQLSettings.Default.connectionString);

            using (dbCon)
            {
                dbCon.Open();

                string sqlGetProductsAndCategories =
                        @"SELECT p.ProductName, c.CategoryName
	                        FROM [northwind].[dbo].[Products] p
	                        INNER JOIN [northwind].[dbo].[Categories] c
	                        ON p.CategoryID = c.CategoryID;";

                SqlCommand command =
                    new SqlCommand(sqlGetProductsAndCategories, dbCon);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} - {1}",
                            reader["ProductName"], 
                            reader["CategoryName"]);
                    }
                }
            }
        }
    }
}
