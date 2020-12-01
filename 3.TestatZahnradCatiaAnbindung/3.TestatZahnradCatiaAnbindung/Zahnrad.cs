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
        public int eingabeparameter ;
        
        public int nachkommastellen ;
        public double material ;

        //Ausgaben
        public double kopfkreisdurchmesser;
        public double fußkreisdurchmesser;
        public double teilung ;
        public double kopfspiel ;
        public double zahnkopfhöhe ;
        public double zahnfußhöhe ;
        public double zahnhöhe ;
        public double masse;
        public const double cf = 0.167;

        //Berechnung
        public void Berechnung()
        {
            if (eingabeparameter == 1)
            {
                teilkreisdurchmesser = modul * zähnezahl;
                teilung = Math.PI * modul;
                kopfkreisdurchmesser = teilkreisdurchmesser + 2 * modul;
                kopfspiel = cf * modul;
                fußkreisdurchmesser = teilkreisdurchmesser - 2 * (modul + kopfspiel);
                zahnhöhe = 2 * modul + kopfspiel;
                zahnkopfhöhe = modul;
                zahnfußhöhe = modul + kopfspiel;
                masse = (Math.PI / 4) * ((teilkreisdurchmesser * teilkreisdurchmesser) - (bohrung * bohrung)) * dicke * material;

                teilkreisdurchmesser = Math.Round(teilkreisdurchmesser, nachkommastellen);
                teilung = Math.Round(teilung, nachkommastellen);
                kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                kopfspiel = Math.Round(kopfspiel, nachkommastellen);
                fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                masse = Math.Round(masse, nachkommastellen);
            }
            else if (eingabeparameter == 2)
            {
                zähnezahl = teilkreisdurchmesser / modul;
                teilung = Math.PI * modul;
                kopfkreisdurchmesser = teilkreisdurchmesser + 2 * modul;
                kopfspiel = cf * modul;
                fußkreisdurchmesser = teilkreisdurchmesser - 2 * (modul + kopfspiel);
                zahnhöhe = 2 * modul + kopfspiel;
                zahnkopfhöhe = modul;
                zahnfußhöhe = modul + kopfspiel;
                masse = (Math.PI / 4) * ((teilkreisdurchmesser * teilkreisdurchmesser) - (bohrung * bohrung)) * dicke * material;


                zähnezahl = Math.Round(zähnezahl, 0);
                teilung = Math.Round(teilung, nachkommastellen);
                kopfkreisdurchmesser = Math.Round(kopfkreisdurchmesser, nachkommastellen);
                kopfspiel = Math.Round(kopfspiel, nachkommastellen);
                fußkreisdurchmesser = Math.Round(fußkreisdurchmesser, nachkommastellen);
                zahnhöhe = Math.Round(zahnhöhe, nachkommastellen);
                zahnkopfhöhe = Math.Round(zahnkopfhöhe, nachkommastellen);
                zahnfußhöhe = Math.Round(zahnfußhöhe, nachkommastellen);
                masse = Math.Round(masse, nachkommastellen);
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
