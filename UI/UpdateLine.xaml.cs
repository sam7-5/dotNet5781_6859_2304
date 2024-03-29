﻿using System;
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
    /// Logique d'interaction pour UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        BL.IBL bl = BL.BLFactory.GetBL();
        BO.StationCustom station1;
        BO.StationCustom station;
        public UpdateLine(BO.Line myLine)
        {
            InitializeComponent();
            line_update.DataContext = myLine;
            line_stations_datagd.DataContext = bl.GetAllCusStationOfLine(myLine);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            var line = line_update.DataContext as BO.Line;
            station = line_stations_datagd.SelectedItem as BO.StationCustom;

            AddStationLine addStationLine = new AddStationLine(line, station);
            addStationLine.ShowDialog();
            line_stations_datagd.DataContext = bl.GetAllCusStationOfLine(line);
        }

        private void update_timeDistance_Click(object sender, RoutedEventArgs e)
        {
            station1 = line_stations_datagd.SelectedItem as BO.StationCustom;

            UpdateTimeDistance updateTimeDistance = new UpdateTimeDistance(station1);
            updateTimeDistance.ShowDialog();
        }

        private void delete_station_Click(object sender, RoutedEventArgs e)
        {
            var line = line_update.DataContext as BO.Line;
            station = line_stations_datagd.SelectedItem as BO.StationCustom;

            try { bl.DeleteStationOfLine(line, station); }
            catch (BO.BadLineIDException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                line_stations_datagd.DataContext = bl.GetAllCusStationOfLine(line);
            }
        }

        private void line_stations_datagd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var line = line_update.DataContext as BO.Line;

            station = line_stations_datagd.SelectedItem as BO.StationCustom;
        }
    }
}
