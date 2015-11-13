namespace SimpleChat.UI
{
    using Models.UI;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ObservableCollection<MessageViewModel> ListMessages { get; private set; }
        public IEnumerable<string> Participants { get; private set; }
        public int ChatId { get; private set; }

        public ChatWindow(IEnumerable<string> participants, string name)
        {
            this.ChatId =
                Network.NetworkDriver.AddIfNoExistingChat("Default topic", participants);

            this.ListMessages = new ObservableCollection<MessageViewModel>();
            this.Participants = participants;     
            InitializeComponent();

            this.Title = name;
            this.stackMessages.ItemsSource = this.ListMessages;
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            Network.NetworkDriver.AddMessage(
                this.textMessage.Text, this.ChatId);

            this.textMessage.Text = string.Empty;
        }

        private void textMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.textMessage.Text == string.Empty)
            {
                this.buttonSend.IsEnabled = false;
            }
            else
            {
                this.buttonSend.IsEnabled = true;
            }
        }
    }
}
