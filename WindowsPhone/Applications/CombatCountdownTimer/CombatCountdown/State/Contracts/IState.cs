namespace CombatCountdown.Contracts.State
{
    using CombatCountdown.ViewModel;

    public interface IState
    {
        bool IsInProcess { get; set; }

        void Process();

        IState GetNextState();
    }
}
