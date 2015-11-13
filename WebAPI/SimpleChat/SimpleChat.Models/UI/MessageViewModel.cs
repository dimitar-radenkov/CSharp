namespace SimpleChat.Models.UI
{
    using System;

    public class MessageViewModel
    {
        public DateTime SentOn { get; set; }
        public string Sender { get; set; }

        public string SenderId { get; set; }
        public string Content { get; set; }
        public int MessageId { get; set; }
        public int ChatId { get; set; }

        public string SenderUsername
        {
            get { return string.Format("{0} :", this.Sender); }
        }

        public string DateTime
        {
            get { return string.Format("[{0}]", this.SentOn.ToLocalTime()); }
        } 
    }
}
