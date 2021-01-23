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

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour addStation.xaml
    /// </summary>
    public partial class addStation : Window
    {
        BO.Station station;
        BL.IBL bl = BL.BLFactory.GetBL();
        public addStation()
        {
            InitializeComponent();
            station = new BO.Station();
            this.DataContext = station;
        }

        private void bkbaddStation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  station = this.DataContext;
                bl.AddStation(station);
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

    }
}
