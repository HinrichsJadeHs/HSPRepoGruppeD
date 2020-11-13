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
        public Window2()
        {
            InitializeComponent();

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
         

            if (einfachCheck.IsChecked == true)
                
            {
                if (zähnezahl.Text != "")
                    {
                    string zahlcheck = zähnezahl.Text;

                        if (isteingabeinteger(zahlcheck) == true)
                            {

                                double z = Convert.ToDouble(zähnezahl.Text);
                                double m = Convert.ToDouble(DropModul.Text);



                                if (z % 1 == 0 && z >= 5)
                                {
                                    zähnezahl.Background = Brushes.White;

                                    // Berechnung einfach
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
                                        zähnezahl.Background = Brushes.Red;
                                        MessageBox.Show("Es gibt nur gerade Zähnezahlen :D ");
                                    }
                                    if (z <= 4)
                                    {
                                        zähnezahl.Background = Brushes.Red;
                                        MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                                    }
                                    else { MessageBox.Show("Technischer Fehler, bitte wenden Sie sich an ihen Administrator"); }
                                }
                            }
                        else if (isteingabeinteger(zahlcheck) == false)
                            {
                                MessageBox.Show("Sie müssen als Zähnezahl eine Zahl eingeben");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Zähnezahl eingeben!");
                    }
                
            }
            else if (schraegCheck.IsChecked == true)
            {
                if (zähnezahl.Text != "" && Winkeleingabe.Text != "")
                {
                    string zahlencheck = zähnezahl.Text;
                    string zahlencheck2 = Winkeleingabe.Text;

                    if (isteingabeinteger(zahlencheck) == true && isteingabeinteger(zahlencheck2) == true)
                    {

                        double z = Convert.ToDouble(zähnezahl.Text);
                        double m = Convert.ToDouble(DropModul.Text);
                        double Winkel = Convert.ToDouble(Winkeleingabe.Text);
                        Winkel = Winkel * Math.PI / 180;



                        if (z % 1 == 0 && z >= 5)
                        {
                            zähnezahl.Background = Brushes.White;

                            double cosbeta = Math.Cos(Winkel);
                            double d = (m * z) / cosbeta;
                            d_Ausgabe.Text = Convert.ToString(Math.Round(d, 2) + " mm");

                            double p = Math.PI * m;
                            p_Ausgabe.Text = Convert.ToString(Math.Round(p, 2));

                            double da = d + 2 * m;
                            da_Ausgabe.Text = Convert.ToString(Math.Round(da, 2) + " mm");

                            c_Ausgabe.Text = Convert.ToString("");
                            df_Ausgabe.Text = Convert.ToString("");
                            h_Ausgabe.Text = Convert.ToString("");
                            ha_Ausgabe.Text = Convert.ToString("");
                            hf_Ausgabe.Text = Convert.ToString("");
                            a_Ausgabe.Text = Convert.ToString("");

                            double mt = p / Math.PI;
                            mt_Ausgabe.Text = Convert.ToString(Math.Round(mt, 2));

                            double pt = p / cosbeta;
                            pt_Ausgabe.Text = Convert.ToString(Math.Round(pt, 2));

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
                                zähnezahl.Background = Brushes.Red;
                                MessageBox.Show("Es gibt nur gerade Zähnezahlen :D ");
                            }
                            if (z <= 4)
                            {
                                zähnezahl.Background = Brushes.Red;
                                MessageBox.Show("Bitte mindestens eine Zähnzahl von 5 eingeben");
                            }
                            else { MessageBox.Show("Technischer Fehler, bitte wenden Sie sich an ihen Administrator"); }
                        }
                    }
                    else if (isteingabeinteger(zahlencheck) == false)
                    {
                        MessageBox.Show("Zähnezahl eingeben!");
                    }
                    else if (isteingabeinteger(zahlencheck2) == false)
                    {
                        MessageBox.Show("Der winkel muss eine Zahl sein!");
                    }
                    else
                    {
                        MessageBox.Show("überprüfen sei ihre eingaben!");
                    }
                }
                else
                {
                    MessageBox.Show("Zähnezahl eingeben!");
                }


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

        private bool isteingabeinteger(string zahlcheck)
        {
            try
            {
                int intzahl = int.Parse(zahlcheck);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
