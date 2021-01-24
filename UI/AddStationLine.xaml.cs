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
        BO.StationCustom station = new BO.StationCustom();
        BL.IBL bl = BL.BLFactory.GetBL();

        public AddStationLine(BO.Line line, BO.StationCustom station1)
        {
            InitializeComponent();
            gridLine_id.DataContext = line;

            station1.LineStationIndex = station1.LineStationIndex + 1;
            lineStationIndex.DataContext = station1;
            stationCode.DataContext = station1.Code;
            add_station_to_line.DataContext = station;

            // lineStationIndexTextBox.DataContext = station1.LineStationIndex;
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            var station1 = lineStationIndexTextBox.DataContext as BO.StationCustom;
            int index = station1.LineStationIndex;
            int code = (int)stationCode.DataContext;
            var line = gridLine_id.DataContext as BO.Line;
            try
            {
                bl.AddStationToLine(station, line);
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
