namespace SimpleChat.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Migrations;
    using System.Data.Entity;

    public class SimpleChatContext : 
        IdentityDbContext<ApplicationUser>
    {       
        public SimpleChatContext()
            : base("SimpleChatContext") 
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SimpleChatContext, Configuration>());
        }

        public static  SimpleChatContext Create()
        {
            return new SimpleChatContext();
        }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Chat> Chats { get; set; }
    }
}