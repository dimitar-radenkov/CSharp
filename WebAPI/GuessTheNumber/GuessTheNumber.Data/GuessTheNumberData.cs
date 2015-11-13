namespace GuessTheNumber.Data
{
    using GuessTheNumber.Data.Contracts;
    using GuessTheNumber.Data.Repositories;
    using GuessTheNumber.Data.Repositories.Contracts;
    using GuessTheNumber.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class GuessTheNumberData : IGuessTheNumberData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public GuessTheNumberData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
