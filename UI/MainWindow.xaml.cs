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
    }
}
