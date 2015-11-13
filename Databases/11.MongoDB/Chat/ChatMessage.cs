namespace Chat
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class ChatMessage
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string MessageText { get; set; }

        public DateTime TimeSend { get; set; }

        public User User { get; set; }

        public ChatMessage(string messageText, User user)
        {
            this.MessageText = messageText;
            this.TimeSend = DateTime.Now;
            this.User = user;          
        }
    }
}
