namespace _01.CreateATMDatabase.Database
{
    using _01.CreateATMDatabase.Models;
    using System.Data.Entity;

    public partial class ATMDatabase : DbContext
    {
        public ATMDatabase()
            : base("ATMDatabase")
        {
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> Transactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
