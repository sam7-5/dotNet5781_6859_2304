using System.Windows;
using BL;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        IBL bL = BL.BLFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
            //b1 = new BL.BLImp();

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
