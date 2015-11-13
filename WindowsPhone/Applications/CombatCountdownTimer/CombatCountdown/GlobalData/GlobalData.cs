namespace CombatCountdown.GlobalData
{
    using System;

    public static class GlobalData
    {
        public static int Rounds { get; set; }
        public static TimeSpan RoundLength { get; set; }
        public static TimeSpan RestLength { get; set; }
        public static TimeSpan WarningLength { get; set; }

        static GlobalData()
        {
            Rounds = 8;
            RoundLength = TimeSpan.FromMinutes(3);
            RestLength = TimeSpan.FromMinutes(1);
            WarningLength = TimeSpan.FromSeconds(10);
        }
    }
}
