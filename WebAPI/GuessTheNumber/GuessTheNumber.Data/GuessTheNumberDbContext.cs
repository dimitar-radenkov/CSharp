namespace GuessTheNumber.Data
{
    using System.Data.Entity;
    using GuessTheNumber.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using GuessTheNumber.Data.Migrations;

    public class GuessTheNumberDbContext : IdentityDbContext<User>
    {
        public GuessTheNumberDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<GuessTheNumberDbContext, 
                    Configuration>());
        }

        public static GuessTheNumberDbContext Create()
        {
            return new GuessTheNumberDbContext();
        }

        public IDbSet<Game> Games { get; set; }
    }
}
