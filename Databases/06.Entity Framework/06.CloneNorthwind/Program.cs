namespace _06.CloneNorthwind
{
    using _01.EntityFramework;

    /*
     Create a database called NorthwindTwin with the same structure as 
     * Northwind using the features from DbContext. Find for the API 
     * for schema generation in MSDN or in Google.
     */
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Loading..");
            var entities = new NorthwindEntities();
            using (entities)
            {
                entities.Database.CreateIfNotExists();
            }
        }
    }
}
