using System.Windows;

namespace dotNet5781_03b_6859_2304
{
    /// <summary>
    /// Logique d'interaction pour BusSettings.xaml
    /// </summary>
    public partial class BusSettings : Window
    {
        //private static ObservableCollection<Bus> _myCollection = new ObservableCollection<Bus>();
        // public Bus buse { get; set; }
        public BusSettings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _contentLoaded;
        }

        private void maintain_Click(object sender, RoutedEventArgs e)
        {
            Bus bus = DataContext as Bus;
            bus.Maintain();

        }
    }
}
