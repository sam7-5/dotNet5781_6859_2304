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
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            new admin().ShowDialog();
        }


    }
}
