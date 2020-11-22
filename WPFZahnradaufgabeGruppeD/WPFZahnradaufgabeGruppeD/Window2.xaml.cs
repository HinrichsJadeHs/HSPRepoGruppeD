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
    public partial class Window2 : Window
    {
        public int decimalzahl;
        
        public Window2()
        {
            InitializeComponent();
            
          
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {
                EingabeAuswahlDrop.Background = Brushes.White;

                if (einfachCheck.IsChecked == true)

                {
                    if (txtbx_eingabe1.Text != "")
                    {
                        string zahlcheck = txtbx_eingabe1.Text;

                        if (isteingabedouble(zahlcheck) == true)
                        {

                            double z = Convert.ToDouble(txtbx_eingabe1.Text);
                            double m = Convert.ToDouble(Drp_eingabe2.Text);

                            txtbx_eingabe1.Background = Brushes.White;

                            RechnungEinfachverzahntSelect0(z, m);
                            
                        }
                        else if (isteingabedouble(zahlcheck) == false)
                        {
                            txtbx_eingabe1.Background = Brushes.OrangeRed;
                            MessageBox.Show("Sie müssen als Zähnezahl eine Zahl eingeben");
                        }
                    }
                    else
                    {
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Zähnezahl eingeben!");
                    }

                }
                else if (schraegCheck.IsChecked == true)
                {
                    if (txtbx_eingabe1.Text != "" && Winkeleingabe.Text != "")
                    {
                        string zahlencheck = txtbx_eingabe1.Text;
                        string zahlencheck2 = Winkeleingabe.Text;

                        if (isteingabedouble(zahlencheck) == true && isteingabedouble(zahlencheck2) == true)
                        {

                            double z = Convert.ToDouble(txtbx_eingabe1.Text);
                            double m = Convert.ToDouble(Drp_eingabe2.Text);
                            double Winkel = Convert.ToDouble(Winkeleingabe.Text);
                            Winkel = Winkel * Math.PI / 180;
                            txtbx_eingabe1.Background = Brushes.White;
                            Winkeleingabe.Background = Brushes.White;

                            RechnungSchrägverzahntSelect0( z , m , Winkel );

                            
                        }
                        else if (isteingabedouble(zahlencheck) == false)
                        {
                            txtbx_eingabe1.Background = Brushes.OrangeRed;
                            MessageBox.Show("Zähnezahl eingeben!");
                        }
                        else if (isteingabedouble(zahlencheck2) == false)
                        {
                            Winkeleingabe.Background = Brushes.OrangeRed;
                            MessageBox.Show("Der winkel muss eine Zahl sein!");
                        }
                        else
                        {
                            MessageBox.Show("überprüfen sei ihre Eingaben!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zähnezahl eingeben und oder Winkel eingeben!");
                    }


                }
                else
                {
                    MessageBox.Show("Verzahnung anhaken");
                }
            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {
                EingabeAuswahlDrop.Background = Brushes.White;
                if (einfachCheck.IsChecked == true)

                {
                    if (txtbx_eingabe1.Text != "")
                    {
                        string zahlcheck = txtbx_eingabe1.Text;

                        if (isteingabedouble(zahlcheck) == true)
                        {

                            double d = Convert.ToDouble(txtbx_eingabe1.Text);
                            double m = Convert.ToDouble(Drp_eingabe2.Text);

                            txtbx_eingabe1.Background = Brushes.White;

                            RechnungEinfachverzahntSelect1(d, m);
                           
                        }
                        else if (isteingabedouble(zahlcheck) == false)
                        {
                            txtbx_eingabe1.Background = Brushes.OrangeRed;
                            MessageBox.Show("Sie müssen als Teilkreisdurchmesser eine Zahl eingeben");
                        }
                    }
                    else
                    {
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Teilkreisdurchmesser eingeben!");
                    }

                }
                else if (schraegCheck.IsChecked == true)
                {
                    if (txtbx_eingabe1.Text != "" && Winkeleingabe.Text != "")
                    {
                        string zahlencheck = txtbx_eingabe1.Text;
                        string zahlencheck2 = Winkeleingabe.Text;

                        if (isteingabedouble(zahlencheck) == true && isteingabedouble(zahlencheck2) == true)
                        {

                            double d = Convert.ToDouble(txtbx_eingabe1.Text);
                            double m = Convert.ToDouble(Drp_eingabe2.Text);
                            double Winkel = Convert.ToDouble(Winkeleingabe.Text);
                            Winkel = Winkel * Math.PI / 180;

                            txtbx_eingabe1.Background = Brushes.White;
                            Winkeleingabe.Background = Brushes.White;

                            RechnungSchrägverzahntSelect1(d, m, Winkel);
                           
                        }
                        else if (isteingabedouble(zahlencheck) == false)
                        {
                            txtbx_eingabe1.Background = Brushes.OrangeRed;
                            MessageBox.Show("Der Teilkreisdurchmesser muss eine Zahl sein!");
                        }
                        else if (isteingabedouble(zahlencheck2) == false)
                        {
                            Winkeleingabe.Background = Brushes.OrangeRed;
                            MessageBox.Show("Der winkel muss eine Zahl sein!");
                        }
                        else
                        {
                            MessageBox.Show("überprüfen sei ihre eingaben!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Teilkreisdurchmesser eingeben und oder Winkel eingeben!");
                    }


                }
                else
                {
                    MessageBox.Show("Verzahnung anhaken!");
                }
            }
            else if (EingabeAuswahlDrop.SelectedIndex != 1 && EingabeAuswahlDrop.SelectedIndex != 0)
            {
                EingabeAuswahlDrop.Background = Brushes.OrangeRed;
                MessageBox.Show("Wählen Sie eine Eingabemöglichkeit aus!");
            }
        }


        private void einfachCheck_Checked(object sender, RoutedEventArgs e)
        {
            schraegCheck.IsChecked = false;

        }

        private void schraegCheck_Checked(object sender, RoutedEventArgs e)
        {
            einfachCheck.IsChecked = false;

        }

        private void einfachCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            schraegCheck.IsChecked = true;
        }

        private void schraegCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            einfachCheck.IsChecked = true;
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


        private void EingabeAuswahlDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EingabeAuswahlDrop.SelectedIndex == 0)
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

                double da = d + 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d - 2 * (m + c);
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
                if (z % 1 != 0)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Es gibt nur ganzzahlige Zähnezahlen!");
                }
                if (z <= 4)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                }

            }
        }

        private void RechnungSchrägverzahntSelect0(double z, double m, double Winkel)
        {
            if (z % 1 == 0 && z >= 5)
            {
                txtbx_eingabe1.Background = Brushes.White;

                double cosbeta = Math.Cos(Winkel);
                double d = (m * z) / cosbeta;
                d_Ausgabe.Text = Convert.ToString(Math.Round(d, decimalzahl) + " mm");

                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, decimalzahl));

                double da = d + 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167 * m;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d - 2 * (m + c);
                df_Ausgabe.Text = Convert.ToString(Math.Round(df, decimalzahl) + " mm");

                double h = 2 * m + c;
                h_Ausgabe.Text = Convert.ToString(Math.Round(h, decimalzahl) + " mm");

                double ha = m;
                ha_Ausgabe.Text = Convert.ToString(Math.Round(ha, decimalzahl) + " mm");

                double hf = m + c;
                hf_Ausgabe.Text = Convert.ToString(Math.Round(hf, decimalzahl) + " mm");


                

                double mt = m / Math.Cos(Winkel);
                mt_Ausgabe.Text = Convert.ToString(Math.Round(mt, decimalzahl));

                double pt = p / cosbeta;
                pt_Ausgabe.Text = Convert.ToString(Math.Round(pt, decimalzahl));

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
                    MessageBox.Show("Es gibt nur gerade Zähnezahlen :D ");
                }
                if (z <= 4)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                }
                else { MessageBox.Show("Technischer Fehler, bitte wenden Sie sich an ihen Administrator"); }
            }
        }

        private void RechnungEinfachverzahntSelect1(double d, double m)
        {
            if (d >= 5)
            {
                txtbx_eingabe1.Background = Brushes.White;

                // Berechnung einfach
                double z = d / m;

                

                d_Ausgabe.Text = Convert.ToString(Math.Round(z, 0));

                z = Convert.ToDouble(d_Ausgabe.Text);
                d = z * m;

                txtbx_eingabe1.Text = Convert.ToString(d);

                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, decimalzahl));

                double da = d + 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d - 2 * (m + c);
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

                if (d <= 4)
                {
                    txtbx_eingabe1.Background = Brushes.Red;
                    MessageBox.Show("Bitte mindestens einen Teilkreisdurchmesser von 5 mm eingeben");
                }
                //else { MessageBox.Show("Technischer Fehler, bitte wenden Sie sich an ihen Administrator"); }
            }
        }

        private void RechnungSchrägverzahntSelect1(double d, double m, double Winkel)
        {
            if (d >= 5)
            {
                txtbx_eingabe1.Background = Brushes.White;

                double cosbeta = Math.Cos(Winkel);
                double z = (cosbeta * d) / m;
                lbl_Ausgabe.Content = "Zähnezahl :";


                d_Ausgabe.Text = Convert.ToString(Math.Round(z, 0));



                


                double p = Math.PI * m;
                p_Ausgabe.Text = Convert.ToString(Math.Round(p, decimalzahl));

                double da = d + 2 * m;
                da_Ausgabe.Text = Convert.ToString(Math.Round(da, decimalzahl) + " mm");

                double c = 0.167 * m;
                c_Ausgabe.Text = Convert.ToString(Math.Round(c, decimalzahl) + " mm");

                double df = d - 2 * (m + c);
                df_Ausgabe.Text = Convert.ToString(Math.Round(df, decimalzahl) + " mm");

                double h = 2 * m + c;
                h_Ausgabe.Text = Convert.ToString(Math.Round(h, decimalzahl) + " mm");

                double ha = m;
                ha_Ausgabe.Text = Convert.ToString(Math.Round(ha, decimalzahl) + " mm");

                double hf = m + c;
                hf_Ausgabe.Text = Convert.ToString(Math.Round(hf, decimalzahl) + " mm");


                

                double mt = m / Math.Cos(Winkel);
                mt_Ausgabe.Text = Convert.ToString(Math.Round(mt, decimalzahl));

                double pt = p / cosbeta;
                pt_Ausgabe.Text = Convert.ToString(Math.Round(pt, decimalzahl));

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

        public void btn_info_Click(object sender, RoutedEventArgs e)
        {
            

            InfoWindow Infowndw = new InfoWindow();
            Infowndw.Show();
        }

        

        public void cmbx_nachkommar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            decimalzahl = Convert.ToInt32(cmbx_nachkommar.SelectedIndex);
        }
    }
}
