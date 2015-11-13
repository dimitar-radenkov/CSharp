using System;
namespace GuessTheNumber.Web.Models
{
    public class GameInfoResponseModel
    {
        public Guid Id { get; set; }

        public int PlayerOneNumber { get; set; }

        public int PlayerTwoNumber { get; set; }
    }
}