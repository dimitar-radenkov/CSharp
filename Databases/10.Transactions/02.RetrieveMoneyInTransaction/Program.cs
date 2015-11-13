namespace _02.RetrieveMoneyInTransaction
{
    using _01.CreateATMDatabase.Database;
    using _01.CreateATMDatabase.Models;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
	
	/*
	Using transactions write a method which retrieves some money (for example $200) from certain account.
	The retrieval is successful when the following sequence of sub-operations is completed successfully:
		A query checks if the given CardPIN and CardNumber are valid.
		
		The amount on the account (CardCash) is evaluated to see 
		whether it is bigger than the requested sum (more than $200).
		
		The ATM machine pays the required sum (e.g. $200) and 
		stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
	*/

    class Program
    {
        static void Main(string[] args)
        {         
            var db = new ATMDatabase();
            using(db)
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

                //finish transaction
                transaction.Commit();
                db.SaveChanges();
            }
        }
    }
}
