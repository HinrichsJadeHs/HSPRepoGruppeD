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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;



namespace _3.TestatZahnradCatiaAnbindung
{

    public partial class Zahnrad2Window : Window
    {
        Zahnrad ZR1 = new Zahnrad();
        public Zahnrad2Window()
        {
            InitializeComponent();
        }

        private void EingabeAuswahlDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_eingabe.Foreground = Brushes.Black;
            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {
                lbl_mm.Content = "";

                lbl_eingabe1.Content = "Zähnezahl :";



                //lbl_Ausgabe.Content = "Teilkreisdurchmesser d:";
            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {
                lbl_mm.Content = "mm";

                lbl_eingabe1.Content = "Teilkreisd. :";

                //lbl_Ausgabe.Content = "Zähnezahl z:";

            }
        }

        public void Button_Catia(object sender, RoutedEventArgs e)
        {


            if (Eingabekontrolle() == true)
            {
                CatiaControl();
            }

        }

        public void CatiaControl()
        {
            try
            {
                CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    // Öffne ein neues Part
                    cc.ErzeugePart();

                    //Erstelle das Zahnrad
                    
                    cc.GanzeInnenZahnrad(ZR1);

                    //cc.Screenshot("ZahnradFoto");
                }
                else
                {
                    MessageBox.Show("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }
        }

        private bool Eingabekontrolle()
        {
            int Kontrollvariable = 0;
            string zahlcheck = txtbx_eingabe1.Text;

            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {

                if (isteingabedouble(zahlcheck) == false)
                {
                    Kontrollvariable++;
                    txtbx_eingabe1.Background = Brushes.OrangeRed;
                    MessageBox.Show("Sie müssen als Zähnezahl eine Zahl eingeben");
                }
                else if (isteingabedouble(zahlcheck) == true)
                {
                    txtbx_eingabe1.Background = Brushes.White;
                    double Parametercheck = Convert.ToDouble(txtbx_eingabe1.Text);
                    if (Parametercheck < 14)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Geben Sie mindestens 14 Zähne an");
                    }
                    if (Parametercheck % 1 != 0)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Es gibt nur ganzzahlige Zähnezahlen ");
                    }

                }
                if (ZR1.ZusatzparameterInnen != 0)
                {

                    zahlcheck = txbx_Außendurchmesser.Text;
                    if (isteingabedouble(zahlcheck) == true)
                    {
                        txbx_Außendurchmesser.Background = Brushes.White;
                    }
                    else if (isteingabedouble(zahlcheck) == false)
                    {
                        Kontrollvariable++;
                        MessageBox.Show("Bitte geben Sie eine Zahl für den Außendurchmesser an");
                        txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                    }
                    

                }


            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {


                if (isteingabedouble(zahlcheck) == false)
                {
                    Kontrollvariable++;
                    txtbx_eingabe1.Background = Brushes.OrangeRed;
                    MessageBox.Show("Sie müssen als Teilkreisdurchmesser eine Zahl eingeben");
                }
                else if (isteingabedouble(zahlcheck) == true)
                {
                    txtbx_eingabe1.Background = Brushes.White;
                    double Parametercheck = Convert.ToDouble(txtbx_eingabe1.Text);
                    if (Parametercheck < 15)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Geben Sie mindestens einen Durchmesser von 15mm an");
                    }


                }


                if (ZR1.ZusatzparameterInnen != 0)
                {

                    zahlcheck = txbx_Außendurchmesser.Text;
                    if (isteingabedouble(zahlcheck) == true)
                    {
                        txbx_Außendurchmesser.Background = Brushes.White;
                    }
                    else if (isteingabedouble(zahlcheck) == false)
                    {
                        Kontrollvariable++;
                        MessageBox.Show("Bitte geben Sie eine Zahl für den Außendurchmesser an");
                        txbx_Außendurchmesser.Background = Brushes.OrangeRed;
                    }
                    

                }



            }
            else if (EingabeAuswahlDrop.SelectedIndex != 1 && EingabeAuswahlDrop.SelectedIndex != 0)
            {
                Kontrollvariable++;
                lbl_eingabe.Foreground = Brushes.OrangeRed;
                MessageBox.Show("Wählen Sie eine Eingabemöglichkeit aus!");
            }


            if (RadioBtn_AutomatischerAußenring.IsChecked == false && RadioBtn_ManuellerAußenring.IsChecked == false)
            {
                RadioBtn_AutomatischerAußenring.IsChecked = true;
                MessageBox.Show("da keine Auswahl für den Außendurchmesser gewählt wurde, wird dieser automatisch erzeugt");
            }







            zahlcheck = txbx_Dicke.Text;
            if (isteingabedouble(zahlcheck) == true)
            {
                txbx_Dicke.Background = Brushes.White;
            }
            else if (isteingabedouble(zahlcheck) == false)
            {
                Kontrollvariable++;
                MessageBox.Show("Bitte geben Sie eine Zahl für die Dicke an");
                txbx_Dicke.Background = Brushes.OrangeRed;
            }

            


            if (Kontrollvariable > 0)
            {
                return false;
            }
            else
            {
                lbl_eingabe.Foreground = Brushes.Black;
                return true;
            }
        }
        private bool isteingabedouble(string zahlcheck)
        {

            try
            {
                double doublezahl = double.Parse(zahlcheck);
                return true;

            }
            catch (FormatException)
            {
                return false;
            }

        }

        private void Ergebnis_Click(object sender, RoutedEventArgs e)
        {
            ZR1.parameterAußen = false;
            ZR1.parameterInnen = true;

            if (Eingabekontrolle() == true)
            {
                

                Zahnradfüttern();
                ZR1.Berechnung();
                if (ZR1.ZusatzparameterInnen == 1)
                {
                    if (KontrolleAußendurchmesser() == true)
                    {
                        Canvasausgabe();
                    }
                }
                else
                {
                    Canvasausgabe();
                }
            }

        }

