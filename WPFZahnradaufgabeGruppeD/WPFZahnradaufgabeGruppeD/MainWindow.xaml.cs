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
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            
            InitializeComponent();
                     
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
                  
            double z = Convert.ToDouble( zähnezahl.Text);         
            double m = Convert.ToDouble(DropModul.Text);



            if (z % 1 == 0 && z >= 5 )
            {
                zähnezahl.Background = Brushes.White;

                double d = m * z;
                d_Ausgabe.Text = Convert.ToString(Math.Round(d, 2) + " mm");

                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, 2));

                double da = d + 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, 2) + " mm");

                double c = 0.167;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, 2) + " mm");

                double df = d - 2 * (m + c);
                df_Ausgabe.Text = Convert.ToString(Math.Round(df, 2) + " mm");

                double h = 2 * m + c;
                h_Ausgabe.Text = Convert.ToString(Math.Round(h, 2) + " mm");

                double ha = m;
                ha_Ausgabe.Text = Convert.ToString(Math.Round(ha, 2) + " mm");

                double hf = m + c;
                hf_Ausgabe.Text = Convert.ToString(Math.Round(hf, 2) + " mm");

                double a = 10 * 10;
                a_Ausgabe.Text = Convert.ToString(Math.Round(a, 2) + " mm");
            }
            else
            {
                if (z % 1 != 0)
                {
                    zähnezahl.Background = Brushes.Red;
                    MessageBox.Show("Es gibt nur gerade Zähnezahlen :D ");
                }
                if(z <= 4)
                {
                    zähnezahl.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                }
                else { MessageBox.Show("Technischer Fehler, bitte wenden Sie sich an ihen Administrator"); }
            }
        }


    }
}
