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
       public double material;
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
                        MassenberechnungZähnezahlEingabe(z, m);
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
                        MassenberechnungDurchmesserEingabe(d);


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

        public void MassenberechnungZähnezahlEingabe(double z, double m)
        {
            string zahlencheck1, zahlencheck2;
            zahlencheck1 = txbx_Dicke.Text;
            zahlencheck2 = txbx_Außendurchmesser.Text;

            if (isteingabedouble(zahlencheck1) == true && isteingabedouble(zahlencheck2) == true)
            {
                double Dicke = Convert.ToDouble(txbx_Dicke.Text);
                double Außenmaß = Convert.ToDouble(txbx_Außendurchmesser.Text);

                double d = z * m;

                if (Außenmaß >= d + 15)
                {
                    txbx_Dicke.Background = Brushes.White;
                    txbx_Außendurchmesser.Background = Brushes.White;

                    double Masse = (Math.PI / 4) * ((Außenmaß * Außenmaß) - (d * d)) * Dicke * material;

                    Masse_Ausgabe.Text = Convert.ToString(Math.Round(Masse, decimalzahl) + "Gramm");
                }
                else
                {
                    MessageBox.Show("Außendurchmesser übderdenken");
                }

            }
            else if (isteingabedouble(zahlencheck1) == false && isteingabedouble(zahlencheck2) == true)
            {
                txbx_Dicke.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe der Dicke ist nicht in Ordnung");
            }
            else if (isteingabedouble(zahlencheck1) == true && true && isteingabedouble(zahlencheck2) == false)
            {
                txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe des Außendurchmessers ist nicht in Ordnung");
            }
            else
            {
                txbx_Dicke.Background = Brushes.OrangeRed;
                txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe des Außendurchmessers und der Dicke ist nicht in Ordnung");
            }
        }

        public void MassenberechnungDurchmesserEingabe(double d)
        {
            string zahlencheck1, zahlencheck2;
            zahlencheck1 = txbx_Dicke.Text;
            zahlencheck2 = txbx_Außendurchmesser.Text;

            if (isteingabedouble(zahlencheck1) == true && isteingabedouble(zahlencheck2) == true)
            {
                double Dicke = Convert.ToDouble(txbx_Dicke.Text);
                double Außenmaß = Convert.ToDouble(txbx_Außendurchmesser.Text);

                if (Außenmaß >= d + 10)
                {
                    txbx_Dicke.Background = Brushes.White;
                    txbx_Außendurchmesser.Background = Brushes.White;

                    double Masse = (Math.PI / 4) * ((Außenmaß * Außenmaß) - (d * d)) * Dicke * material;

                    Masse_Ausgabe.Text = Convert.ToString(Math.Round(Masse, decimalzahl) + "Gramm");
                }
                else
                {
                    MessageBox.Show("Außendurchmesser übderdenken");
                }

            }
            else if (isteingabedouble(zahlencheck1) == false && isteingabedouble(zahlencheck2) == true)
            {
                txbx_Dicke.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe der Dicke ist nicht in Ordnung");
            }
            else if (isteingabedouble(zahlencheck1) == true && true && isteingabedouble(zahlencheck2) == false)
            {
                txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe des Außendurchmessers ist nicht in Ordnung");
            }
            else
            {
                txbx_Dicke.Background = Brushes.OrangeRed;
                txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                MessageBox.Show("Die Eingabe des Außendurchmessers und der Dicke ist nicht in Ordnung");
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

        

        private void cmbx_nachkommar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                decimalzahl = Convert.ToInt32(cmbx_nachkommar.SelectedIndex);
            
        }

        private void cmbx_material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbx_material.SelectedIndex == 0)
            {
                material = 0.00786;
            }
            else if (cmbx_material.SelectedIndex == 1)
            {
                material = 0.00067;
            }
            else if (cmbx_material.SelectedIndex == 2)
            {
                material = 0.0027;
            }
            else if (cmbx_material.SelectedIndex == 3)
            {
                material = 0.00896;
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txtbx_eingabe1.Clear();
            txbx_Dicke.Clear();
            txbx_Außendurchmesser.Clear();
            d_Ausgabe.Text = "";
            p_Ausgabe.Text = "";
            da_Ausgabe.Text = "";
            df_Ausgabe.Text = "";
            h_Ausgabe.Text = "";
            ha_Ausgabe.Text = "";
            hf_Ausgabe.Text = "";
            c_Ausgabe.Text = "";
            Masse_Ausgabe.Text = "";
        }
    }
}
