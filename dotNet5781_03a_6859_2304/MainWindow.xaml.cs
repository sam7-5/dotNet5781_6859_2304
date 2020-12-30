using dotNet5781_02_6859_2304;
using System.Windows;
using System.Windows.Controls;

namespace dotNet5781_03a_6859_2304
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BusLine currentDisplayBusLine;
        private BusLineCollection busLigneCollection;
        public MainWindow()
        {
            InitializeComponent();
            //--- personalized icon ---//
            //Uri iconUri = new Uri("youtube.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);

            busLigneCollection = new BusLineCollection();
            cbBusLines.ItemsSource = busLigneCollection;
            cbBusLines.DisplayMemberPath = "Id";
            cbBusLines.SelectedIndex = 0;
            showBusLines((cbBusLines.SelectedValue as BusLine).Id);
        }

        private void showBusLines(int index)
        {
            currentDisplayBusLine = busLigneCollection[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
        }
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showBusLines((cbBusLines.SelectedValue as BusLine).Id);
        }
        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbArea_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
