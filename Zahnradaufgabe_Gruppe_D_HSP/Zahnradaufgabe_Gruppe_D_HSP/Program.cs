using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnradaufgabe_Gruppe_D_HSP
{
    class Program
        
    {
        //Konstante Variablen
        
        

        static void Main(string[] args)  //Hauptschleife
        {

            //Begrüßung in einer Methode
            Begrüßung();



            //Konsoleneingabe
            Console.Write("Zähnezahl: ");
            double zähnezahl = Convert.ToDouble(Console.ReadLine());
            Console.Write("Teilkreisdurchmesser: ");
            double teilkreisdurchmesser = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(zähnezahl);
            Console.ReadKey();


            // Modul = teilkreisdurchmesser / zähnezahl
            // Eingegebene Daten werden in Unterprogrammen berechnet und ausgegeben


        }

        static void Begrüßung() //Methode Begrüßung 1. Hallo/Moin/.... 2. Wir berechnen ein Zahnrad
        {
            Console.WriteLine("Hallo an den Anwender!");
            Console.WriteLine("Willkommen bei dem Zahnradrechner");
            Console.WriteLine("Bitte geben Sie Die Zähnezahl und den Teilkreisdurchmesser (in mm) an");
            Console.WriteLine("Mit ENTER gehts weiter!");
            Console.ReadKey();
        }
        
        //Berechnungen
        

    }
}
static void Main(string[] args)//xiaowei
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
