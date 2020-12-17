using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TestatZahnradCatiaAnbindung
{
    class Zahnrad
    {
        //Eingabenauswahl
        public double teilkreisdurchmesser ;
        public double zähnezahl ;

        //Eingaben
        public double modul ;

        public double dicke ;
        public double bohrung;
        public double bohrungsradius;
        public double außendurchmesser;
        public double außenradius;
        public int eingabeparameter ;
        
        public int nachkommastellen ;
        public double material ;
        public double materialpreis;

        public int Zusatzparameter;
        public int ZusatzparameterInnen;

        //Ausgaben
        public double kopfkreisdurchmesser;
        public double fußkreisdurchmesser;
        public double teilung ;
        public double kopfspiel ;
        public double zahnkopfhöhe ;
        public double zahnfußhöhe ;
        public double zahnhöhe ;
        public double masse;
        public double Preis;
        public const double cf = 0.167;
        public double PassfederBreite;
        public double PassfederHöhe;
        public double EingabeDesTeilkreisdurchmessersCheck=0;

        public bool parameterAußen;
        public bool parameterInnen;

        public int EswurdeGerechnet=0;

        public double WinkelFürGewichtsMinus = 10;

        public bool CatiaError = false;
        

        //Berechnung
        public void Berechnung()
        {
            if (parameterAußen == true)
            {
                if (eingabeparameter == 1)
                {
                    bohrungsradius = bohrung / 2;
                    teilkreisdurchmesser = modul * zähnezahl;
                    teilung = Math.PI * modul;
                    kopfkreisdurchmesser = teilkreisdurchmesser + 2 * modul;
                    kopfspiel = cf * modul;
                    fußkreisdurchmesser = teilkreisdurchmesser - 2 * (modul + kopfspiel);
                    zahnhöhe = 2 * modul + kopfspiel;
                    zahnkopfhöhe = modul;
                    zahnfußhöhe = modul + kopfspiel;
                    masse = (Math.PI / 4) * ((teilkreisdurchmesser * teilkreisdurchmesser) - (bohrung * bohrung)) * dicke * material;
                    Preis = masse * materialpreis;
                    teilkreisdurchmesser = Math.Round(teilkreisdurchmesser, nachkommastellen);
                    teilung = Math.Round(teilung, nachkommastellen);
                    kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                    kopfspiel = Math.Round(kopfspiel, 3);
                    fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                    zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                    zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                    zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                    masse = Math.Round(masse, nachkommastellen);
                    Preis = Math.Round(Preis, 2);
                    außenradius = außendurchmesser / 2;
                    if (Zusatzparameter == 2)
                    {
                        Passfederberechnung();
                    }
                }
                else if (eingabeparameter == 2)
                {
                    EingabeDesTeilkreisdurchmessersCheck = 0;
                    bohrungsradius = bohrung / 2;
                    zähnezahl = teilkreisdurchmesser / modul;
                    zähnezahl = Math.Round(zähnezahl, 0);

                    if (zähnezahl * modul != teilkreisdurchmesser)
                    {
                        teilkreisdurchmesser = zähnezahl * modul;
                        EingabeDesTeilkreisdurchmessersCheck = 1;
                    }

                    teilung = Math.PI * modul;
                    kopfkreisdurchmesser = teilkreisdurchmesser + 2 * modul;
                    kopfspiel = cf * modul;
                    fußkreisdurchmesser = teilkreisdurchmesser - 2 * (modul + kopfspiel);
                    zahnhöhe = 2 * modul + kopfspiel;
                    zahnkopfhöhe = modul;
                    zahnfußhöhe = modul + kopfspiel;
                    masse = (Math.PI / 4) * ((teilkreisdurchmesser * teilkreisdurchmesser) - (bohrung * bohrung)) * dicke * material;
                    Preis = masse * materialpreis;

                    zähnezahl = Math.Round(zähnezahl, 0);
                    teilung = Math.Round(teilung, nachkommastellen);
                    kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                    kopfspiel = Math.Round(kopfspiel, 3);
                    fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                    zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                    zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                    zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                    masse = Math.Round(masse, nachkommastellen);
                    Preis = Math.Round(Preis, 2);
                    außenradius = außendurchmesser / 2;
                    if (Zusatzparameter == 2)
                    {
                        Passfederberechnung();
                    }
                }
            }
            if(parameterInnen == true)
            {

                if (eingabeparameter == 1)
                {
                    fußkreisdurchmesser = teilkreisdurchmesser + 2 * (modul + kopfspiel);
                    if (ZusatzparameterInnen == 0)
                    {
                        außendurchmesser = fußkreisdurchmesser + 20;
                    }
                    bohrungsradius = bohrung / 2;
                    teilkreisdurchmesser = modul * zähnezahl;
                    teilung = Math.PI * modul;
                    kopfkreisdurchmesser = teilkreisdurchmesser - 2 * modul;
                    kopfspiel = cf * modul;
                    
                    zahnhöhe = 2 * modul + kopfspiel;
                    zahnkopfhöhe = modul;
                    zahnfußhöhe = modul + kopfspiel;
                    masse = (Math.PI / 4) * ((außendurchmesser * außendurchmesser) - (teilkreisdurchmesser * teilkreisdurchmesser)) * dicke * material;
                    Preis = masse * materialpreis;

                    teilkreisdurchmesser = Math.Round(teilkreisdurchmesser, nachkommastellen);
                    teilung = Math.Round(teilung, nachkommastellen);
                    kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                    kopfspiel = Math.Round(kopfspiel, 3);
                    fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                    zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                    zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                    zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                    masse = Math.Round(masse, nachkommastellen);
                    Preis = Math.Round(Preis, 2);
                    außendurchmesser = Math.Round(außendurchmesser, nachkommastellen);
                    außenradius = außendurchmesser / 2;
                    if (Zusatzparameter == 2)
                    {
                        Passfederberechnung();
                    }

                    
                }
                else if (eingabeparameter == 2)
                {
                    fußkreisdurchmesser = teilkreisdurchmesser - 2 * (modul + kopfspiel);
                    kopfkreisdurchmesser = teilkreisdurchmesser + 2 * modul;
                    if (ZusatzparameterInnen == 0)
                    {
                        außendurchmesser = kopfkreisdurchmesser  + 20;
                    }

                    EingabeDesTeilkreisdurchmessersCheck = 0;
                    bohrungsradius = bohrung / 2;
                    zähnezahl = teilkreisdurchmesser / modul;
                    zähnezahl = Math.Round(zähnezahl, 0);

                    if (zähnezahl * modul != teilkreisdurchmesser)
                    {
                        teilkreisdurchmesser = zähnezahl * modul;
                        EingabeDesTeilkreisdurchmessersCheck = 1;
                    }

                    teilung = Math.PI * modul;
                    
                    kopfspiel = cf * modul;
                    
                    zahnhöhe = 2 * modul + kopfspiel;
                    zahnkopfhöhe = modul;
                    zahnfußhöhe = modul + kopfspiel;
                    masse = (Math.PI / 4) * ((außendurchmesser * außendurchmesser) - (teilkreisdurchmesser * teilkreisdurchmesser)) * dicke * material;
                    Preis = masse * materialpreis;

                    zähnezahl = Math.Round(zähnezahl, 0);
                    teilung = Math.Round(teilung, nachkommastellen);
                    kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                    kopfspiel = Math.Round(kopfspiel, 3);
                    fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                    zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                    zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                    zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                    masse = Math.Round(masse, nachkommastellen);
                    Preis = Math.Round(Preis, 2);
                    außenradius = außendurchmesser / 2;



                    if (Zusatzparameter == 2)
                    {
                        Passfederberechnung();
                    }
                }
            }
        }

        public void Passfederberechnung()
        {
            if(bohrung <= 12)
            {
                PassfederHöhe = bohrungsradius + 1.8;
            }
            if (bohrung > 12 && bohrung <= 17)
            {
                PassfederHöhe = bohrungsradius + 2.3;
            }
            if (bohrung > 17 && bohrung <= 22)
            {
                PassfederHöhe = bohrungsradius + 2.8;
            }
            if (bohrung > 22 && bohrung <= 44)
            {
                PassfederHöhe = bohrungsradius + 3.3;
            }
            if (bohrung > 44 && bohrung <= 50)
            {
                PassfederHöhe = bohrungsradius + 3.8;
            }
            if (bohrung > 50 && bohrung <= 58)
            {
                PassfederHöhe = bohrungsradius + 4.3;
            }
            if (bohrung > 58 && bohrung <= 65)
            {
                PassfederHöhe = bohrungsradius + 4.4;
            }
            if (bohrung > 65 && bohrung <= 75)
            {
                PassfederHöhe = bohrungsradius + 4.9;
            }
            if (bohrung > 75 && bohrung <= 95)
            {
                PassfederHöhe = bohrungsradius + 5.4;
            }
            if (bohrung > 95 && bohrung <= 110)
            {
                PassfederHöhe = bohrungsradius + 6.4;
            }
            if (bohrung > 110 && bohrung <= 130)
            {
                PassfederHöhe = bohrungsradius + 7.4;
            }
            if (bohrung > 130 && bohrung <= 150)
            {
                PassfederHöhe = bohrungsradius + 8.4;
            }
            if (bohrung > 150 && bohrung <= 170)
            {
                PassfederHöhe = bohrungsradius + 9.4;
            }
            if (bohrung > 170 )
            {
                PassfederHöhe = bohrungsradius + 10.4;
            }

            if (bohrung <= 12)
            {
                PassfederBreite = 4;
            }
            if (bohrung > 12 && bohrung <= 17)
            {
                PassfederBreite = 5;
            }
            if (bohrung > 17 && bohrung <= 22)
            {
                PassfederBreite = 6;
            }
            if (bohrung > 22 && bohrung <= 30)
            {
                PassfederBreite = 8;
            }
            if (bohrung > 30 && bohrung <= 38)
            {
                PassfederBreite = 10;
            }
            if (bohrung > 38 && bohrung <= 44)
            {
                PassfederBreite = 12;
            }
            if (bohrung > 44 && bohrung <= 50)
            {
                PassfederBreite = 14;
            }
            if (bohrung > 50 && bohrung <= 58)
            {
                PassfederBreite = 16;
            }
            if (bohrung > 58 && bohrung <= 65)
            {
                PassfederBreite = 18;
            }
            if (bohrung > 65 && bohrung <= 75)
            {
                PassfederBreite = 20;
            }
            if (bohrung > 75 && bohrung <= 85)
            {
                PassfederBreite = 22;
            }
            if (bohrung > 85 && bohrung <= 95)
            {
                PassfederBreite = 25;
            }
            if (bohrung > 95 && bohrung <= 110)
            {
                PassfederBreite = 28;
            }
            if (bohrung > 110 && bohrung <= 130)
            {
                PassfederBreite = 32;
            }
            if (bohrung > 130 && bohrung <= 150)
            {
                PassfederBreite = 36;
            }
            if (bohrung > 150 && bohrung <= 170)
            {
                PassfederBreite = 40;
            }
            if (bohrung > 170)
            {
                PassfederBreite = 45;
            }

        }
        //eingabeparameter aufnehmen
        public string Nachkommarstellen
        {
            set
            {
                nachkommastellen = Convert.ToInt32(value);
            }
            get
            {
                return Convert.ToString(nachkommastellen);
            }

        }

        public string Eingabeparameter
        {
            set
            {
                eingabeparameter = Convert.ToInt32(value);
            }
            get
            {
                return Convert.ToString(eingabeparameter);
            }

        }

        public string Zähnezahl
        {
            
                set
                {
                    if (eingabeparameter == 1)
                    {
                    zähnezahl = Convert.ToDouble(value);
                    }
                    else if (eingabeparameter == 2)
                {
                    zähnezahl = Convert.ToDouble(Math.Round(teilkreisdurchmesser / modul,0));
                }
                }
                get
                {
                    return Convert.ToString(zähnezahl);
                }
            
        }
        public string Teilkreisdurchmesser
        {
            set
            {
                teilkreisdurchmesser = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(teilkreisdurchmesser);
            }

        }
        public string Modul
        {
            set 
            {
                modul = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(modul);
            }

        }
        public string Dicke
        {
            set
            {
                dicke = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(dicke);
            }

        }
        public string Bohrung
        {
           
            
            set
            {
                bohrung = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(bohrung);
            }
            
        }

        public string Außendurchmesser
        {


            set
            {
                außendurchmesser = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(außendurchmesser);
            }

        }

        public string Material
        {
            set
            {
                material = Convert.ToDouble(value);
            }
            get
            {
                return Convert.ToString(material);
            }

        }

        

      


    }
}
