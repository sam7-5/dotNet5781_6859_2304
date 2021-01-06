using System.Windows;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static BL.myBL b1;
        public MainWindow()
        {
            InitializeComponent();
            b1 = new BL.myBL();

        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            new users().ShowDialog();
        }


        private void admin_Click(object sender, RoutedEventArgs e)
        {
            new admin().ShowDialog();
        }
       
    }
}
