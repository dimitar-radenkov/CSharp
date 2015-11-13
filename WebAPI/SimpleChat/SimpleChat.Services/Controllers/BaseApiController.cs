namespace SimpleChat.Services.Controllers
{
    using Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
           : this(new SimpleChatContext())
        {
        }

        public BaseApiController(SimpleChatContext data)
        {
            this.Data = data;
        }

        protected SimpleChatContext Data { get; set; }
    }
}
