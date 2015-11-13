namespace CombatCountdown.State
{
    using CombatCountdown.Contracts.State;
    using Contracts;
    using System;
    using System.Threading.Tasks;
    using ViewModel;
    using Windows.Media.Playback;
    using Windows.UI;
    using Windows.UI.Xaml.Media;

    public class RoundRunningState : BaseState
    {
        private Brush brush;

        public RoundRunningState(MainPageViewModel viewModel)
            :base(viewModel, State.RoundRunning)
        {
            this.brush = new SolidColorBrush(Colors.LightGreen);
            BackgroundMediaPlayer.Current.SetUriSource(
                 new Uri(@"ms-appx:///Sounds/boxing-bell.mp3"));
            BackgroundMediaPlayer.Current.Play();
        }

        public override IState GetNextState()
        {
            Task.Delay(TimeSpan.FromSeconds(2));
            return new WarningRunningState(base.viewModel);
        }

        public override void Process()
        {
            var elapsed = base.stopwatch.Elapsed;
            var timeToWarning = GlobalData.GlobalData.RoundLength - GlobalData.GlobalData.WarningLength;
            if (elapsed >= timeToWarning)
            {
                //warning is starting...               
                base.stopwatch.Stop();
                base.stopwatch.Reset();
                base.IsInProcess = false;

                return;
            }

            if (this.viewModel.CountdownTimeBrush != this.brush)
            {
                this.viewModel.CountdownTimeBrush = this.brush;
            }

            var countdownTime = GlobalData.GlobalData.RoundLength - elapsed;

            this.viewModel.CountdownTime = countdownTime;
            this.viewModel.ProgressValue =
                (this.stopwatch.Elapsed.TotalSeconds * 100) / GlobalData.GlobalData.RoundLength.TotalSeconds;
        }
    }
}
