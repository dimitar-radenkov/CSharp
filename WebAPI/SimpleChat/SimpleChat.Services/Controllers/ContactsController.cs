namespace SimpleChat.Services.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class ContactsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllContacts()
        {
            string loggedUserId =
                this.User.Identity.GetUserId();

            var users =
                from u in this.Data.Users
                where u.Id != loggedUserId
                select new
                {
                    UserId = u.Id,
                    Username = u.UserName, 
                    Status = u.Status
                };

            return this.Ok(users);
        }
    }
}
