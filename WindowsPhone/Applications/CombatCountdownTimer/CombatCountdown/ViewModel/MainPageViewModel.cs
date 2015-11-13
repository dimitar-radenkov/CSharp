namespace CombatCountdown.ViewModel
{
    using CombatCountdown.ViewModel.Contracts;
    using System;
    using Windows.UI.Xaml.Media;

    public class MainPageViewModel : ViewModelBase
    {
        private int rounds;
        public int Rounds 
        {
            get
            {
                return this.rounds;
            }
            set
            {
                this.rounds = value;
                this.OnPropertyChanged(nameof(this.RoundsInfo));
            }
 
        }

        private int currentRound;
        public int CurrentRound
        {
            get
            {
                return this.currentRound;
            }
            set
            {
                this.currentRound = value;
                this.OnPropertyChanged(nameof(this.RoundsInfo));
            }

        }

        private double progressValue;
        public double ProgressValue
        {
            get
            {
                return this.progressValue;
            }
            set
            {
                this.progressValue = value;
                this.OnPropertyChanged(nameof(this.ProgressValue));
            }

        }

        private TimeSpan countdownTime;
        public TimeSpan CountdownTime
        {
            get { return this.countdownTime; }
            set
            {
                this.countdownTime = value;
                this.OnPropertyChanged(nameof(this.TimeRunning));
            }
        }

        public TimeSpan CurrentActivityLength { get; set; }

        private Brush countdownTimeBrush;
        public Brush CountdownTimeBrush
        {
            get { return this.countdownTimeBrush; }
            set
            {
                this.countdownTimeBrush = value;
                this.OnPropertyChanged(nameof(this.ForegroundColor));
            }
        }      

        private TimeSpan roundLength;
        public TimeSpan RoundLength
        {
            get { return this.roundLength; }
            set
            {
                this.roundLength = value;
                this.OnPropertyChanged(nameof(this.Round));
            }
        }

        private TimeSpan restLength;
        public TimeSpan RestLength
        {
            get { return this.restLength; }
            set
            {
                this.restLength = value;
                this.OnPropertyChanged(nameof(this.Rest));
            }
        }


        private TimeSpan warningLength;
        public TimeSpan WarningLength
        {
            get { return this.warningLength; }
            set
            {
                this.warningLength = value;
                this.OnPropertyChanged(nameof(this.Warning));
            }
        }

        public MainPageViewModel(int rounds, 
            TimeSpan countdownTime, 
            TimeSpan roundLength, 
            TimeSpan restLength, 
            TimeSpan warningLength)
        {
            this.countdownTime = new TimeSpan();

            this.Rounds = rounds;
            this.CountdownTime = countdownTime;
            this.RoundLength = roundLength;
            this.RestLength = restLength;
            this.WarningLength = warningLength;

            this.CurrentRound = 1;
        }

        public Brush ForegroundColor
        {
            get
            {
                return this.CountdownTimeBrush;
            }
        }

        public string RoundsInfo 
        {
            get
            {
                return string.Format("{0} / {1}",
                    this.CurrentRound,
                    this.Rounds);
            } 
        }

        public string TimeRunning
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:000}",
                    this.CountdownTime.Minutes,
                    this.CountdownTime.Seconds,
                    this.CountdownTime.Milliseconds);
            }
        }

        public string Round
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.RoundLength.Minutes,
                    this.RoundLength.Seconds);
            }
        }

        public string Rest
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.RestLength.Minutes,
                    this.RestLength.Seconds);
            }
        }

        public string Warning
        {
            get
            {
                return string.Format("{0}:{1:00}",
                    this.WarningLength.Minutes,
                    this.WarningLength.Seconds);
            }
        }       
    }
}