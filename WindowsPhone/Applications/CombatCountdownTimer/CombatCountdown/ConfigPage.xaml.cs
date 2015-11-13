// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CombatCountdown
{
    using CombatCountdown.Common;
    using CombatCountdown.ViewModel;
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Navigation;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfigPage : Page
    {
        private ConfigPageViewModel viewModel;
        private NavigationHelper navigationHelper;

        public ConfigPage()
        {           
            this.InitializeComponent();
      
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            this.viewModel = new ConfigPageViewModel();
            this.DataContext = this.viewModel;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.viewModel.RoundsNumber = GlobalData.GlobalData.Rounds;
            this.viewModel.RestTime = GlobalData.GlobalData.RestLength;
            this.viewModel.RoundTime = GlobalData.GlobalData.RoundLength;
            this.viewModel.WarningTime = GlobalData.GlobalData.WarningLength;

            this.sliderRounds.Value = GlobalData.GlobalData.Rounds;
            this.sliderRestLength.Value = GlobalData.GlobalData.RestLength.TotalSeconds;
            this.sliderRoundLength.Value = GlobalData.GlobalData.RoundLength.TotalSeconds;
            this.sliderWarningLength.Value = GlobalData.GlobalData.WarningLength.TotalSeconds;

            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            GlobalData.GlobalData.Rounds = this.viewModel.RoundsNumber;
            GlobalData.GlobalData.RoundLength = this.viewModel.RoundTime;
            GlobalData.GlobalData.RestLength = this.viewModel.RestTime;
            GlobalData.GlobalData.WarningLength = this.viewModel.WarningTime;

            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void sliderRounds_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (this.sliderRounds != null)
            {
                this.viewModel.RoundsNumber = (int)this.sliderRounds.Value;
            }
        }

        private void sliderRoundLength_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (this.sliderRoundLength != null)
            {
                this.viewModel.RoundTime = TimeSpan.FromSeconds(this.sliderRoundLength.Value);
            }
        }

        private void sliderRestLength_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (this.sliderRestLength != null)
            {
                this.viewModel.RestTime = TimeSpan.FromSeconds(this.sliderRestLength.Value);
            }
        }

        private void sliderWarningLength_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (this.sliderWarningLength != null)
            {
                this.viewModel.WarningTime = TimeSpan.FromSeconds(this.sliderWarningLength.Value);
            }
        }
    }
}
