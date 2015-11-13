namespace SimpleChat.Models
{
    using System.Collections.Generic;

    public class Chat
    {
        private ISet<ApplicationUser> participants;

        public Chat()
        {
            this.participants = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public virtual ISet<ApplicationUser> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }
    }
}
