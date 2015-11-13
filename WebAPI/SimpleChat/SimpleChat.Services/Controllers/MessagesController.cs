namespace SimpleChat.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models.Bindings;
    using SimpleChat.Models;
    using SimpleChat.Models.WEB.Bindings;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class MessagesController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllMessages()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            string loggedUserId = this.User.Identity.GetUserId();

            var chats =
                from c in base.Data.Chats
                where c.Participants.Any( x => x.Id == loggedUserId)
                select c;

            List<object> messages = new List<object>();

            if (chats != null)
            {
                foreach (var chat in chats)
                {
                    var msgs =
                        from m in base.Data.Messages
                        where m.ChatId == chat.Id &&
                              m.Status == MessageStatus.Send
                        select new
                        {
                            SentOn = m.SentOn,
                            Sender = m.Sender.UserName,
                            SenderId = m.SenderId,
                            Content = m.Content,
                            MessageId = m.Id,
                            ChatId = chat.Id
                        };

                    messages.AddRange(msgs.ToList());
                }
            }

            return this.Ok(messages);
        }

        [HttpPost]
        public IHttpActionResult AddMessage(PostMessageBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var chat =
                (from c in base.Data.Chats
                 where c.Id == model.ChatId
                 select c).FirstOrDefault();

            if (chat == null)
            {
                return this.BadRequest("Such chat do not exists");
            }

            string loggedUserId = this.User.Identity.GetUserId();
            var loggedUser =
                (from u in base.Data.Users
                 where u.Id == loggedUserId
                 select u).FirstOrDefault();

            var message = new Message()
            {
                Content = model.Content,
                Chat = chat,
                Sender = loggedUser,
                SentOn = DateTime.Now,
                Status = MessageStatus.Send,
            };

            base.Data.Messages.Add(message);
            base.Data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult PutMessage(int id, PutMessageBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var message =
                (from m in base.Data.Messages
                 where m.Id == id
                 select m).FirstOrDefault();

            if (message == null)
            {
                return this.BadRequest("Message do not exists !");
            }

            message.Status = model.Status;
            base.Data.SaveChanges();

            return this.Ok(
                string.Format("Message {0} changed", id));
        }
    }
}
