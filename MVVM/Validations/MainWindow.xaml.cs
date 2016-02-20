namespace Validations
{
    using Models;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.spMain.DataContext = new Student("Mitko", 22);
        }
    }
}
