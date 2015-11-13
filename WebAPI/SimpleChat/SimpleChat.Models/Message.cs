namespace SimpleChat.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public Message()
        { }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public MessageStatus Status { get; set; }

        public DateTime SentOn { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
