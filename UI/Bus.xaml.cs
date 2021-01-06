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
using UI.PO;
namespace UI
{
    /// <summary>
    /// Logique d'interaction pour Bus.xaml
    /// </summary>
    public partial class Bus : Page
    {
        public Bus()
        {
            InitializeComponent();
            DateTime date = DateTime.Now;
            Bus bus = new Bus(123, date, 45, 89, Enums.BusStatus.Available);
            busDataGrid.Items.Add(bus);

        }
        #region demo
        public Bus(int v1, DateTime date, int v2, int v3, Enums.BusStatus available)
        {
            LicenseNum = v1;
            FromDate = date;
            TotalTrip = v2;
            FuelRemain = v3;
            Status = available;
        }

        public int LicenseNum { get; }
        public DateTime FromDate { get; }
        public int TotalTrip { get; }
        public int FuelRemain { get; }
        public Enums.BusStatus Status { get; }

        #endregion
        private void busRefuel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void maintain_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
