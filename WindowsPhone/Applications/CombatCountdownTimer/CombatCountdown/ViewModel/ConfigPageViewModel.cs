namespace CombatCountdown.ViewModel
{
    using CombatCountdown.ViewModel.Contracts;
    using System;

    public class ConfigPageViewModel : ViewModelBase
    {
        private int roundsNumber;
        public int RoundsNumber
        {
            get
            {
                return this.roundsNumber;
            }
            set
            {
                this.roundsNumber = value;
                this.OnPropertyChanged(nameof(this.RoundsNumber));
                this.OnPropertyChanged(nameof(this.Rounds));
            }
        }

        private TimeSpan roundTime;
        public TimeSpan RoundTime
        {
            get
            {
                return this.roundTime;
            }
            set
            {
                this.roundTime = value;
                this.OnPropertyChanged(nameof(this.RoundLength));
            }
        }

        private TimeSpan restTime;
        public TimeSpan RestTime
        {
            get
            {
                return this.restTime;
            }
            set
            {
                this.restTime = value;
                this.OnPropertyChanged(nameof(this.RestLength));
            }
        }


        private TimeSpan warningTime;
        public TimeSpan WarningTime
        {
            get
            {
                return this.warningTime;
            }
            set
            {
                this.warningTime = value;
                this.OnPropertyChanged(nameof(this.WarningLength));
            }
        }


        public ConfigPageViewModel(
            int roundsNumber,
            TimeSpan roundTime,
            TimeSpan restTime,
            TimeSpan warningTime)
        {
            this.RoundsNumber = roundsNumber;
            this.RoundTime = roundTime;
            this.RestTime = restTime;
            this.WarningTime = warningTime;
        }

        public ConfigPageViewModel()
            : this(0, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0))
        {

        }

        public string Rounds
        {
            get { return this.RoundsNumber.ToString(); }
        }


        public string RoundLength
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.RoundTime.Minutes,
                    this.RoundTime.Seconds);
            }
        }


        public string RestLength
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.RestTime.Minutes,
                    this.RestTime.Seconds);
            }
        }


        public string WarningLength
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.WarningTime.Minutes,
                    this.WarningTime.Seconds);
            }
        }

    }
}
