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


    public class WarningRunningState : BaseState
    {
        private Brush brush;

        public WarningRunningState(MainPageViewModel viewModel)
            :base(viewModel, State.WarningRunning)
        {
            this.brush = new SolidColorBrush(Colors.Orange);
            BackgroundMediaPlayer.Current.SetUriSource(
                     new Uri(@"ms-appx:///Sounds/warning.mp3"));
            BackgroundMediaPlayer.Current.Play();
        }

        public override IState GetNextState()
        {
            Task.Delay(TimeSpan.FromSeconds(2));
            return new RestRunningState(base.viewModel);
        }

        public override void Process()
        {
            var elapsed = base.stopwatch.Elapsed;          
            if (elapsed >= GlobalData.GlobalData.WarningLength)
            {
                //round has finished
                base.viewModel.CurrentRound++;
                base.stopwatch.Stop();
                base.stopwatch.Reset();
                base.IsInProcess = false;

                return;
            }

            if (this.viewModel.CountdownTimeBrush != this.brush)
            {
                this.viewModel.CountdownTimeBrush = this.brush;
            }

            var countdownTime = GlobalData.GlobalData.WarningLength - elapsed;

            this.viewModel.CountdownTime = countdownTime;

            var additionalProgress =
                (GlobalData.GlobalData.RoundLength - GlobalData.GlobalData.WarningLength).TotalSeconds * 100 /
                GlobalData.GlobalData.RoundLength.TotalSeconds;

            var currentProgress =
                (elapsed.TotalSeconds * 100) / GlobalData.GlobalData.RoundLength.TotalSeconds;

            this.viewModel.ProgressValue =
                currentProgress + additionalProgress;
        }
    }
}
