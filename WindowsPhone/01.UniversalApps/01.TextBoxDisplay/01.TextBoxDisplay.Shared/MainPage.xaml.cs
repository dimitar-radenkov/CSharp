// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _01.TextBoxDisplay
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void textSample_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog(string.Format(
                "You have selected '{0}'", this.textSample.Text));

            await msgbox.ShowAsync();
        }
    }
}
