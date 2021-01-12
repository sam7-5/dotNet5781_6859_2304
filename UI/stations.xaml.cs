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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace UI
{
    /// <summary>
    /// Logique d'interaction pour stations.xaml
    /// </summary>
    public partial class stations : Page
    {
        BL.IBL bl = BL.BLFactory.GetBL();

        public stations()
        {
            InitializeComponent();
            allStations.DataContext = bl.GetAllStations();

        }

        private void allStations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            station = (allStations.SelectedItem as BO.Station);
            gridOneStation.DataContext = station;

            /*
            if (station != null)
            {
              //  nextStations.DataContext = station.getNextStations.ToList();
              //   previousStations.DataContext = station.getPreviousStations.ToList();
              //  busPassesTrough.DataContext = station.getAllbusPassThrough.ToList();
            }

        }



        private void add_station_Click(object sender, RoutedEventArgs e)
        {
            addStation station = new addStation();
            station.Show();
        }

        private void delete_station_Click(object sender, RoutedEventArgs e)
        {

        }

        private void update_station_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (station != null)
            //        BL.UpdateStudentPersonalDetails(station);
            //}
            //catch (BO.BadStationIdException ex)
            //{
            //    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

    }
}
