using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int TimerSecondsInterval = 3;
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "MitkoDB";
        private const string CollectionName = "Messages";
        private MongoDatabase database = null;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private User user;

        private int lastEntitiesCount = 0;
   
        private void InitTimer()
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, TimerSecondsInterval);
            this.dispatcherTimer.Start();
        }

        private void InitDatabase()
        {
            var mongoClient = new MongoClient(DatabaseHost);
            var server = mongoClient.GetServer();
            this.database = server.GetDatabase(DatabaseName);
        }

        private void GetMessages()
        {
            var messages =
                this.database.GetCollection<ChatMessage>(CollectionName).FindAll();

            List<string> messageSource;
            if (this.lastEntitiesCount != messages.Count())
            {
                messageSource = new List<string>();

                foreach (var item in messages)
                {
                    string entity = string.Format("[{0}]  {1}: {2}",
                        item.TimeSend, item.User.Name, item.MessageText);

                    messageSource.Add(entity);
                }

                this.listboxMessages.ItemsSource = messageSource;
                this.listboxMessages.ScrollIntoView(messageSource.Last());
                
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.GetMessages();
        }

        public MainWindow()
        {
            InitializeComponent();

            this.user = new User("Mitko", 28);
            this.InitDatabase();
            this.InitTimer();       
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            var messages =
                this.database.GetCollection<ChatMessage>(CollectionName);

            ChatMessage chatMessage = 
                new ChatMessage(this.textMessage.Text, this.user);
            messages.Insert(chatMessage);

            this.textMessage.Text = string.Empty;
        }

        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.buttonSend_Click(sender, null);
            }
        }
    }
}
