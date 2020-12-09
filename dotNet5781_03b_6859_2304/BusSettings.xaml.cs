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
            this.DataContext =_contentLoaded ;
        }
    }
}
