namespace GuessTheNumber.Data.Contracts
{
    using GuessTheNumber.Data.Repositories.Contracts;
    using GuessTheNumber.Models;

    public interface IGuessTheNumberData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}
