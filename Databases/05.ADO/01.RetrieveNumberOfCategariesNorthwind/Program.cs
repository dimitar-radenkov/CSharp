namespace _01.RetrieveNumberOfCategariesNorthwind
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
                SqlCommand command = 
                    new SqlCommand(SQLSettings.Default.sqlGetCategoriesCount, dbCon);

                int categoriesCounnt = (int)command.ExecuteScalar();

                Console.WriteLine("Categories count: {0} ", categoriesCounnt);
            }
        }
    }
}
