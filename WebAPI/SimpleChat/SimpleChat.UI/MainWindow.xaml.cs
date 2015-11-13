namespace SimpleChat.UI
{
    using Model.UI;
    using Network;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, ChatWindow> listChatWindows;
        private ObservableCollection<ContactViewModel> listContactsViewModels;

        public MainWindow()
        {
            this.listContactsViewModels = new ObservableCollection<ContactViewModel>();

            LoginWindow loginWindow = new LoginWindow();
            if(loginWindow.ShowDialog() != true)
            {
                return;
            }

            //contacts background service
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    System.Console.WriteLine("Get Contacts Running...");          
                    var contacts = NetworkDriver.GetAllContacts();
                    foreach (var item in contacts)
                    {
                        var contact =
                            (from c in this.listContactsViewModels
                                where c.UserId == item.UserId
                                select c).FirstOrDefault();

                        this.Dispatcher.Invoke(() =>
                        {                         
                            if (contact != null)
                            {
                                contact.Status = item.Status;
                                this.listContacts.Items.Refresh();
                                System.Console.WriteLine(contact.Status);
                            }
                            else
                            {
                                this.listContactsViewModels.Add(item);
                            }    
                        });                       
                    }                   
                    Thread.Sleep(5000);
                }
            });

            //message background service
            Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    System.Console.WriteLine("Message background service running...");

                    var messages = NetworkDriver.GetNewMessages();
                    foreach (var msg in messages)
                    {
                        System.Console.WriteLine(string.Format("{0} {1} {2}", msg.ChatId, msg.Content, msg.MessageId));
                        if (this.listChatWindows.Count > 0)
                        {
                            var window = this.listChatWindows[msg.ChatId];
                            this.Dispatcher.Invoke(() =>
                            {
                                if (!window.ListMessages.Any(x => x.MessageId == msg.MessageId))
                                {
                                    window.ListMessages.Add(msg);
                                    System.Console.WriteLine("msg added " + msg.Content);

                                    if (msg.SenderId != NetworkDriver.LoggedUserId)
                                    {
                                        NetworkDriver.ChangeMessageStatus(msg.MessageId, Models.MessageStatus.Received);
                                        System.Console.WriteLine("message status has been changed to received");
                                    }                              
                                }
                            });
                        }
                        else
                        {
                            var contact = this.listContactsViewModels.FirstOrDefault(
                                    x => x.UserId == msg.SenderId);

                            //there aren't open chat window
                            this.Dispatcher.Invoke(() =>
                            {
                                if (contact != null)
                                {
                                    contact.VisibleString = "Visible";
                                    this.listContacts.Items.Refresh();
                                }
                            });
                        }
                    }                   
                    Thread.Sleep(3000);
                }        
            });
            
            InitializeComponent();

            this.listContacts.ItemsSource = this.listContactsViewModels;
            this.listChatWindows = new Dictionary<int, ChatWindow>();
        }

        private void listContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> participants = new List<string>();
            var selectedContact = this.listContacts.SelectedItem as ContactViewModel;
            if (selectedContact != null)
            {
                participants.Add(selectedContact.UserId);

                var chat =
                    (from c in this.listChatWindows.Values
                    where c.Participants.SequenceEqual(participants)
                    select c).FirstOrDefault();

                if (chat == null)
                {
                    chat = new ChatWindow(participants, selectedContact.Username);
                    chat.Closed += ChatWindowClosed;
                    this.listChatWindows.Add(chat.ChatId, chat);

                    Debug.WriteLine("new chat created");
                }

                Debug.WriteLine(string.Join(", ", chat.Participants));
                chat.Show();
                selectedContact.VisibleString = "Hidden";
                this.listContacts.Items.Refresh();      
            }
        }

        private void ChatWindowClosed(object sender, System.EventArgs e)
        {
            ChatWindow currentChatWindow = sender as ChatWindow;
            if (currentChatWindow != null && 
                this.listChatWindows.ContainsKey(currentChatWindow.ChatId))
            {
                this.Dispatcher.Invoke(()=> 
                {
                    this.listChatWindows.Remove(currentChatWindow.ChatId);
                });         
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            NetworkDriver.ChangeUserStatus(Models.UserStatus.Offline);
        }
    }
}
