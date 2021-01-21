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
    /// Logique d'interaction pour line.xaml
    /// </summary>
    public partial class line : Page
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        BO.Line myLine;
        public line()
        {
            InitializeComponent();
            allLines.DataContext = bl.GetAllLines();
        }

        private void allLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myLine = (allLines.SelectedItem as BO.Line);
            if (myLine != null)
            {
                stationCustomDataGrid.DataContext = bl.GetAllCusStationOfLine(myLine);
            }
        }

        private void delete_line_Click(object sender, RoutedEventArgs e)
        {
            myLine = (allLines.SelectedItem as BO.Line);
            try
            {
                if (myLine == null)
                    throw new NullReferenceException();
               
            }
            catch(NullReferenceException )
            {
                    MessageBox.Show("you have to select a line", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
               bl.DeleteLine(myLine.Id);

            allLines.DataContext = bl.GetAllLines();
        }

        private void add_line_Click(object sender, RoutedEventArgs e)
        {
            addLine addLine = new addLine();
            addLine.ShowDialog();
            allLines.DataContext = bl.GetAllLines();
            stationCustomDataGrid.DataContext = bl.GetAllCusStationOfLine(myLine);
        }

        private void update_line_Click(object sender, RoutedEventArgs e)
        {
            UpdateLine update = new UpdateLine(myLine);
            update.ShowDialog();
            stationCustomDataGrid.DataContext = bl.GetAllCusStationOfLine(myLine);
        }
    }
}
