namespace CombatCountdown.State.Contracts
{
    using CombatCountdown.Contracts.State;
    using ViewModel;
    using System.Diagnostics;

    public abstract class BaseState : IState
    {
        protected MainPageViewModel viewModel;
        protected Stopwatch stopwatch;
        protected State description;

        public bool IsInProcess { get; set; }

        public BaseState(MainPageViewModel viewModel, State description)
        {
            this.IsInProcess = true;
            this.viewModel = viewModel;
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
            this.description = description;
        }

        public void Pause()
        {
            this.stopwatch.Stop();
        }

        public void Resume()
        {
            this.stopwatch.Start();
        }

        public abstract void Process();

        public abstract IState GetNextState();
    }
}
