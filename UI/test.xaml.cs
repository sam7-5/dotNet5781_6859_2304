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
    /// Logique d'interaction pour test.xaml
    /// </summary>
    public partial class test : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        BO.StationCustom station;
        public test()
        {
            InitializeComponent();
            stationCustomDataGrid.DataContext = bl.GetAllCustomStations();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource stationCustomViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stationCustomViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // stationCustomViewSource.Source = [source de données générique]
        }
    }
}
