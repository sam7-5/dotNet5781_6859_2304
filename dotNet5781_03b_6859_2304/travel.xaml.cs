using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void enter(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                this.Close();
            }
        }
    }
}
