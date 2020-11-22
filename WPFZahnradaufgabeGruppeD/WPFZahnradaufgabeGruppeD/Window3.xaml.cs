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
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class Window3 : Window
    {
       
       public int decimalzahl = 0;

        public Window3()
        {
            InitializeComponent();

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {

                if (txtbx_eingabe1.Text != "")
                {
                    string zahlcheck = txtbx_eingabe1.Text;

                    if (isteingabedouble(zahlcheck) == true)
                    {

                        double z = Convert.ToDouble(txtbx_eingabe1.Text);
                        double m = Convert.ToDouble(Drp_eingabe2.Text);

                        RechnungEinfachverzahntSelect0(z, m);
                    }
                    else if (isteingabedouble(zahlcheck) == false)
                    {
                        MessageBox.Show("Sie müssen als Zähnezahl eine Zahl eingeben");
                    }
                }
                else
                {
                    MessageBox.Show("Zähnezahl eingeben!");
                }

                
                
                
            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {

                    if (txtbx_eingabe1.Text != "")
                    {
                        string zahlcheck = txtbx_eingabe1.Text;

                        if (isteingabedouble(zahlcheck) == true)
                        {

                            double d = Convert.ToDouble(txtbx_eingabe1.Text);
                            double m = Convert.ToDouble(Drp_eingabe2.Text);

                        RechnungEinfachverzahntSelect1(d, m);

                            
                        }
                        else if (isteingabedouble(zahlcheck) == false)
                        {
                            MessageBox.Show("Sie müssen als Teilkreisdurchmesser eine Zahl eingeben");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Teilkreisdurchmesser eingeben!");
                    }

            
            }
            else if (EingabeAuswahlDrop.SelectedIndex != 1 && EingabeAuswahlDrop.SelectedIndex != 0)
            {
                MessageBox.Show("Wählen Sie eine Eingabemöglichkeit aus!");
            }
        }

        

        
        

       

        private void Close_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private bool isteingabedouble(string zahlcheck)
        {
            try
            {
                double intzahl = double.Parse(zahlcheck);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void RechnungEinfachverzahntSelect0(double z, double m)
        {
            if (z % 1 == 0 && z >= 5)
            {
                txtbx_eingabe1.Background = Brushes.White;

                // Berechnung einfach
                double d = m * z;
                d_Ausgabe.Text = Convert.ToString(Math.Round(d, decimalzahl) + " mm");

                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, decimalzahl));

                double da = d - 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d + 2 * (m + c);
                df_Ausgabe.Text = Convert.ToString(Math.Round(df, decimalzahl) + " mm");

                double h = 2 * m + c;
                h_Ausgabe.Text = Convert.ToString(Math.Round(h, decimalzahl) + " mm");

                double ha = m;
                ha_Ausgabe.Text = Convert.ToString(Math.Round(ha, decimalzahl) + " mm");

                double hf = m + c;
                hf_Ausgabe.Text = Convert.ToString(Math.Round(hf, decimalzahl) + " mm");

                


                mt_Ausgabe.Text = Convert.ToString("");

                pt_Ausgabe.Text = Convert.ToString("");

                //Berechnung schräg

                if (Dicke.Text != "")
                {
                    dicke_Ausgabe.Text = Dicke.Text + " mm";
                }
                else
                {
                    dicke_Ausgabe.Text = "";
                }
            }
            else
            {
                if (z % 1 != 0)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Es gibt nur ganzzahlige Zähnezahlen ");
                }
                if (z <= 4)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                }

            }
        }

        private void RechnungEinfachverzahntSelect1(double d, double m)
        {
            if (d >= 5)
            {
                txtbx_eingabe1.Background = Brushes.White;

                
                double z = d / m;

                d_Ausgabe.Text = Convert.ToString(Math.Round(z, 0));

                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, decimalzahl));

                double da = d - 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d + 2 * (m + c);
                df_Ausgabe.Text = Convert.ToString(Math.Round(df, decimalzahl) + " mm");

                double h = 2 * m + c;
                h_Ausgabe.Text = Convert.ToString(Math.Round(h, decimalzahl) + " mm");

                double ha = m;
                ha_Ausgabe.Text = Convert.ToString(Math.Round(ha, decimalzahl) + " mm");

                double hf = m + c;
                hf_Ausgabe.Text = Convert.ToString(Math.Round(hf, decimalzahl) + " mm");

                


                mt_Ausgabe.Text = Convert.ToString("");

                pt_Ausgabe.Text = Convert.ToString("");

               

                if (Dicke.Text != "")
                {
                    dicke_Ausgabe.Text = Dicke.Text + " mm";
                }
                else
                {
                    dicke_Ausgabe.Text = "";
                }
            }
            else
            {

                if (d <= 4)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens einen Teilkreisdurchmesser von 5 mm eingeben");
                }
                
            }
        }

        private void EingabeAuswahlDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {
                lbl_mm.Content = "";

                lbl_eingabe1.Content = "Zähnezahl :";

                lbl_Ausgabe.Content = "Teilkreisdurchmesser d:";
            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {
                lbl_mm.Content = "mm";

                lbl_eingabe1.Content = "Teilkreisd. :";

                lbl_Ausgabe.Content = "Zähnezahl z:";

            }


        }

        private void btn_info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow Infowndw = new InfoWindow();
            Infowndw.Show();
        }

        private void btn_option_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbx_nachkommar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                decimalzahl = Convert.ToInt32(cmbx_nachkommar.SelectedIndex);
            
        }
    }
}
