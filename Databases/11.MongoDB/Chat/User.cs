namespace Chat
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public User(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
