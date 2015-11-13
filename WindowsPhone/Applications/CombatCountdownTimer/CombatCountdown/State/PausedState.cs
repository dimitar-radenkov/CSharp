namespace CombatCountdown.State
{
    using CombatCountdown.Contracts.State;
    using CombatCountdown.State.Contracts;
    using ViewModel;

    public class PausedState : BaseState
    {
        private BaseState prevState;

        public PausedState(IState currentState, MainPageViewModel viewModel)
            :base(viewModel, State.Paused)
        {
            this.prevState = (BaseState)currentState;
            base.IsInProcess = true;        
        }

        public override IState GetNextState()
        {
            this.prevState.Resume();

            return this.prevState;
        }

        public override void Process()
        {
            this.prevState.Pause();
        }
    }
}
