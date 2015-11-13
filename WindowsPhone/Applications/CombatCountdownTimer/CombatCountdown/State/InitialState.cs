namespace CombatCountdown.State
{
    using CombatCountdown.Contracts.State;
    using CombatCountdown.State.Contracts;
    using CombatCountdown.ViewModel;
    using Windows.UI;
    using Windows.UI.Xaml.Media;

    public class InitialState : BaseState
    {
        private Brush brush;

        public InitialState(MainPageViewModel viewModel)
            :base(viewModel, State.Initial)
        {
            base.viewModel = viewModel;
            base.viewModel.CurrentRound = 1;
            this.brush = new SolidColorBrush(Colors.White);

            if (this.viewModel.CountdownTimeBrush != this.brush)
            {
                this.viewModel.CountdownTimeBrush = this.brush;
            }
        }

        public override IState GetNextState()
        {
            return new RoundRunningState(base.viewModel);
        }

        public override void Process()
        {
            base.IsInProcess = false;         
        }
    }
}
