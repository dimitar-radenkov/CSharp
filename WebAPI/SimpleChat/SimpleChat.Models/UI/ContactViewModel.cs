namespace SimpleChat.Model.UI
{
    using SimpleChat.Models;
    using System.Windows.Media;

    public class ContactViewModel
    {
        public ContactViewModel()
        {
            this.VisibleString = "Hidden";
        }

        public ContactViewModel(
            string id, 
            string name,
            UserStatus status)
        {
            this.UserId = id;
            this.Username = name;
            this.Status = status;
            this.VisibleString = "Hidden";
        }

        public string UserId { get; set; }

        public string Username { get; set; }

        public UserStatus Status { get; set; }

        public Brush StatusBrush
        {
            get
            {
                switch (this.Status)
                {
                    case UserStatus.Unknwown:
                        return Brushes.BlueViolet;
                    case UserStatus.Active:
                        return Brushes.Green;
                    case UserStatus.Away:
                        return Brushes.Orange;
                    case UserStatus.DoNotDisturb:
                        return Brushes.Red;
                    case UserStatus.Offline:
                        return Brushes.Gray;
                    default:
                        return Brushes.White;
                }
            }
            set { this.StatusBrush = value; }
        }       

        public string VisibleString { get; set; }
    }
}
