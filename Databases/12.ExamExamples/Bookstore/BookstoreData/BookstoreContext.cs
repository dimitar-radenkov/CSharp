namespace BookstoreData
{
    using BookstoreData.Migrations;
    using BookstoreModels;
    using System.Data.Entity;

    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
            : base("BookstoreContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookstoreContext, Configuration>());
        }


        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
