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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour UpdateTimeDistance.xaml
    /// </summary>
    public partial class UpdateTimeDistance : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
      //  BO.Line myLine;
       // BO.StationCustom station;
        public UpdateTimeDistance(BO.StationCustom station1)
        {
            InitializeComponent();
            timeDistance_Dg.DataContext = station1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                bl.UpdateStation((timeDistance_Dg.DataContext as BO.StationCustom));
            }
            catch(BO.BadStationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                this.Close();
            }
        }

        // only number are allowed for distance
        private void distanceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex1 = new Regex("[a-zA-Z]");
            e.Handled = regex1.IsMatch(e.Text);

            // if user input = letter
            if (e.Handled)
                MessageBox.Show("only numbers are allowed");
        }

        // only number are allowed for time
        private void timeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex1 = new Regex("[a-zA-Z]");
            e.Handled = regex1.IsMatch(e.Text);

            // if user input = letter
            if (e.Handled)
                MessageBox.Show("only numbers are allowed");
        }
    }
}
