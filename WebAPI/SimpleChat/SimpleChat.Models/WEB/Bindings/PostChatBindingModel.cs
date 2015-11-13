namespace SimpleChat.Models.WEB
{
    using System.Collections.Generic;

    public class PostChatBindingModel
    {
        public string Topic { get; set; }
        public List<string> Participants { get; set; }
    }
}
