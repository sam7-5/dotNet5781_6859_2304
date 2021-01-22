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
    /// Logique d'interaction pour AddStationLine.xaml
    /// </summary>
    public partial class AddStationLine : Window
    {
        BO.StationCustom station=new BO.StationCustom();
        BL.IBL bl = BL.BLFactory.GetBL();

        public AddStationLine(BO.Line line,int index)
        {
            InitializeComponent();
            gridLine_id.DataContext = line;
            station.LineStationIndex = index+1;
            add_station_to_line.DataContext = station;
        }

       
      

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            var line = gridLine_id.DataContext as BO.Line;
           bl.AddStationToLine(station, line);
            this.Close();

        }
    }
}
