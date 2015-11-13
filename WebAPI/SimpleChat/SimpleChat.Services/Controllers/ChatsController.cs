namespace SimpleChat.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using SimpleChat.Models;
    using SimpleChat.Models.WEB;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class ChatsController : BaseApiController
    {
        [HttpPost]
        public IHttpActionResult AddIfNoExistingChat(PostChatBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            string loggedUserId =
                this.User.Identity.GetUserId();

            model.Participants.Add(loggedUserId);
                 
            var chat = new Chat()
            {
                Topic = model.Topic,
            };

            foreach (var item in model.Participants)
            {            
                var user =
                    (from u in base.Data.Users
                     where u.Id == item
                     select u).FirstOrDefault();

                if (user == null)
                {
                    this.BadRequest("unknown participant");
                }

                chat.Participants.Add(user);
            }

            var chats =
               from c in base.Data.Chats
               where c.Participants.Count == chat.Participants.Count
               select c;

            foreach (Chat c in chats)
            {
                if (c.Participants.SetEquals(chat.Participants))
                {
                    return this.Ok(c.Id);
                }
            }

            base.Data.Chats.Add(chat);
            base.Data.SaveChanges();

            return this.Ok(chat.Id);
        }
    }
}