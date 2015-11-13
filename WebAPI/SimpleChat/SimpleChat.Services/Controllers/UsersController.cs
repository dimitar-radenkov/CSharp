namespace SimpleChat.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using SimpleChat.Models;

    [Authorize]
    public class UsersController : BaseApiController
    {
        //POST api/Account/ChangeStatus
        [HttpPut]
        [Route("api/Users/ChangeStatus")]
        public IHttpActionResult ChangeStatus(UserStatus status)
        {
            string loggedUserId =
                this.User.Identity.GetUserId();

            var user =
                from u in base.Data.Users
                where u.Id == loggedUserId
                select u;

            if (user.FirstOrDefault() != null)
            {
                user.FirstOrDefault().Status = status;
            }

            base.Data.SaveChanges();

            return this.Ok();
        }
    }
}