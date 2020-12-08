using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace dotNet5781_03b_6859_2304
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Bus> _myCollection = new ObservableCollection<Bus>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _myCollection;
            _myCollection.Add(new Bus());
        }

        private void Click_AddBus(object sender, RoutedEventArgs e)
        {
            addWin win = new addWin();
            win.Show();
        }


        private void Click_Refuel(object sender, RoutedEventArgs e)
        {
            refuel refuel1 = new refuel();
            refuel1.Show();
        }
        private void Click_Travel(object sender, RoutedEventArgs e)
        {
            travel travel1 = new travel();
            travel1.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
