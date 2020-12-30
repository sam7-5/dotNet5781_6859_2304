using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace dotNet5781_03b_6859_2304
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Bus> _myCollection = new ObservableCollection<Bus>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _myCollection;
            List<Bus> buses = Bus.CreateListOfBuses();

            foreach (var item in buses)
            {
                _myCollection.Add(item);
            }
        }

        private void Click_AddBus(object sender, RoutedEventArgs e)
        {
            // create a new "addWin" window
            addWin win = new addWin();
            win.Show();

        }
        private void DoubleClick_BusSettings(object sender, RoutedEventArgs e)
        {
            // create a "BusSettings" window
            BusSettings settings = new BusSettings();
            settings.DataContext = lbBus.SelectedItem;
            settings.Show();
        }


        private void Click_Refuel(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Bus currentuser = btn.DataContext as Bus;
            btn.IsEnabled = false;
            tidluk(currentuser, 3000, btn);
        }

        private void tidluk(Bus lineData, int time, Button btn)
        {
            List<Object> lst = new List<object> { lineData, time, btn };

            BackgroundWorker tidluk = new BackgroundWorker();
            tidluk.DoWork += Tidluk_DoWork;
            tidluk.RunWorkerCompleted += Tidluk_RunWorkerCompleted;
            btn.Background = Brushes.LawnGreen;
            tidluk.RunWorkerAsync(lst);
        }
        private void Tidluk_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> lst = (List<object>)e.Argument;

            //idkun delek acharei hamiluy
            Bus currentUser = lst[0] as Bus;
            //currentUser.FuelTank = 1200;
            currentUser.Refuel();//tank fill up

            int value = (int)lst[1];
            //ProgressBar bar = new ProgressBar();
            //bar.Value=5;
            Thread.Sleep(value);

            e.Result = lst[2];
        }
        private void Tidluk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button btn = e.Result as Button;
            btn.IsEnabled = true;
            btn.Background = Brushes.MintCream;
        }


        private void Click_Travel(object sender, RoutedEventArgs e)
        {
            travel travel1 = new travel();
            travel1.Show();

            Button btn = sender as Button;
            Bus currentuser = btn.DataContext as Bus;
            // string aa = currentuser;
            travel1.DataContext = currentuser;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContentControl content = new ContentControl();
        }



        // private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //   {
        //ProgressBar bar = new ProgressBar();
        //bar.IsEnabled = true;
        //bar.Maximum = 10;
        //bar.Value=5;
        //bar.Background = Brushes.Red;            
        //   bar.IsIndeterminate = true;        
        //  }
    }
}
