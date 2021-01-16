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
        BO.Line myLine;
        BO.Enums.Area area;
        public addLine()
        {
            InitializeComponent();
            areaCbBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Area));     
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // System.Windows.Data.CollectionViewSource lineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // lineViewSource.Source = [source de données générique]
        }

        private void add_line_Click(object sender, RoutedEventArgs e)
        {
            myLine = (BO.Line)this.DataContext;
            bl.AddLine(myLine);
            this.Close();
        }

        

        private void areaCbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            area = (BO.Enums.Area)areaCbBox.SelectedItem ;
            firstStationTextBox.ItemsSource = bl.GetAllStationsOfArea(area);
            lastStationTextBox.ItemsSource = bl.GetAllStationsOfArea(area);

        }
    }
}
