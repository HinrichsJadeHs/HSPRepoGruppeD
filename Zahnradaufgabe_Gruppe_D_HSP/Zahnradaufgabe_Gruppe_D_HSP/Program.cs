﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnradaufgabe_Gruppe_D_HSP
{
    class Program
        
    {

        static void Main(string[] args)  //Hauptschleife
        {
            Boolean abfrage = true;
            while (abfrage == true)
            {
                //Begrüßung in einer Methode
                Begrüßung();
                //Begrüßung in einer Methode

                //Konsoleneingabe
                Console.WriteLine("...");
                Console.Write("Geben Sie die gewünschte Zähnezahl an: ");
                double z = Convert.ToDouble(Console.ReadLine());
                Console.Write("Geben Sie den gewünschten Teilkreisdurchmesser an: ");
                double d = Convert.ToDouble(Console.ReadLine());
                Console.Write("Geben sie die Anzahl der gerundeten Nachkommarstellen an: ");
                int nachkommar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mit ENTER wird berechnet...");
                Console.ReadKey();
                //Konsoleneingabe

                //Verarbeitung in einer Methode
                Program prg = new Program();
                double m = prg.Modul_m(d, z);
                double c = prg.Kopfspiel_c(m);
                double h = prg.Zahnhöhe_h(m, c);
                double df = prg.Fusskreisdurchmesser_df(d, m, c);
                double da = prg.Kopfkreisdurchmesser_da(m, z);
                double p = prg.Teilung_p(m);
                double hf = prg.Zahnfusshöhe_hf(m, c);
                double ha = m;
                //Verarbeitung in einer Methode



                //Ausgabe
                Console.WriteLine("...");
                Console.WriteLine("Das Modul                        m   = " + Math.Round(m, nachkommar));
                Console.WriteLine("Die Teilung                      p   = " + Math.Round(p, nachkommar));
                Console.WriteLine("Die Zahnhöhe                     h   = " + Math.Round(h, nachkommar) + "mm");
                Console.WriteLine("Der Fußkreisdurchmesser          df  = " + Math.Round(df, nachkommar) + "mm");
                Console.WriteLine("Der Kopfkreisdurchmesser         da  = " + Math.Round(da, nachkommar) + "mm");
                Console.WriteLine("Die Zahnfusshöhe                 hf  = " + Math.Round(hf, nachkommar) + "mm");
                Console.WriteLine("Die Zahnkopfhöhe                 ha  = " + Math.Round(ha, nachkommar) + "mm");
                Console.WriteLine("Press ENTER");
                //Ausgabe
                // Eingegebene Daten werden in Unterprogrammen berechnet und ausgegeben

                // erneut ausführen ?
                Console.ReadKey();
                Console.WriteLine("...");
                Console.WriteLine("Mit 1 = wiederholen und mit 2 = beenden");
                Console.Write("Geben Sie ein: ");
                 int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    abfrage = true;
                    Console.Clear();
                }
                else if (i == 2 )
                {
                    Console.Clear();
                    Console.WriteLine("Press ENTER and BYE BYE!");
                    Console.ReadKey();
                    abfrage = false;
                }
                // erneut ausführen ?
               

            }
        }

        static void Begrüßung() //Methode Begrüßung 
        {
            Console.WriteLine("Ein herzerfrischendes MOIN MOIN! an den Anwender!");
            Console.WriteLine("Willkommen bei dem Zahnradrechner");
            Console.WriteLine("...");
            Console.WriteLine("Mit diesem Programm kann exemplarisch gezeigt werden,");
            Console.WriteLine("dass man mit Eingabeparametern Werte für ein Zahnrad ausrechnen kann.");
            Console.WriteLine("...");
            Console.WriteLine("Bitte geben Sie Die Zähnezahl und den Teilkreisdurchmesser (in mm) an");
            Console.WriteLine("Mit ENTER gehts weiter!");
            Console.ReadKey();
        }
        
        //Berechnungen
        public double Modul_m(double d, double z)
        {
            double m = d / z;
            return m;
        }

        public double Zahnhöhe_h(double m, double c)
        {
            double h = 2 * m + c;
            return h;
        }

        public double Fusskreisdurchmesser_df(double d, double m, double c)
        {
            double df = d - 2 * (m + c);
            return df;
        }
        public double Kopfkreisdurchmesser_da(double m, double z)
        {
            double da = m * (z + 2);
            return da;
        }
        public double Teilung_p(double m)
        {
            double p = m * Math.PI;
            return p;
        }
        public double Zahnfusshöhe_hf(double m, double c)
        {
            double hf = m + c;
            return hf;
        }
        //Berechnungen

        //Konstanten
        public double Kopfspiel_c(double m)
        {
            double c = m * 0.167;
            return c;
        }
        //Konstanten


        private static void Xiao(string[] args)//xiaowei
        {
            Console.WriteLine("Hallo an den Anwender!");
            Console.WriteLine("Willkommen bei dem Zahnradrechner");
            Console.WriteLine("Bitte geben Sie Die Zahnhöhe(z) und den Teilkreisdurchmesser（d) (in mm) an");
            Console.WriteLine("Mit ENTER gehts weiter!");
            Console.ReadKey();

            Console.WriteLine("z: ");
            double z = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("d: ");
            double d = Convert.ToDouble(Console.ReadLine());

            double m = d / z;
            double c = 0.167 * m;
            Console.ReadKey();

            Console.WriteLine("Es stehen vier Ergebinisse zur Benutz");
            double q = m + c;
            Console.WriteLine("Zahnhöhe=" + q);


            double e = m;
            Console.WriteLine("Zahnkopfhöhe=" + m);

            double s = m * 3.14;
            Console.WriteLine("Teilung=" + s);

            double h = d - 2 * (m + c);
            Console.WriteLine("Fusskreisdurchmesser=" + h);

            Console.ReadKey();


            Console.WriteLine("Danke für das Benutzen");
            Console.ReadKey();
        }


    }
}

