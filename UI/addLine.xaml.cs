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
    /// Logique d'interaction pour addLine.xaml
    /// </summary>
    public partial class addLine : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        BO.Line myLine=new BO.Line();
        BO.Enums.Area area;
        public addLine()
        {
            InitializeComponent();
          
            gridLine.DataContext = myLine;
            areaCbBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Area));
        }



        private void add_line_Click(object sender, RoutedEventArgs e)
        {
            myLine.FirstStation = Int32.Parse(firstStationTextBox.SelectedValue.ToString());
            myLine.LastStation = Int32.Parse(lastStationTextBox.SelectedValue.ToString());

            try
            {
                bl.AddLine(myLine);
            }
            catch(BO.BadLineIDException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                this.Close();
            }
        }

        private void areaCbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            area = (BO.Enums.Area)areaCbBox.SelectedItem;
            firstStationTextBox.ItemsSource = bl.GetAllStationsOfArea(area);
            this.firstStationTextBox.SelectedValuePath = "Code";
            lastStationTextBox.ItemsSource = bl.GetAllStationsOfArea(area);
            this.lastStationTextBox.SelectedValuePath = "Code";
        }
    }
}
