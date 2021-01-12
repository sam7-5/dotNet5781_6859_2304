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
        BO.Station station ;
        public stations()
        {
            InitializeComponent();
            allStations.DataContext=BL.getAllStations.ToList();

        }

        private void allStations_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            station = (allStations.SelectedItem as BO.Station);
            // gridOneStudent.DataContext = curStu;
            busPassesTrough.DataContext = station.getAllbusPassThrough.ToList();
            nextStations.DataContext=station.getNextStations.ToList();
            previousStations.DataContext = station.getPreviousStations.ToList();

            if (station != null)
            {
                //list of courses of selected student
                //RefreshAllRegisteredCoursesGrid();
                //list of all courses (that selected student is not registered to it)
                //RefreshAllNotRegisteredCoursesGrid();
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

        }

    }
}
