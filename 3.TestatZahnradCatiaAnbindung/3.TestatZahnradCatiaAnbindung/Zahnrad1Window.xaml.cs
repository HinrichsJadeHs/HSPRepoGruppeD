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


namespace _3.TestatZahnradCatiaAnbindung
{
    /// <summary>
    /// Interaktionslogik für Zahnrad1Window.xaml
    /// </summary>
    public partial class Zahnrad1Window : Window
    {
        Zahnrad ZR1 = new Zahnrad();
        public Zahnrad1Window()
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
            

            if(Eingabekontrolle() == true)
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

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();


                    // Generiere ein Profil                    
                    cc.ErzeugedasneueProfil(ZR1);

                    cc.ErzeugeDasNeueKreismuster(ZR1);

                    cc.ErstelleLeereSkizzefürBohrung();
                    cc.ErzeugeBohrung(ZR1.bohrung);
                    
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
        { int Kontrollvariable = 0;
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
                    if (Parametercheck <8)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Geben Sie mindestens 8 Zähne an");
                    }
                    if (Parametercheck% 1 != 0)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Es gibt nur ganzzahlige Zähnezahlen ");
                    }

                }
                if (txtbx_eingabe1.Text == "")
                {
                    Kontrollvariable++;
                    txtbx_eingabe1.Background = Brushes.OrangeRed;
                    MessageBox.Show("Sie müssen eine Zähnezahl eingeben");
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
                    if (Parametercheck < 5)
                    {
                        Kontrollvariable++;
                        txtbx_eingabe1.Background = Brushes.OrangeRed;
                        MessageBox.Show("Geben Sie mindestens einen Durchmesser von 5mm an");
                    }
                    

                }
                if (txtbx_eingabe1.Text == "")
                {
                    Kontrollvariable++;
                    txtbx_eingabe1.Background = Brushes.OrangeRed;
                    MessageBox.Show("Sie müssen eine Zähnezahl eingeben");
                }
            }
            else if (EingabeAuswahlDrop.SelectedIndex != 1 && EingabeAuswahlDrop.SelectedIndex != 0)
            {
                Kontrollvariable++;
                lbl_eingabe.Foreground = Brushes.OrangeRed;
                MessageBox.Show("Wählen Sie eine Eingabemöglichkeit aus!");
            }

            




                
            


            zahlcheck = txbx_Dicke.Text;
            if (isteingabedouble(zahlcheck) == true)
            {
                txbx_Dicke.Background = Brushes.White;
            }
            else if (isteingabedouble(zahlcheck) == false)
            {
                Kontrollvariable++;
                MessageBox.Show("Bitte geben Sie eine Zahl als Winkel ein");
                txbx_Dicke.Background = Brushes.OrangeRed;
            }

            zahlcheck = txbx_Bohrungsdurchmesser.Text;
            if (isteingabedouble(zahlcheck) == true)
            {
                txbx_Bohrungsdurchmesser.Background = Brushes.White;
            }
            else if (isteingabedouble(zahlcheck) == false)
            {
                Kontrollvariable++;
                MessageBox.Show("Bitte geben Sie eine Zahl für die Dicke ein");
                txbx_Bohrungsdurchmesser.Background = Brushes.OrangeRed;
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
            Zahnradfüttern();
            ZR1.Berechnung();
            Canvasausgabe();
            
        }
        

        public void Zahnradfüttern()
        {

            if (Eingabekontrolle() == true)
            {
                if (EingabeAuswahlDrop.SelectedIndex == 0)
                {                   
                    ZR1.Eingabeparameter = Convert.ToString(1);                  
                    ZR1.Zähnezahl = txtbx_eingabe1.Text;
                    ZR1.Modul = Convert.ToString(Drp_Modul.Text);
                    ZR1.Dicke = Convert.ToString(txbx_Dicke.Text);
                    ZR1.Bohrung = Convert.ToString(txbx_Bohrungsdurchmesser.Text);
                    
                    ZR1.Nachkommarstellen = Convert.ToString(drp_nachkommar.Text);
                }
                else if (EingabeAuswahlDrop.SelectedIndex == 1)
                {
                    ZR1.Eingabeparameter = Convert.ToString(2);
                    ZR1.Teilkreisdurchmesser = txtbx_eingabe1.Text;
                    ZR1.Modul = Convert.ToString(Drp_Modul.Text);
                    ZR1.Dicke = Convert.ToString(txbx_Dicke.Text);
                    ZR1.Bohrung = Convert.ToString(txbx_Bohrungsdurchmesser.Text);
                    
                    ZR1.Nachkommarstellen = drp_nachkommar.Text;
                    
                }
            }
            


            
        }
        public void Canvasausgabe()
        {
            m_Ausgabe.Text = Convert.ToString(ZR1.modul);
            z_Ausgabe.Text = Convert.ToString(ZR1.zähnezahl);
            d_Ausgabe.Text = Convert.ToString(ZR1.teilkreisdurchmesser + "mm");
            p_Ausgabe.Text = Convert.ToString(ZR1.teilung + "mm");
            da_Ausgabe.Text = Convert.ToString(ZR1.kopfkreisdurchmesser + "mm");
            c_Ausgabe.Text = Convert.ToString(ZR1.kopfspiel + "mm");
            df_Ausgabe.Text = Convert.ToString(ZR1.fußkreisdurchmesser + "mm");
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
    }

    



}
