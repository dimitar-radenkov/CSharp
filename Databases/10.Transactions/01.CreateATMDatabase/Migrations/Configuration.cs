namespace _01.CreateATMDatabase.Migrations
{
    using _01.CreateATMDatabase.Database;
    using _01.CreateATMDatabase.Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ATMDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CreateATMDatabase.ATMDatabase";
        }

        protected override void Seed(ATMDatabase context)
        {
            CardAccount card1 = new CardAccount("1111111111", "1111", 1000);
            CardAccount card2 = new CardAccount("2222222222", "2222", 2000);
            CardAccount card3 = new CardAccount("3333333333", "3333", 3000);

            context.CardAccounts.AddOrUpdate(card1);
            context.CardAccounts.AddOrUpdate(card2);
            context.CardAccounts.AddOrUpdate(card3);

            context.SaveChanges();
        }
    }
}
