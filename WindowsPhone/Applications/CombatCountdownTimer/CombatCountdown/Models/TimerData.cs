using System;
namespace CombatCountdown.Models
{
    public class TimerData
    {
        public int RoundsCount { get; private set; }
        public TimeSpan RoundTime { get; set; }
        public TimeSpan RestTime { get; private set; }
        public TimeSpan WarningTime { get; private set; }

        public TimerData(int rounds, 
            int rest, 
            int warning)
        {
            this.RoundsCount = rounds;         
        }
    }
}
