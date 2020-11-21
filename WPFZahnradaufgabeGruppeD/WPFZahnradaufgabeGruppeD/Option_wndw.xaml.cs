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

namespace WPFZahnradaufgabeGruppeD
{
    /// <summary>
    /// Interaktionslogik für Option_wndw.xaml
    /// </summary>
    public partial class Option_wndw : Window
    {
        
        public Option_wndw()
        {
         
            InitializeComponent();

        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
