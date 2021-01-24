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
using System.Text.RegularExpressions;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour addStation.xaml
    /// </summary>
    public partial class addStation : Window
    {
        BO.Station station;
        BL.IBL bl = BL.BLFactory.GetBL();
        public addStation()
        {
            InitializeComponent();
            station = new BO.Station();
            this.DataContext = station;
            //this.DataContext = "";
        }

        private void bkbaddStation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  station = this.DataContext;
                bl.AddStation(station);
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

        // only letters for station name
        private void nameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled)
                MessageBox.Show("only letters are allowed for a station name");
        }
        // only numbers for station code
        private void codeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled)
                MessageBox.Show("only numbers are allowed for a station code");
        }
        // only numbers for lattitude
        private void lattitudeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex1 = new Regex("[a-zA-Z]");
            //Regex regex2 = new Regex("[^0]");//[1-9][0-9]*

            e.Handled = regex1.IsMatch(e.Text);

            // if user input = letter
            if (e.Handled)
                MessageBox.Show("only numbers are allowed");

            // if input begin with zero
            /*
            if (regex2.IsMatch(e.Text))
            {
                MessageBox.Show("can't be only zero");
                e.Handled = true;
            }
            */
        }
        // only numbers for longitude
        private void longitudeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled)
                MessageBox.Show("only numbers are allowed");
        }
    }
}
