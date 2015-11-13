namespace SimpleChat.UI.Observer
{
    public class OnContactClickedArgs
    {
        public string Username { get; set; }
        public string Id { get; set; }

        public OnContactClickedArgs(string username, string id)
        {
            this.Username = username;
            this.Id = id;
        }
    }
}
