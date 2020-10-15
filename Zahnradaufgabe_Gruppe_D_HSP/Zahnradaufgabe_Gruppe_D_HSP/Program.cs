﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnradaufgabe_Gruppe_D_HSP
{
    class Program
        
    {
        //Constante Variablen
        const double Spielconstante = 0.167;
        const double PI = 3.1415926535897932384626433832;
        double cosAngle;

        

        static void Main(string[] args)  //Hauptschleife
        {
            
            //Begrüßung
            Begrüßung();

            //Konsoleneingabe
            Console.Write("Geben Sie die Zähnezahl ein: ");
            double zähnezahl = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie den Teilkreisdurchmesser ein: ");
            double teilkreisdurchmesser = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie die Breite ein: ");
            double breite = Convert.ToDouble(Console.ReadLine());
            Console.Write("Auf wie viele Nachkommarstellen soll gerundet werden?: ");
            int deci = Convert.ToInt32(Console.ReadLine());           
            Console.WriteLine("Danke für ihre Eingabe. Mit ENTER wird berechnet!");
            Console.WriteLine("");
            Console.ReadKey();

            // Eingegebene Daten werden in Unterprogrammen berechnet und ausgegeben

            Program prg = new Program();

            double modul = prg.Modul_m(teilkreisdurchmesser, zähnezahl);
            Console.WriteLine("Das Modul                        m   = " + Math.Round(modul , deci) + "mm");
            double h = prg.Zahnhöhe_h(modul, Spielconstante);
            Console.WriteLine("Die Zahnhöhe                     h   = " + Math.Round(h , deci) + "mm");
            double hf = prg.Zahnfusshöhe_hf(modul, Spielconstante);
            Console.WriteLine("Die Zahnfusshöhe                 hf  = " + Math.Round(hf , deci) + "mm");
            double ha = prg.Zahnkopfhöhe_ha(modul);
            Console.WriteLine("Die Zahnkopfhöhe                 ha  = " + Math.Round(ha, deci) + "mm");
            double p = prg.Teilung_p(modul, PI);
            Console.WriteLine("Die Teilung                      p   = " + Math.Round(p, deci) + "mm");
            double df = prg.Fusskreisdurchnmesser_df(modul , teilkreisdurchmesser, Spielconstante );
            Console.WriteLine("Der Fußkreisdurchnmesser         df  = " + Math.Round(df, deci) + "mm");
            double da = prg.Kopfkreisdurchnmesser_da(modul, teilkreisdurchmesser);
            Console.WriteLine("Der Kopfkreisdurchnmesser        da  = " + Math.Round(da, deci) + "mm");
            double db = prg.Grundkreisdurchmesser_db(teilkreisdurchmesser);
            Console.WriteLine("Der Grundkreisdurchnmesser       db  = " + Math.Round(db, deci) + "mm");


            Console.ReadKey();
            Console.Write("Geben Sie das Material ein: ");
            string Material = Convert.ToString(Console.ReadLine());
            Console.ReadKey();
        }

        static void Begrüßung()
        {
            Console.WriteLine("Ein herzerfrischendes Moin Moin an den Anwender!");
            Console.WriteLine("Mit dieser Anwendung können Sie ein Zahnrad konfigurieren.");
            Console.WriteLine("");
            Console.WriteLine("Zur Berechnung werden folgende Daten benötigt: ");
            Console.WriteLine("Zähnezahl , Teilkreisdurchmesser (mm), Breite(mm) und das Material.");
        }
       

        //Berechnungen
        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
        public double Modul_m(double teilkreisdurchmesser, double zähnezahl)
        {
            double modul = teilkreisdurchmesser / zähnezahl;
            return modul;
        }
        public double Zahnhöhe_h(double modul, double Spielconstante)
        {
            double c = Spielconstante * modul;
            double h = 2 * modul + c;
            return h ;
        }

        public double Zahnfusshöhe_hf(double modul, double Spielconstante)
        {
            double c = Spielconstante * modul;
            double hf = modul + c;
            return hf;
        }

        public double Zahnkopfhöhe_ha(double modul)
        {
            
            double ha = modul;
            return ha;
        }

        public double Teilung_p(double modul, double PI)
        {
            double p = PI * modul;
            return p;
        }
        public double Fusskreisdurchnmesser_df(double modul, double teilkreisdurchmesser, double Spielconstante)
        {
            double c = Spielconstante * modul;
            double df = teilkreisdurchmesser - 2 * (c + modul);
            return df;
        }
        public double Kopfkreisdurchnmesser_da(double modul, double teilkreisdurchmesser)
        {
            double da = teilkreisdurchmesser + 2 * modul;
            return da;
        }
        public double Grundkreisdurchmesser_db(double teilkreisdurchmesser)
        {
            cosAngle = Math.Cos(DegreesToRadians(20));
            double db = teilkreisdurchmesser * cosAngle;
            return db;
        }

    }
}
