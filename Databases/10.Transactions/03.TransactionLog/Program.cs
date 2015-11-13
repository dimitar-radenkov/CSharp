namespace _03.TransactionLog
{
    using _01.CreateATMDatabase.Database;
    using _01.CreateATMDatabase.Models;
    using _01.CreateATMDatabase.Migrations;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

	/*
	
	Extend the project from the previous exercise and add a new 
	table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount)
	containing information about all money retrievals on all accounts.
	
	Modify the program logic so that it saves historical information 
	(logs) in the new table after each successful money withdrawal.
	
	What should the isolation level be for the transaction?

	
	*/
	
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ATMDatabase, Configuration>());
            var db = new ATMDatabase();
            using (db)
            {
                var transaction = db.Database.BeginTransaction(IsolationLevel.RepeatableRead);

                string cardNumber = "2222222222";
                string cardPin = "2222";
                int cardId = 2;
                decimal money = 500;

                CardAccount card =
                    (from c in db.CardAccounts
                     where (c.CardNumber == cardNumber &&
                           c.CardPin == cardPin)
                     select c).First();

                //check card pin and number
                if (card.CardAccountId != cardId)
                {
                    throw new InvalidOperationException("wrong card number or pin");
                }

                //check ballance
                if (card.CardCash < money)
                {
                    throw new InvalidOperationException("not enought money in account");
                }

                card.CardCash -= money;

                //create new transaction log
                TransactionHistory log = 
                    new TransactionHistory(card.CardNumber, money);

                log.CardAccountId = card.CardAccountId;

                //add log in database
                db.Transactions.Add(log);

                //finish transaction
                transaction.Commit();
                db.SaveChanges();
            }
        }
    }
}
