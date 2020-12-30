using System.Windows;
using System.Windows.Controls;

namespace dotNet5781_03b_6859_2304
{
    /// <summary>
    /// Logique d'interaction pour addWin.xaml
    /// </summary>
    public partial class addWin : Window
    {
        public addWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void dateInputNewBus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void idInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
