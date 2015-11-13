namespace SimpleChat.UI.Network
{
    using Model.UI;
    using Models;
    using Models.UI;
    using System.Collections.Generic;
    using System.Net.Http;

    public static class NetworkDriver
    {
        //messages
        private const string CHANGE_MESSAGE_STATUS_END_POINT = "http://localhost:56610/api/Messages/ChangeStatus";
        private const string ADD_NEW_MESSAGE_END_POINT = "http://localhost:56610/api/Messages";
        private const string GET_NEW_MESSAGES_END_POINT = "http://localhost:56610/api/Messages";
        //users
        private const string CHANGE_USER_STATUS_END_POINT = "http://localhost:56610/api/Users/ChangeStatus";
        private const string GET_ALL_CONTACTS_END_POINT = "http://localhost:56610/api/Contacts";
        //chats
        private const string ADD_CHAT_END_POINT = "http://localhost:56610/api/Chats";
        //other
        private const string REGISTER_END_POINT = "http://localhost:56610/api/account/Register";
        private const string LOGIN_END_POINT = "http://localhost:56610/Token";
        
        private static HttpClient client;

        public static string AccessToken { get; set; }
        public static string LoggedUsername { get; set; }
        public static string LoggedUserId { get; set; }

        static NetworkDriver()
        {
            client = new HttpClient();
        }

        public static void Login(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

            var response = client.PostAsync(LOGIN_END_POINT, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }

            var login = response.Content.ReadAsAsync<LoginResultModel>().Result;
            AccessToken = login.Access_Token;
            LoggedUsername = login.UserName;
            LoggedUserId = login.UserId;

            client.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + AccessToken);

            ChangeUserStatus(UserStatus.Active);
        }

        public static void Register(string username, string password, string confirmPass)
        {
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPass),
                    new KeyValuePair<string, string>("email", username + password + "@abv.bg"),
                });

            var response = client.PostAsync(REGISTER_END_POINT, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }
        }

        public static IEnumerable<ContactViewModel> GetAllContacts()
        {          
            var response = client.GetAsync(GET_ALL_CONTACTS_END_POINT).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }

            return response.Content.ReadAsAsync<IEnumerable<ContactViewModel>>().Result;
        }

        public static void AddMessage(string content, int chatId)
        {
            var bodyData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("content", content),
                new KeyValuePair<string, string>("chatId", chatId.ToString()),
            });

            var response = client.PostAsync(ADD_NEW_MESSAGE_END_POINT, bodyData).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }
        }

        public static IEnumerable<MessageViewModel> GetNewMessages()
        {          
            var response = client.GetAsync(GET_NEW_MESSAGES_END_POINT).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }

            return response.Content.ReadAsAsync<IEnumerable<MessageViewModel>>().Result;
        }

        public static void ChangeMessageStatus(int messageId, MessageStatus status)
        {
            var fullEndPoint = ADD_NEW_MESSAGE_END_POINT + "/" + messageId;
            var bodyData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("status", status.ToString()),
            });

            var response = client.PutAsync(fullEndPoint, bodyData).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }            
        }

        public static void ChangeUserStatus(UserStatus status)
        {          
            var response = client.PutAsync(CHANGE_USER_STATUS_END_POINT + 
                string.Format("?status={0}", status.ToString()), null ).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.Content.ReadAsStringAsync().Result);
            }
        }

        public static int AddIfNoExistingChat(string topic, IEnumerable<string> participants)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("topic", topic));
            
            int counter = 0;
            foreach (var item in participants)
            {
                pairs.Add(new KeyValuePair<string, string>(
                    string.Format("participants[{0}]", counter++), item));
            }

            var bodyData = new FormUrlEncodedContent(pairs);        
            var response = client.PostAsync(ADD_CHAT_END_POINT, bodyData).Result;          
            return response.Content.ReadAsAsync<int>().Result;
        }
    }
}
