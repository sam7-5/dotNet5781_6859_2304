using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour UpdateStation.xaml
    /// </summary>
    public partial class UpdateStation : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        public UpdateStation(BO.Station station)
        {
            InitializeComponent();
            update_stat.DataContext = station;
        }

        private void station_update_Click(object sender, RoutedEventArgs e)
        {
            BO.Station station1;
            station1 = (update_stat.DataContext as BO.Station);
            try
            {
                bl.UpdateStation(station1);
            }
            catch (BO.BadStationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        // only letters allowed for the station name
        private void nameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled)
                MessageBox.Show("only letters are allowed for a station name");
        }
    }
}
