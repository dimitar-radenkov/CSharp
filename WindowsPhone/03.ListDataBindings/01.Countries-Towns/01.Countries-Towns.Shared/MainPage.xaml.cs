using _01.Countries_Towns.Models;
using _01.Countries_Towns.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _01.Countries_Towns
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            List<Country> countries = new List<Country>()
            {
                new Country("Bulgaria", "Images/bg.png", "bulgarian", 800000, new List<string>(){"Sofia", "Varna", "Pleven"}),
                new Country("England", "Images/en.png", "english", 150000, new List<string>(){"London", "Manchestar", "York"}),
                new Country("Germany", "Images/dn.png", "german", 18888, new List<string>(){"Berlin", "Munich", "Bon"}),

            };
            this.viewModel = new MainPageViewModel(countries);
            this.stackMain.DataContext = this.viewModel;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void comboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selCountry =
                from c in this.viewModel.Countries
                where c.Name == this.comboCountries.SelectedItem.ToString()
                select c;

            if(selCountry != null)
            {
                this.viewModel.Country = (Country)selCountry.FirstOrDefault();
            }
        }
    }
}
