namespace GuessTheNumber.Web.Controllers
{
    using GuessTheNumber.Data;
    using GuessTheNumber.Data.Contracts;
    using System.Web.Http;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using GuessTheNumber.Models;
    using System;

    [Authorize]
    public class GamesController : ApiController
    {
        private IGuessTheNumberData data;

        public GamesController()
            :this(new GuessTheNumberData(new GuessTheNumberDbContext()))
        { }

        public GamesController(IGuessTheNumberData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetUsersCount()
        {
            return Ok(this.data.Users.All().Count());
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int number)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var newGame = new Game();
            newGame.PlayerOneId = currentUserId;
            newGame.NumberPlayerOne = number;

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            return Ok(newGame.Id);
        }

        [HttpPost]
        public IHttpActionResult Join(string gameId, int number)
        {           
            var currentUserId = this.User.Identity.GetUserId();

            var game = this.data.Games.Find(new Guid(gameId));
            if (game == null)
            {
                return BadRequest("There is no such game");
            }

            game.PlayerTwoId = currentUserId;
            game.NumberPlayerTwo = number;
            game.State = GameState.TurnPlayerOne;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost] IHttpActionResult Play(string gameId, int prediction)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var game = this.data.Games.Find(new Guid(gameId));
            if (gameId == null)
            {
                return BadRequest("There is no such game");
            }

            if (game.State == GameState.TurnPlayerOne)
            {
                if (prediction > game.NumberPlayerTwo)
                {
                    return Ok("your number is too high.");
                }
                else
                {

                }
            }
            else if (game.State == GameState.TurnPlayerTwo)
            {
                
            }

            return Ok();
        }
    }
}
