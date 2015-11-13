namespace _01.CreateATMDatabase
{
    using _01.CreateATMDatabase.Database;
    using _01.CreateATMDatabase.Models;
    using System;
    using System.Linq;
	
	/*
	
	Suppose you are creating a simple engine for an ATM machine. 
	Create a new database "ATM" in SQL Server to hold the accounts 
	of the card holders and the balance (money) for each account. 
	Add a new table CardAccounts with the following fields: 
	Id (int)
	CardNumber (char(10))
	CardPIN (char(4))
	CardCash (money)
	Add a few sample records in the table.
	
	*/
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ATMDatabase();
            using (db)
            {
                //add some records
                CardAccount card1 = new CardAccount("1111111111", "1111", 1000);
                CardAccount card2 = new CardAccount("2222222222", "2222", 2000);
                CardAccount card3 = new CardAccount("3333333333", "3333", 3000);

                db.CardAccounts.Add(card1);
                db.CardAccounts.Add(card2);
                db.CardAccounts.Add(card3);

                db.SaveChanges();
            }
        }
    }
}
