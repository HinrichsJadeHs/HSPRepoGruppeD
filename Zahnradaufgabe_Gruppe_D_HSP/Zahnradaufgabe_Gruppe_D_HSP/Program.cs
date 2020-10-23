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
