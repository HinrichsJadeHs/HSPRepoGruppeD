using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnradaufgabe_Gruppe_D_HSP
{
    class Program
        
    {
        double c = 0.167;
        static void Main(string[] args)
        {
            Console.WriteLine("Ein herzerfrischendes Moin Moin an den Anwender!");
            Console.WriteLine("Mit dieser Anwendung können Sie ein Zahnrad konfigurieren.");
            Console.WriteLine("");
            Console.WriteLine("Zur Berechnung werden folgende Daten benötigt: ");
            Console.WriteLine("Modul, Zähnezahl, Teilkreisdurchmesser, Breite und das Material.");



            Console.Write("Geben Sie das Modul ein: ");
            double modul = Convert.ToDouble(Console.ReadLine());
          

            Console.Write("Geben Sie die Zähnezahl ein: ");
            double Zähnezahl = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie den Teilkreisdurchmesser ein: ");
            double Teilkreisdurchmesser = Convert.ToDouble(Console.ReadLine());

            Console.Write("Geben Sie die Breite ein: ");
            double Breite = Convert.ToDouble(Console.ReadLine());

            
            Console.WriteLine("Danke für ihre Eingabe. Mit ENTER wird berechnet!");
            Console.ReadKey();

            Program prg = new Program();
            double h = prg.Zahnhöhe_z(modul);
            Console.WriteLine("Die Zahnhöhe h lautet: " + h);
            Console.ReadKey();

            Console.Write("Geben Sie das Material ein: ");
            string Material = Convert.ToString(Console.ReadLine());
            Console.ReadKey();
        }
        public double Zahnhöhe_z(double modul)
        {
           
            double h = (2 * modul) + c;
            return h;
        }
    }
}
