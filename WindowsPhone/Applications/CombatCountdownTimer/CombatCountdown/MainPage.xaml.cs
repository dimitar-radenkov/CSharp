// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
namespace CombatCountdown
{
    using Contracts.State;
    using CombatCountdown.ViewModel;
    using System;
    using System.Diagnostics;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using State;
    using Windows.UI;
    using Windows.UI.Xaml.Media;
    using Windows.Media.Playback;
    using Windows.System.Display;
    using System.Threading.Tasks;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel viewModel;
        private DispatcherTimer timer;
        private IState currentState;
        private DisplayRequest keepScreenOnRequest;

        public MainPage()
        {          
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.viewModel = new MainPageViewModel(
                 GlobalData.GlobalData.Rounds,
                 GlobalData.GlobalData.RoundLength,
                 GlobalData.GlobalData.RoundLength,
                 GlobalData.GlobalData.RestLength,
                 GlobalData.GlobalData.WarningLength);

            this.gridMain.DataContext = this.viewModel;

            this.timer = new DispatcherTimer();
            this.timer.Tick += timer_Tick;
            this.timer.Interval = TimeSpan.FromMilliseconds(20);

            this.currentState = new InitialState(this.viewModel);

            this.keepScreenOnRequest = new Windows.System.Display.DisplayRequest();
            this.keepScreenOnRequest.RequestActive();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.viewModel.Rounds = GlobalData.GlobalData.Rounds;
            this.viewModel.RoundLength = GlobalData.GlobalData.RoundLength;
            this.viewModel.RestLength = GlobalData.GlobalData.RestLength;
            this.viewModel.WarningLength = GlobalData.GlobalData.WarningLength;

            this.buttonReset_Click(null, null);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (this.buttonStart.Content.ToString() == "Start" || 
                this.buttonStart.Content.ToString() == "Resume")
            {
                this.timer.Start();
                this.buttonStart.Content = "Pause";
                this.currentState.IsInProcess = false;     
            }
            else
            { 
                this.buttonStart.Content = "Resume";
                this.currentState = 
                    new PausedState(this.currentState, this.viewModel);
            }                        
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        { 
            this.buttonStart.Content = "Start";

            this.viewModel.CountdownTime = this.viewModel.RoundLength;
            this.viewModel.ProgressValue = 0;

            this.timer.Stop();
            this.currentState = new InitialState(this.viewModel);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ConfigPage));
        }

        private void timer_Tick(object sender, object e)
        {
            if (this.viewModel.CurrentRound > GlobalData.GlobalData.Rounds)
            {
                //all rounds have been passed
                this.buttonReset_Click(null, null);
                return;
            }

            if (this.currentState.IsInProcess)
            {
                this.currentState.Process();
            }
            else
            {
                this.currentState = this.currentState.GetNextState();         
            }                 
        }
    }
}
