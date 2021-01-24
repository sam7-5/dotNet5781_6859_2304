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
        BO.Station station;
        public stations()
        {
            InitializeComponent();
            allStations.DataContext = bl.GetAllStations();
        }

        private void add_station_Click(object sender, RoutedEventArgs e)
        {
            addStation station = new addStation();
            station.ShowDialog();
            allStations.DataContext = bl.GetAllStations();
        }

        private void delete_station_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sorry not implemented yet");
        }

        private void update_station_Click(object sender, RoutedEventArgs e)
        {
            if (station == null)
            {
                MessageBox.Show("please select a station to update");
                return;
            }

            UpdateStation updateStation = new UpdateStation(station);
            updateStation.ShowDialog();
            allStations.DataContext = bl.GetAllStations();
        }

        private void allStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            station = allStations.SelectedItem as BO.Station;
            gridOneStation.DataContext = station;
            previousStations.DataContext = bl.GetAllPrevCusStations(station);
            nextStations.DataContext = bl.GetAllNextCusStations(station);
            busPassesTrough.DataContext = bl.GetAllLinesPassThrough(station);
        }

        private void nextStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
