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
        BL.IBL bl;
        public addStation()
        {
            InitializeComponent();
            station = new BO.Station();
            this.DataContext = station;
            BL.IBL bl = BL.BLFactory.GetBL();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // stationViewSource.Source = [source de données générique]
        }

        private void bkbaddStation_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
              //  bl.AddStation(station);
              
                station = new BO.Station();
                this.DataContext = station;
            } 
            catch (Exception ex) //change it!!
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
