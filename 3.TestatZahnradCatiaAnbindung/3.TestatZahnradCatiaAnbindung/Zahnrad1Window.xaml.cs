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

        private void einfachCheck_Checked(object sender, RoutedEventArgs e)
        {
            schraegCheck.IsChecked = false;
            txbx_Winkeleingabe.Visibility = Visibility.Hidden;

        }

        private void schraegCheck_Checked(object sender, RoutedEventArgs e)
        {
            einfachCheck.IsChecked = false;
            txbx_Winkeleingabe.Visibility = Visibility.Visible;
        }

        private void einfachCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            schraegCheck.IsChecked = true;
            txbx_Winkeleingabe.Visibility = Visibility.Visible;
        }

        private void schraegCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            einfachCheck.IsChecked = true;
            txbx_Winkeleingabe.Visibility = Visibility.Hidden;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Zahnrad ZR1 = new Zahnrad();

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
                    cc.ErzeugeProfil(Convert.ToDouble(txtbx_eingabe1.Text), 10);


                    // Extrudiere Balken
                    cc.ErzeugeBalken(Convert.ToDouble(txbx_Dicke.Text));
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

            if (schraegCheck.IsChecked == false && einfachCheck.IsChecked == false)
            {
                Kontrollvariable++;
                MessageBox.Show("Verzahnung anhaken");
            }




                if (schraegCheck.IsChecked == true)
            {
                zahlcheck = txbx_Winkeleingabe.Text;
                if (isteingabedouble(zahlcheck) == true)
                {
                    txbx_Winkeleingabe.Background = Brushes.White;

                }
                else if (isteingabedouble(zahlcheck) == false)
                {
                    Kontrollvariable++;
                    MessageBox.Show("Bitte geben Sie eine Zahl als Winkel ein");
                    txbx_Winkeleingabe.Background = Brushes.OrangeRed;
                }
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


    }

    



}
