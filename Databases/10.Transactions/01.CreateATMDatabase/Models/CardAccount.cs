namespace _01.CreateATMDatabase.Models
{
    using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        private ICollection<TransactionHistory> transactions;

        [Required]
        public int CardAccountId { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }

        public virtual ICollection<TransactionHistory> Transactions
        {
            get { return this.transactions; }
            set { this.transactions = value; }
        }

        public CardAccount()
        {

        }

        public CardAccount(string number, string pin, decimal money)
            :this(0, number, pin, money)
        {

        }
        public CardAccount(int id, string number, string pin, decimal money)
        {
            this.CardAccountId = id;
            this.CardNumber = number;
            this.CardPin = pin;
            this.CardCash = money;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",
                this.CardAccountId, this.CardNumber, this.CardPin, this.CardCash);
        }
    }
}
