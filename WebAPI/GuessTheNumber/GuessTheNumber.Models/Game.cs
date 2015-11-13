namespace GuessTheNumber.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.State = GameState.WaitingForPlayer;
        }

        public Guid Id { get; set; }

        public GameState State { get; set; }

        [Range(1, 1000)]
        public int NumberPlayerOne { get; set; }

        public int NumberPlayerTwo { get; set; }

        public string PlayerOneId { get; set; }

        public virtual User PlayerOne { get; set; }

        public string PlayerTwoId { get; set; }

        public virtual User PlayerTwo { get; set; }
    }
}
