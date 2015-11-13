namespace SimpleChat.UI
{
    using SimpleChat.UI.Network;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NetworkDriver.Login(
                    this.textUsername.Text,
                    this.passwordPass.Password);

                this.DialogResult = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NetworkDriver.Register(
                    this.textRegisterUsername.Text,
                    this.passwordRegisterPass.Password,
                    this.passwordRegisterConfirmPass.Password);

                MessageBox.Show("User registered ! You can login now !");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
    }
}