        public bool KontrolleAußendurchmesser()
        {

            
         double Außendurchmesser = Convert.ToDouble(txbx_Außendurchmesser.Text);

        if (Außendurchmesser < (ZR1.kopfkreisdurchmesser + 20) && ZR1.ZusatzparameterInnen > 0)
             {
                double WieVielZuKlein = ZR1.kopfkreisdurchmesser +20 - Außendurchmesser;
                 MessageBox.Show("Außendurchmesser ist um mind. "+Convert.ToString(WieVielZuKlein)+" Millimeter zu klein!");
                 return false;
             }           
            else  
            {
                return true;
            }
            
            
        }

        public void Zahnradfüttern()
        {


            if (EingabeAuswahlDrop.SelectedIndex == 0)
            {
                ZR1.Eingabeparameter = Convert.ToString(1);
                ZR1.Zähnezahl = txtbx_eingabe1.Text;
                ZR1.Modul = Convert.ToString(Drp_Modul.Text);
                ZR1.Dicke = Convert.ToString(txbx_Dicke.Text);
                if (ZR1.ZusatzparameterInnen != 0)
                {
                    ZR1.Außendurchmesser = Convert.ToString(txbx_Außendurchmesser.Text);
                }
                ZR1.Nachkommarstellen = Convert.ToString(drp_nachkommar.Text);
            }
            else if (EingabeAuswahlDrop.SelectedIndex == 1)
            {
                ZR1.Eingabeparameter = Convert.ToString(2);
                ZR1.Teilkreisdurchmesser = txtbx_eingabe1.Text;
                ZR1.Modul = Convert.ToString(Drp_Modul.Text);
                ZR1.Dicke = Convert.ToString(txbx_Dicke.Text);

                if (ZR1.ZusatzparameterInnen != 0)
                {
                    ZR1.Außendurchmesser = Convert.ToString(txbx_Außendurchmesser.Text);
                }
                ZR1.Nachkommarstellen = Convert.ToString(drp_nachkommar.Text);
            }


        }
        public void Canvasausgabe()
        {
            m_Ausgabe.Text = Convert.ToString(ZR1.modul);
            z_Ausgabe.Text = Convert.ToString(ZR1.zähnezahl);
            d_Ausgabe.Text = Convert.ToString(ZR1.teilkreisdurchmesser + "mm");
            if (ZR1.EingabeDesTeilkreisdurchmessersCheck == 1)
            {
                txtbx_eingabe1.Text = Convert.ToString(ZR1.teilkreisdurchmesser);
                MessageBox.Show("Achtung! Eingabe des Teilkreisdurchmessers musste korrigiert werden!");
            }
            p_Ausgabe.Text = Convert.ToString(ZR1.teilung + "mm");            
            c_Ausgabe.Text = Convert.ToString(ZR1.kopfspiel + "mm");
            da_Ausgabe.Text = Convert.ToString(ZR1.fußkreisdurchmesser + "mm");
            df_Ausgabe.Text = Convert.ToString(ZR1.kopfkreisdurchmesser + "mm");
            h_Ausgabe.Text = Convert.ToString(ZR1.zahnhöhe + "mm");
            ha_Ausgabe.Text = Convert.ToString(ZR1.zahnkopfhöhe + "mm");
            hf_Ausgabe.Text = Convert.ToString(ZR1.zahnfußhöhe + "mm");
            Masse_Ausgabe.Text = Convert.ToString(ZR1.masse + "g");
        }

        private void cmbx_material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbx_material.SelectedIndex == 0)
            {
                ZR1.material = 0.00786;
            }
            else if (cmbx_material.SelectedIndex == 1)
            {
                ZR1.material = 0.00067;
            }
            else if (cmbx_material.SelectedIndex == 2)
            {
                ZR1.material = 0.0027;
            }
            else if (cmbx_material.SelectedIndex == 3)
            {
                ZR1.material = 0.00896;
            }
        }

        

        

        private void btn_catiaÖffnen(object sender, RoutedEventArgs e)
        {

            bool Catia_running = CheckIfRunning("CNEXT");
            if (Catia_running == true)
            {
                MessageBox.Show("Catia läuft bereits!");

            }
            else if (Catia_running == false)
            {
                Process Catia = new Process();
                Catia.StartInfo.FileName = "CNEXT.exe";
                Catia.Start();
            }


        }

        private bool CheckIfRunning(string Processname)
        {

            return Process.GetProcessesByName(Processname).Length > 0;
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            m_Ausgabe.Text = "";
            z_Ausgabe.Text = "";
            d_Ausgabe.Text = "";
            p_Ausgabe.Text = "";
            da_Ausgabe.Text = "";
            c_Ausgabe.Text = "";
            df_Ausgabe.Text = "";
            h_Ausgabe.Text = "";
            ha_Ausgabe.Text = "";
            hf_Ausgabe.Text = "";
            Masse_Ausgabe.Text = "";
            txtbx_eingabe1.Text = "";
            txbx_Außendurchmesser.Text = "";
            txbx_Dicke.Text = "";
        }

        private void automatischdurchmesser_checked(object sender, RoutedEventArgs e)
        {
            txbx_Außendurchmesser.Visibility = Visibility.Hidden;
            ZR1.ZusatzparameterInnen = 0;
        }

        private void manuelldurchmesser_checked(object sender, RoutedEventArgs e)
        {
            txbx_Außendurchmesser.Visibility = Visibility.Visible;
            ZR1.ZusatzparameterInnen = 1;
        }
    }





}
