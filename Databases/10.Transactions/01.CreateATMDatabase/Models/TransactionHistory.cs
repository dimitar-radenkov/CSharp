namespace _01.CreateATMDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TransactionHistory
    {
        public int Id { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }


        [ForeignKey("CardAccount")]
        public int CardAccountId { get; set; }
        public virtual CardAccount CardAccount { get; set; }

        public TransactionHistory()
        {

        }

        public TransactionHistory(string number, decimal amount)
            : this(0, number, amount)
        {

        }

        public TransactionHistory(int id, string number, decimal amount)
        {
            this.Id = id;
            this.CardNumber = number;
            this.Date = DateTime.Now;
            this.Amount = amount;
        }    
    }
}
