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

namespace dotNet5781_03a_6859_2304
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private dotNet5781_02_6859_2304.BusLigne currentDisplayBusLine;
        public MainWindow()
        {
            InitializeComponent();
            dotNet5781_02_6859_2304.BusLigneCollection busLigneCollection = new dotNet5781_02_6859_2304.BusLigneCollection();

            cbBusLines.ItemsSource = busLigneCollection;
            cbBusLines.DisplayMemberPath = " BusLineNum ";
            cbBusLines.SelectedIndex = 0;
            showBusLines(cbBusLines.SelectedIndex);
            void showBusLines(int Index)
            {
                currentDisplayBusLine = busLigneCollection[index];
                UpGrid.DataContext = currentDisplayBusLine;
                lbBusLineStations.DataContext = currentDisplayBusLine.Stations;

            }

        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).BusLineNum);

        }

        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ListBox.DataContextProperty = cbBusLines[ComboBox.SelectedIndexProperty].index;
        }
    }
}
