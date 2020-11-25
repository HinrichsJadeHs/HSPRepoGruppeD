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

namespace WPFZahnradaufgabeGruppeD
{
    
   
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {         
            InitializeComponent();

            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 objwindow2 = new Window2();
            objwindow2.Show();
        }

        private void Close_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window3 objwindow3 = new Window3();
            objwindow3.Show();           
        }
    }
}
