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
    /// Logique d'interaction pour UpdateStation.xaml
    /// </summary>
    public partial class UpdateStation : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        //   BO.Station station;
        public UpdateStation(BO.Station station)
        {
            InitializeComponent();
            update_stat.DataContext = station;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //{

            //  //  System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            //    // Charger les données en définissant la propriété CollectionViewSource.Source :
            //    // stationViewSource.Source = [source de données générique]
        }


        private void station_update_Click(object sender, RoutedEventArgs e) //jette error
        {
            BO.Station station1;
            station1 = (update_stat.DataContext as BO.Station);
            try
            {
                bl.UpdateStation(station1);
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
    }
}
