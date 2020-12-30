using System.Windows;
using System.Windows.Input;

namespace dotNet5781_03b_6859_2304
{
    /// <summary>
    /// Logique d'interaction pour travel.xaml
    /// </summary>
    public partial class travel : Window
    {
        public travel()
        {
            InitializeComponent();
        }



        //private void enter(object sender, KeyEventArgs e)
        //{


        //    //   string aa = current.License;
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _contentLoaded;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
                add();
            }
        }
        private void add()
        {
            string distanceToTravel = this.distance.Text;
            int distance = 0;
            Bus busSelected = DataContext as Bus;
            bool temp = true;
            temp = int.TryParse(distanceToTravel, out distance);
            if (!temp)
            {
                MessageBox.Show("you must not enter letters but only numbers!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (busSelected.CanTravel(distance))
                {
                    //lancer thread progress bar
                    busSelected.Kilometrage = distance;
                    busSelected.FuelTank -= distance;
                }
                else
                {
                    MessageBox.Show("not enough fuel or maintain required", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
