namespace _04.InsertValueIntoTable
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        private static SqlConnection dbCon =
                new SqlConnection(SQLSettings.Default.connectionString);

        private static int InsertProduct(
            string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsInOrder,
            int reorderLevel,
            byte discounted )
        {
            SqlCommand sqlInsert = new SqlCommand(
                "INSERT INTO [northwind].[dbo].[Products] " +
                "VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, " +
                        "@unitsInStock, @unitsInOrder, @reorderLevel, @discounted)", dbCon);

            sqlInsert.Parameters.AddWithValue("@productName", productName);
            sqlInsert.Parameters.AddWithValue("@supplierId", supplierId);
            sqlInsert.Parameters.AddWithValue("@categoryId", categoryId);
            sqlInsert.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            sqlInsert.Parameters.AddWithValue("@unitPrice", unitPrice);
            sqlInsert.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            sqlInsert.Parameters.AddWithValue("@unitsInOrder", unitsInOrder);
            sqlInsert.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            sqlInsert.Parameters.AddWithValue("@discounted", discounted);

            return sqlInsert.ExecuteNonQuery();
        }

        static void Main(string[] args)
        {
            using (dbCon)
            {
                dbCon.Open();

                int rowsAffected = InsertProduct(
                    "Beer", 1, 1, "12 bottes per stack", 
                    20, 100, 20, 1, 0);

                Console.WriteLine("Rows affected : {0}", rowsAffected);
            }
        }
    }
}
