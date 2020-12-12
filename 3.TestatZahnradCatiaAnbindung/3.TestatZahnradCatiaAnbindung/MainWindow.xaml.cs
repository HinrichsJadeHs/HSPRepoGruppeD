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



namespace _3.TestatZahnradCatiaAnbindung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Aussenverzahnung_Click(object sender, RoutedEventArgs e)
        {
            Zahnrad1Window objaussenverzahnt = new Zahnrad1Window();
            objaussenverzahnt.Show();
        }

        private void Close_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Innenverzahnung_Click(object sender, RoutedEventArgs e)
        {
            Zahnrad2Window objinnenverzahnt = new Zahnrad2Window();
            objinnenverzahnt.Show();
        }
    }
}
