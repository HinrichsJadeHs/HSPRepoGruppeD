using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;
using HybridShapeTypeLib;
using KnowledgewareTypeLib;
using ProductStructureTypeLib;
using System.Windows;
using System.Windows.Shapes;


namespace _3.TestatZahnradCatiaAnbindung
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;

        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeDasNeueKreismuster(Zahnrad ZR1)
        {
            ShapeFactory shapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)hsp_catiaPart.Part.HybridShapeFactory;

            Factory2D factory2D1 = hsp_catiaProfil.Factory2D;

            HybridShapePointCoord ursprung = hybridShapeFactory1.AddNewPointCoord(0, 0, 0);
            Reference refUrsprung = hsp_catiaPart.Part.CreateReferenceFromObject(ursprung);

            HybridShapeDirection xRichtung = hybridShapeFactory1.AddNewDirectionByCoord(1, 0, 0);
            Reference refxRichtung = hsp_catiaPart.Part.CreateReferenceFromObject(xRichtung);

            CircPattern kreismuster = shapeFactory1.AddNewSurfacicCircPattern(factory2D1, 1, 2, 0, 0, 1, 1, refUrsprung, refxRichtung, false, 0, true, false);
            kreismuster.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;
            AngularRepartition angularRepartition1 = kreismuster.AngularRepartition;
            Angle angle1 = angularRepartition1.AngularSpacing;
            angle1.Value = Convert.ToDouble(360 / ZR1.zähnezahl);
            AngularRepartition angularRepartition2 = kreismuster.AngularRepartition;
            IntParam intParam1 = angularRepartition2.InstancesCount;
            intParam1.Value = Convert.ToInt32(ZR1.zähnezahl) + 1;


            //Kreismusterenden verbinden

            Reference refKreismuster = hsp_catiaPart.Part.CreateReferenceFromObject(kreismuster);
            HybridShapeAssemble verbindung = hybridShapeFactory1.AddNewJoin(refKreismuster, refKreismuster);
            Reference refVerbindung = hsp_catiaPart.Part.CreateReferenceFromObject(verbindung);

            hybridShapeFactory1.GSMVisibility(refVerbindung, 0);

            hsp_catiaPart.Part.MainBody.InsertHybridShape(verbindung);

            

            hsp_catiaPart.Part.Update();

            ErzeugedenNeuenBlock(ZR1, refVerbindung, shapeFactory1);



            
        }

        public void ErzeugedenNeuenBlock(Zahnrad ZR1, Reference refVerbindung, ShapeFactory sf1)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
            Pad catPad1 = sf1.AddNewPadFromRef(refVerbindung, ZR1.dicke);          
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeDieNeueZahnradTasche(Zahnrad ZR1, Reference refVerbindung, ShapeFactory sf1)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
            Pocket catPad1 = sf1.AddNewPocketFromRef(refVerbindung, ZR1.dicke);
            hsp_catiaPart.Part.Update();
        }

        private double Schnittpunkt_X(double xMittelpunkt, double yMittelpunkt, double Radius1, double xMittelpunkt2, double yMittelpunkt2, double Radius2)
        {
            double d = Math.Sqrt(Math.Pow((xMittelpunkt - xMittelpunkt2), 2) + Math.Pow((yMittelpunkt - yMittelpunkt2), 2));
            double l = (Math.Pow(Radius1, 2) - Math.Pow(Radius2, 2) + Math.Pow(d, 2)) / (d * 2);
            double h;
            double Verbindungsabfrage = 0.00001;

            if (Radius1-l < -Verbindungsabfrage)
            {
                MessageBox.Show("Fehler");
            }
            if(Math.Abs(Radius1 - l)< Verbindungsabfrage)
            {
                h = 0;
            }
            else
            {
                h = Math.Sqrt(Math.Pow(Radius1, 2) - Math.Pow(l, 2));
            }

            return l * (xMittelpunkt2 - xMittelpunkt) / d - h * (yMittelpunkt2 - yMittelpunkt) / d + xMittelpunkt;
        }

        private double Schnittpunkt_Y(double xMittelpunkt, double yMittelpunkt, double Radius1, double xMittelpunkt2, double yMittelpunkt2, double Radius2)
        {
            double d = Math.Sqrt(Math.Pow((xMittelpunkt - xMittelpunkt2), 2) + Math.Pow((yMittelpunkt - yMittelpunkt2), 2));
            double l = (Math.Pow(Radius1, 2) - Math.Pow(Radius2, 2) + Math.Pow(d, 2)) / (d * 2);
            double h;
            double Verbindungsabfrage = 0.00001;

            if (Radius1 - l < -Verbindungsabfrage)
            {
                MessageBox.Show("Fehler");
            }
            if (Math.Abs(Radius1 - l) < Verbindungsabfrage)
            {
                h = 0;
            }
            else
            {
                h = Math.Sqrt(Math.Pow(Radius1, 2) - Math.Pow(l, 2));
            }

            return l * (yMittelpunkt2 - yMittelpunkt) / d + h * (xMittelpunkt2 - xMittelpunkt) / d + yMittelpunkt;
        }

        public void GanzeZahnrad(Zahnrad ZR1)
        {
            //Erstelle Skizze
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();

            //Erstelle Skizze Ende


            //Profil Erstellen

            //Deklarieren!! Beginn


            //Nullpunkt
            double x0 = 0;
            double y0 = 0;

            //Hilfsgrößen von Wilkos PDF
            double Teilkreisradius = ZR1.teilkreisdurchmesser / 2;
            double Hilfskreisradius = Teilkreisradius * 0.94;
            double Fußkreisradius = Teilkreisradius - (1.25 * ZR1.modul);
            double Kopfkreisradius = Teilkreisradius + ZR1.modul;
            double Verrundungsradius = 0.35 * ZR1.modul;

            double Alpha = 20;
            double Beta = 90 / ZR1.zähnezahl;
            double Betarad = Math.PI * Beta / 180;
            double Gamma = 90 - (Alpha - Beta);
            double Gammarad = Math.PI * Gamma / 180;
            double Totalangel = 360.0 / ZR1.zähnezahl;
            double Totalangelrad = Math.PI * Totalangel / 180;

            //Punkte
            //LinkerEvolKreis Mittelp. Koordinaten
            double xMittelpunktaufEvol_links = Hilfskreisradius * Math.Cos(Gammarad);
            double yMittelpunktaufEvol_links = Hilfskreisradius * Math.Sin(Gammarad);

            // Schnittpkt. auf Evolvente und Teilkreisradius
            double xPunktAufEvolvente = -Teilkreisradius * Math.Sin(Betarad);
            double yPunktAufEvolvente = Teilkreisradius * Math.Cos(Betarad);

            //Evolventenkreis Radius
            double EvolventenkreisRadius = Math.Sqrt(Math.Pow((xMittelpunktaufEvol_links - xPunktAufEvolvente), 2) + Math.Pow((yMittelpunktaufEvol_links - yPunktAufEvolvente), 2));

            //Koordinaten Schnittpunkt Kopfkreis und Evolventenkreis
            double xEvolventenkopfkreis_links = Schnittpunkt_X(x0, y0, Kopfkreisradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius);
            double yEvolventenkopfkreis_links = Schnittpunkt_Y(x0, y0, Kopfkreisradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius);

            //Mittelpunktkoordinaten Verrundung
            double xMittelpunktVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius + Verrundungsradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius + Verrundungsradius);
            double yMittelpunktVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius + Verrundungsradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius + Verrundungsradius);

            //Schnittpubktkoordinaten Verrundung - Evolventenkreis
            double x_SP_EvolventeVerrundung_links = Schnittpunkt_X(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_EvolventeVerrundung_links = Schnittpunkt_Y(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Schnittpunktkoordinaten Verrundung - Fußkreis
            double x_SP_FußkreisradiusVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_FußkreisradiusVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Koordinaten Anfangspunkt Fußkreis
            double Hilfswinkel = Totalangelrad - Math.Atan(Math.Abs(x_SP_FußkreisradiusVerrundung_links) / Math.Abs(y_SP_FußkreisradiusVerrundung_links));
            double x_AnfangspunktFußkreis = -Fußkreisradius * Math.Sin(Hilfswinkel);
            double y_AnfangspunktFußkreis = Fußkreisradius * Math.Cos(Hilfswinkel);


            //Deklarieren!! Ende



            //Skizze umbenennen und öffnen
            hsp_catiaProfil.set_Name("Zahnrädchen");
            Factory2D catfactory2D1 = hsp_catiaProfil.OpenEdition();

            //Nun die Punkte in die Skizze
            Point2D point_Ursprung = catfactory2D1.CreatePoint(x0, y0);
            Point2D pointAnfangFußkreisLinks = catfactory2D1.CreatePoint(x_AnfangspunktFußkreis, y_AnfangspunktFußkreis);
            Point2D pointFußkreisVerrundungLinks = catfactory2D1.CreatePoint(x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D pointFußkreisVerrundungRechts = catfactory2D1.CreatePoint(-x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D pointMittelpunktVerrundungLinks = catfactory2D1.CreatePoint(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D pointMittelpunktVerrundungRechts = catfactory2D1.CreatePoint(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D pointVerrundungEvolventeLinks = catfactory2D1.CreatePoint(x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D pointVerrundungEvolventeRechts = catfactory2D1.CreatePoint(-x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D pointMittelpunktevolventeLinks = catfactory2D1.CreatePoint(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links);
            Point2D pointMittelpunktevolventeRechts = catfactory2D1.CreatePoint(-xMittelpunktaufEvol_links, yMittelpunktaufEvol_links);
            Point2D pointEvolventenKopfkreisLinks = catfactory2D1.CreatePoint(xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);
            Point2D pointEvolventenKopfkreisRechts = catfactory2D1.CreatePoint(-xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);

            //Kreise

            Circle2D KreisFrußkreis = catfactory2D1.CreateCircle(x0, y0, Fußkreisradius, 0, Math.PI * 2);
            KreisFrußkreis.CenterPoint = point_Ursprung;
            KreisFrußkreis.StartPoint = pointFußkreisVerrundungLinks;
            KreisFrußkreis.EndPoint = pointAnfangFußkreisLinks;

            Circle2D KreisVerrundungLinks = catfactory2D1.CreateCircle(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            KreisVerrundungLinks.CenterPoint = pointMittelpunktVerrundungLinks;
            KreisVerrundungLinks.StartPoint = pointFußkreisVerrundungLinks;
            KreisVerrundungLinks.EndPoint = pointVerrundungEvolventeLinks;

            Circle2D KreisEvolventenkreisLinks = catfactory2D1.CreateCircle(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, 0, Math.PI * 2);
            KreisEvolventenkreisLinks.CenterPoint = pointMittelpunktevolventeLinks;
            KreisEvolventenkreisLinks.StartPoint = pointEvolventenKopfkreisLinks;
            KreisEvolventenkreisLinks.EndPoint = pointVerrundungEvolventeLinks;

            Circle2D KreisKopfkreis = catfactory2D1.CreateCircle(x0, y0, Kopfkreisradius, 0, Math.PI * 2);
            KreisKopfkreis.CenterPoint = point_Ursprung;
            KreisKopfkreis.StartPoint = pointEvolventenKopfkreisRechts;
            KreisKopfkreis.EndPoint = pointEvolventenKopfkreisLinks;

            Circle2D KreisEvolventenkreisRechts = catfactory2D1.CreateCircle(-xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, 0, Math.PI * 2);
            KreisEvolventenkreisRechts.CenterPoint = pointMittelpunktevolventeRechts;
            KreisEvolventenkreisRechts.StartPoint = pointVerrundungEvolventeRechts;
            KreisEvolventenkreisRechts.EndPoint = pointEvolventenKopfkreisRechts;

            Circle2D KreisVerrundungRechts = catfactory2D1.CreateCircle(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            KreisVerrundungRechts.CenterPoint = pointMittelpunktVerrundungRechts;
            KreisVerrundungRechts.StartPoint = pointVerrundungEvolventeRechts;
            KreisVerrundungRechts.EndPoint = pointFußkreisVerrundungRechts;



            hsp_catiaProfil.CloseEdition();

            hsp_catiaPart.Part.Update();


            

            //Profilerstellen Ende


            ShapeFactory shapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)hsp_catiaPart.Part.HybridShapeFactory;

            Factory2D factory2D1 = hsp_catiaProfil.Factory2D;

            HybridShapePointCoord ursprung = hybridShapeFactory1.AddNewPointCoord(0, 0, 0);
            Reference refUrsprung = hsp_catiaPart.Part.CreateReferenceFromObject(ursprung);

            HybridShapeDirection xRichtung = hybridShapeFactory1.AddNewDirectionByCoord(1, 0, 0);
            Reference refxRichtung = hsp_catiaPart.Part.CreateReferenceFromObject(xRichtung);

            CircPattern kreismuster = shapeFactory1.AddNewSurfacicCircPattern(factory2D1, 1, 2, 0, 0, 1, 1, refUrsprung, refxRichtung, false, 0, true, false);
            kreismuster.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;
            AngularRepartition angularRepartition1 = kreismuster.AngularRepartition;
            Angle angle1 = angularRepartition1.AngularSpacing;
            angle1.Value = Convert.ToDouble(360 / ZR1.zähnezahl);
            AngularRepartition angularRepartition2 = kreismuster.AngularRepartition;
            IntParam intParam1 = angularRepartition2.InstancesCount;
            intParam1.Value = Convert.ToInt32(ZR1.zähnezahl) + 1;


            //Kreismusterenden verbinden

            Reference refKreismuster = hsp_catiaPart.Part.CreateReferenceFromObject(kreismuster);
            HybridShapeAssemble verbindung = hybridShapeFactory1.AddNewJoin(refKreismuster, refKreismuster);
            Reference refVerbindung = hsp_catiaPart.Part.CreateReferenceFromObject(verbindung);

            hybridShapeFactory1.GSMVisibility(refVerbindung, 0);

            hsp_catiaPart.Part.MainBody.InsertHybridShape(verbindung);



            hsp_catiaPart.Part.Update();

            ErzeugedenNeuenBlock(ZR1, refVerbindung, shapeFactory1);


            //Profil Erstellen

            // zweite skizze öffnen zeichnen, und eine Tasche daraus bilden

            if (ZR1.Zusatzparameter == 1 )
            {
                Sketches sketchesBohrung = catHybridBody1.HybridSketches;
                OriginElements catoriginelements = hsp_catiaPart.Part.OriginElements;
                Reference refmxPlaneX = (Reference)catoriginelements.PlaneYZ;
                hsp_catiaProfil = catSketches1.Add(refmxPlaneX);

                ErzeugeAchsensystem();

                hsp_catiaPart.Part.Update();

                hsp_catiaProfil.set_Name("Bohrung");

                Factory2D catfactory2D2 = hsp_catiaProfil.OpenEdition();

                Circle2D KreisFürBohrungsskizze = catfactory2D2.CreateClosedCircle(x0, y0, ZR1.bohrungsradius);

                hsp_catiaProfil.CloseEdition();

                hsp_catiaPart.Part.Update();

                hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
                Pocket Tasche = shapeFactory1.AddNewPocket(hsp_catiaProfil, ZR1.dicke);
                hsp_catiaPart.Part.Update();
            }
            if (ZR1.Zusatzparameter == 2 )
            {
                //Koordinaten der Punkte

                //KoordinatenPunkt Links Kreis-Anfang Passfeder
                double x_AnfangkreisZuPassfeder = -ZR1.PassfederBreite / 2;
                double y_AnfangkreisZuPassfeder = Math.Sqrt(Math.Pow(ZR1.bohrungsradius, 2) - Math.Pow((ZR1.PassfederBreite / 2), 2));

                //KoordinatenPunkt LinksobenPassfeder
                double x_Passfederecke = -ZR1.PassfederBreite / 2;
                double y_Passfederecke = ZR1.PassfederHöhe;


                Sketches sketchesBohrung = catHybridBody1.HybridSketches;
                OriginElements catoriginelements = hsp_catiaPart.Part.OriginElements;
                Reference refmxPlaneX = (Reference)catoriginelements.PlaneYZ;
                hsp_catiaProfil = catSketches1.Add(refmxPlaneX);

                ErzeugeAchsensystem();

                hsp_catiaPart.Part.Update();

                hsp_catiaProfil.set_Name("Passfederbohrung");

                Factory2D catfactory2D2 = hsp_catiaProfil.OpenEdition();



                //Punkte in die Skizze
                Point2D POINTLinksAnfangKreisZuPassfeder = catfactory2D2.CreatePoint(x_AnfangkreisZuPassfeder, y_AnfangkreisZuPassfeder);
                Point2D POINTLinksPassfederEcke = catfactory2D2.CreatePoint(x_Passfederecke, y_Passfederecke);
                Point2D POINTRechtsPassfederEcke = catfactory2D2.CreatePoint(-x_Passfederecke, y_Passfederecke);
                Point2D POINTRechtsAnfangKreisZuPassfeder = catfactory2D2.CreatePoint(-x_AnfangkreisZuPassfeder, y_AnfangkreisZuPassfeder);

                //Linen ziehen
                Line2D PassfederKanteLinks = catfactory2D2.CreateLine(x_AnfangkreisZuPassfeder, y_AnfangkreisZuPassfeder, x_Passfederecke, y_Passfederecke);
                PassfederKanteLinks.StartPoint = POINTLinksAnfangKreisZuPassfeder;
                PassfederKanteLinks.EndPoint = POINTLinksPassfederEcke;

                Line2D PassfederHöhenkante = catfactory2D2.CreateLine(x_Passfederecke, y_Passfederecke, -x_Passfederecke, y_Passfederecke);
                PassfederHöhenkante.StartPoint = POINTLinksPassfederEcke;
                PassfederHöhenkante.EndPoint = POINTRechtsPassfederEcke;

                Line2D PassfederKanteRechts = catfactory2D2.CreateLine(-x_Passfederecke, y_Passfederecke, -x_AnfangkreisZuPassfeder, y_AnfangkreisZuPassfeder);
                PassfederKanteRechts.StartPoint = POINTRechtsPassfederEcke;
                PassfederKanteRechts.EndPoint = POINTRechtsAnfangKreisZuPassfeder;

                Circle2D KreisFürPassfeder = catfactory2D2.CreateCircle(x0, y0, ZR1.bohrungsradius, 0, Math.PI * 2);
                KreisFürPassfeder.CenterPoint = point_Ursprung;
                KreisFürPassfeder.EndPoint = POINTRechtsAnfangKreisZuPassfeder;
                KreisFürPassfeder.StartPoint = POINTLinksAnfangKreisZuPassfeder;




                hsp_catiaProfil.CloseEdition();

                hsp_catiaPart.Part.Update();

                hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
                Pocket Tasche = shapeFactory1.AddNewPocket(hsp_catiaProfil, ZR1.dicke);
                hsp_catiaPart.Part.Update();
            }
            if (ZR1.Zusatzparameter == 1)
            {
                MessageBoxResult result = MessageBox.Show("Es ist eine Gewichtsoptimierung verfügbar, soll diese im 3D-Model implementiert werden ?", "Gewichtsoptimierung?", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ZR1.Zusatzparameter = 3;
                        break;
                    case MessageBoxResult.No:
                        ZR1.Zusatzparameter = 0;
                        break;

                }
            }

            if ( ZR1.Zusatzparameter ==3 )
            {

                double UntererKreisradius = Math.Round(ZR1.bohrungsradius,0) + 15;
                double ObererKreisradius = Math.Round( (ZR1.fußkreisdurchmesser / 2),0) - 15;
                double VerrundungsradiusGewichtsopt = (ObererKreisradius*2 + UntererKreisradius*2) / 4 - UntererKreisradius;
                double Winkel = 10;
                double WinkelRad = Math.PI * Winkel / 180;



                //Koordinaten der Punkte

                //KoordinatenPunkt Links unten
                double x_UntenLinks = -UntererKreisradius* Math.Sin(WinkelRad);
                double y_UntenLinks = UntererKreisradius * Math.Cos(WinkelRad);

                //KoordinatenPunkt Links oben
                double x_ObenLinks = -ObererKreisradius * Math.Sin(WinkelRad);
                double y_ObenLinks = ObererKreisradius * Math.Cos(WinkelRad);

                //KoordinatenPunkt Rechts oben
                double x_ObenRechts = ObererKreisradius * Math.Sin(WinkelRad);
                double y_ObenRechts = ObererKreisradius * Math.Cos(WinkelRad);

                //KoordinatenPunkt Rechts unten
                double x_UntenRechts = UntererKreisradius * Math.Sin(WinkelRad);
                double y_UntenRechts = UntererKreisradius * Math.Cos(WinkelRad);

                //KoordinatenMittelPunkt VerrundungLinks
                double x_VerrundungsmittelpunktLinks = -(ObererKreisradius*2 + UntererKreisradius*2)/4 * Math.Sin(WinkelRad);
                double y_VerrundungsmittelpunktLinks = (ObererKreisradius*2 + UntererKreisradius*2)/4 * Math.Cos(WinkelRad);

                //KoordinatenMittelPunkt VerrundungRechts
                double x_VerrundungsmittelpunktRechts = (ObererKreisradius*2 + UntererKreisradius*2)/4 * Math.Sin(WinkelRad);
                double y_VerrundungsmittelpunktRechts = (ObererKreisradius*2 + UntererKreisradius*2)/4 * Math.Cos(WinkelRad);




                Sketches sketchesGewichtsReduzierung = catHybridBody1.HybridSketches;
                OriginElements catoriginelements = hsp_catiaPart.Part.OriginElements;
                Reference refmxPlaneX = (Reference)catoriginelements.PlaneYZ;
                hsp_catiaProfil = catSketches1.Add(refmxPlaneX);

                ErzeugeAchsensystem();

                hsp_catiaPart.Part.Update();

                hsp_catiaProfil.set_Name("Passfederbohrung");

                Factory2D catfactory2D3 = hsp_catiaProfil.OpenEdition();



                //Punkte in die Skizze
                Point2D POINTLinksUnten = catfactory2D3.CreatePoint(x_UntenLinks, y_UntenLinks);
                Point2D POINTLinksOben = catfactory2D3.CreatePoint(x_ObenLinks, y_ObenLinks);
                Point2D POINTRechtsOben = catfactory2D3.CreatePoint(x_ObenRechts, y_ObenRechts);
                Point2D POINTRechtsUnten = catfactory2D3.CreatePoint(x_UntenRechts, y_UntenRechts);
                Point2D POINTVerrundungMittelPunktLinks = catfactory2D3.CreatePoint(x_VerrundungsmittelpunktLinks, y_VerrundungsmittelpunktLinks);
                Point2D POINTVerrundungMittelPunktRechts = catfactory2D3.CreatePoint(x_VerrundungsmittelpunktRechts, y_VerrundungsmittelpunktRechts);


                //Linen ziehen
                Circle2D KreisVerrundungUntenNachObenLinks = catfactory2D3.CreateCircle(x_VerrundungsmittelpunktLinks, y_VerrundungsmittelpunktLinks, VerrundungsradiusGewichtsopt, 0, Math.PI * 2);
                KreisVerrundungUntenNachObenLinks.CenterPoint = POINTVerrundungMittelPunktLinks;
                KreisVerrundungUntenNachObenLinks.EndPoint = POINTLinksUnten;
                KreisVerrundungUntenNachObenLinks.StartPoint = POINTLinksOben;

                Circle2D KreisObenLinksnachObenRechts = catfactory2D3.CreateCircle(x0, y0, ObererKreisradius, 0, Math.PI * 2);
                KreisObenLinksnachObenRechts.CenterPoint = point_Ursprung;
                KreisObenLinksnachObenRechts.EndPoint =  POINTLinksOben;
                KreisObenLinksnachObenRechts.StartPoint =  POINTRechtsOben;

                Circle2D KreisVerrundungObennachUntenRechts = catfactory2D3.CreateCircle(x_VerrundungsmittelpunktRechts, y_VerrundungsmittelpunktRechts, VerrundungsradiusGewichtsopt, 0, Math.PI * 2);
                KreisVerrundungObennachUntenRechts.CenterPoint = POINTVerrundungMittelPunktRechts;
                KreisVerrundungObennachUntenRechts.EndPoint = POINTRechtsOben;
                KreisVerrundungObennachUntenRechts.StartPoint = POINTRechtsUnten;

                Circle2D KreisUntenLinksUntenRechts = catfactory2D3.CreateCircle(x0, y0, UntererKreisradius, 0, Math.PI * 2);
                KreisUntenLinksUntenRechts.CenterPoint = point_Ursprung;
                KreisUntenLinksUntenRechts.EndPoint = POINTLinksUnten;
                KreisUntenLinksUntenRechts.StartPoint = POINTRechtsUnten;



                hsp_catiaProfil.CloseEdition();

                hsp_catiaPart.Part.Update();

                hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
                Pocket Tasche2 = shapeFactory1.AddNewPocket(hsp_catiaProfil, ZR1.dicke);
                hsp_catiaPart.Part.Update();

                CircPattern kreismusterFürwenigerGewicht = shapeFactory1.AddNewCircPattern(Tasche2, 1, 4, 20, 90, 1, 1, refUrsprung, refxRichtung, true, 0, true);
                kreismusterFürwenigerGewicht.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;


                hsp_catiaPart.Part.Update();





            }



        }

        public void GanzeInnenZahnrad(Zahnrad ZR1)
        {
            double x0 = 0;
            double y0 = 0;

            //Hilfsgrößen von Wilkos PDF nach Innenverzahnung umgestellt
            double Teilkreisradius = ZR1.teilkreisdurchmesser / 2;
            double Hilfskreisradius = Teilkreisradius * 1.12;
            double Kopfkreisradius = Teilkreisradius - (1.25 * ZR1.modul);
            double Fußkreisradius = Teilkreisradius + ZR1.modul;
            double Verrundungsradius = 0.35 * ZR1.modul;

            double Alpha = 20;
            double Beta = 90 / ZR1.zähnezahl;
            double Betarad = Math.PI * Beta / 180;
            double Gamma = 90 - (Alpha - Beta);
            double Gammarad = Math.PI * Gamma / 180;
            double Totalangel = 360.0 / ZR1.zähnezahl;
            double Totalangelrad = Math.PI * Totalangel / 180;

            //Punkte von außen nach innenverzahnung umgestellt
            //LinkerEvolKreis Mittelp. Koordinaten
            double xMittelpunktaufEvol_links = Hilfskreisradius * Math.Cos(Gammarad);
            double yMittelpunktaufEvol_links = Hilfskreisradius * Math.Sin(Gammarad);

            // Schnittpkt. auf Evolvente und Teilkreisradius
            double xPunktAufEvolvente = -Teilkreisradius * Math.Sin(Betarad);
            double yPunktAufEvolvente = Teilkreisradius * Math.Cos(Betarad);

            //Evolventenkreis Radius
            double EvolventenkreisRadius = Math.Sqrt(Math.Pow((xMittelpunktaufEvol_links - xPunktAufEvolvente), 2) + Math.Pow((yMittelpunktaufEvol_links - yPunktAufEvolvente), 2));

            //Koordinaten Schnittpunkt Kopfkreis und Evolventenkreis
            double xEvolventenkopfkreis_links = Schnittpunkt_X(x0, y0, Kopfkreisradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius);
            double yEvolventenkopfkreis_links = Schnittpunkt_Y(x0, y0, Kopfkreisradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius);

            //Mittelpunktkoordinaten Verrundung
            double xMittelpunktVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius - Verrundungsradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius + Verrundungsradius);
            double yMittelpunktVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius - Verrundungsradius, xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius + Verrundungsradius);

            //Schnittpubktkoordinaten Verrundung - Evolventenkreis
            double x_SP_EvolventeVerrundung_links = Schnittpunkt_X(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_EvolventeVerrundung_links = Schnittpunkt_Y(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Schnittpunktkoordinaten Verrundung - Fußkreis
            double x_SP_FußkreisradiusVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_FußkreisradiusVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Koordinaten Anfangspunkt Fußkreis
            double Hilfswinkel = Totalangelrad - Math.Atan(Math.Abs(x_SP_FußkreisradiusVerrundung_links) / Math.Abs(y_SP_FußkreisradiusVerrundung_links));
            double x_AnfangspunktFußkreis = -Fußkreisradius * Math.Sin(Hilfswinkel);
            double y_AnfangspunktFußkreis = Fußkreisradius * Math.Cos(Hilfswinkel);












            //Erstelle Skizze
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            
            //erst skizze für einen Block


            ShapeFactory shapeFactory2 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)hsp_catiaPart.Part.HybridShapeFactory;

            Sketches sketchesBohrung = catHybridBody1.HybridSketches;
            OriginElements catoriginelements = hsp_catiaPart.Part.OriginElements;
            Reference refmxPlaneX = (Reference)catoriginelements.PlaneYZ;
            hsp_catiaProfil = sketchesBohrung.Add(refmxPlaneX);

            ErzeugeAchsensystem();

            hsp_catiaPart.Part.Update();

            hsp_catiaProfil.set_Name("Block");

            Factory2D catfactory2D2 = hsp_catiaProfil.OpenEdition();
            if (ZR1.ZusatzparameterInnen == 0)
            {
                Circle2D KreisFürBohrungsskizze = catfactory2D2.CreateClosedCircle(x0, y0, Fußkreisradius+10);
            }
            else if (ZR1.ZusatzparameterInnen > 0)
            {
                Circle2D KreisFürBohrungsskizze = catfactory2D2.CreateClosedCircle(x0, y0, ZR1.außenradius);
            }

            hsp_catiaProfil.CloseEdition();

            hsp_catiaPart.Part.Update();

            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
            Pad Block = shapeFactory2.AddNewPad(hsp_catiaProfil, ZR1.dicke);
            hsp_catiaPart.Part.Update();

            //dann zahnradskizze für eine tasche

            //Skizze umbenennen und öffnen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
            
            ShapeFactory shapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            hsp_catiaProfil.set_Name("Zahnrädchen");
            Factory2D catfactory2D1 = hsp_catiaProfil.OpenEdition();

            //Nun die Punkte in die Skizze
            Point2D point_Ursprung = catfactory2D1.CreatePoint(x0, y0);
            Point2D pointAnfangFußkreisLinks = catfactory2D1.CreatePoint(x_AnfangspunktFußkreis, y_AnfangspunktFußkreis);
            Point2D pointFußkreisVerrundungLinks = catfactory2D1.CreatePoint(x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D pointFußkreisVerrundungRechts = catfactory2D1.CreatePoint(-x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D pointMittelpunktVerrundungLinks = catfactory2D1.CreatePoint(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D pointMittelpunktVerrundungRechts = catfactory2D1.CreatePoint(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D pointVerrundungEvolventeLinks = catfactory2D1.CreatePoint(x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D pointVerrundungEvolventeRechts = catfactory2D1.CreatePoint(-x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D pointMittelpunktevolventeLinks = catfactory2D1.CreatePoint(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links);
            Point2D pointMittelpunktevolventeRechts = catfactory2D1.CreatePoint(-xMittelpunktaufEvol_links, yMittelpunktaufEvol_links);
            Point2D pointEvolventenKopfkreisLinks = catfactory2D1.CreatePoint(xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);
            Point2D pointEvolventenKopfkreisRechts = catfactory2D1.CreatePoint(-xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);

            //Kreise

            Circle2D KreisFrußkreis = catfactory2D1.CreateCircle(x0, y0, Fußkreisradius, 0, Math.PI * 2);
            KreisFrußkreis.CenterPoint = point_Ursprung;
            KreisFrußkreis.StartPoint = pointFußkreisVerrundungLinks;
            KreisFrußkreis.EndPoint = pointAnfangFußkreisLinks;

            Circle2D KreisVerrundungLinks = catfactory2D1.CreateCircle(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            KreisVerrundungLinks.CenterPoint = pointMittelpunktVerrundungLinks;
            KreisVerrundungLinks.EndPoint = pointFußkreisVerrundungLinks;
            KreisVerrundungLinks.StartPoint = pointVerrundungEvolventeLinks;

            Circle2D KreisEvolventenkreisLinks = catfactory2D1.CreateCircle(xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, 0, Math.PI * 2);
            KreisEvolventenkreisLinks.CenterPoint = pointMittelpunktevolventeLinks;
            KreisEvolventenkreisLinks.EndPoint = pointEvolventenKopfkreisLinks;
            KreisEvolventenkreisLinks.StartPoint = pointVerrundungEvolventeLinks;

            Circle2D KreisKopfkreis = catfactory2D1.CreateCircle(x0, y0, Kopfkreisradius, 0, Math.PI * 2);
            KreisKopfkreis.CenterPoint = point_Ursprung;
            KreisKopfkreis.StartPoint = pointEvolventenKopfkreisRechts;
            KreisKopfkreis.EndPoint = pointEvolventenKopfkreisLinks;

            Circle2D KreisEvolventenkreisRechts = catfactory2D1.CreateCircle(-xMittelpunktaufEvol_links, yMittelpunktaufEvol_links, EvolventenkreisRadius, 0, Math.PI * 2);
            KreisEvolventenkreisRechts.CenterPoint = pointMittelpunktevolventeRechts;
            KreisEvolventenkreisRechts.EndPoint = pointVerrundungEvolventeRechts;
            KreisEvolventenkreisRechts.StartPoint = pointEvolventenKopfkreisRechts;

            Circle2D KreisVerrundungRechts = catfactory2D1.CreateCircle(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            KreisVerrundungRechts.CenterPoint = pointMittelpunktVerrundungRechts;
            KreisVerrundungRechts.EndPoint = pointVerrundungEvolventeRechts;
            KreisVerrundungRechts.StartPoint = pointFußkreisVerrundungRechts;



            hsp_catiaProfil.CloseEdition();

            hsp_catiaPart.Part.Update();

            //Profilerstellen Ende


            

            Factory2D factory2D1 = hsp_catiaProfil.Factory2D;

            HybridShapePointCoord ursprung = hybridShapeFactory1.AddNewPointCoord(0, 0, 0);
            Reference refUrsprung = hsp_catiaPart.Part.CreateReferenceFromObject(ursprung);

            HybridShapeDirection xRichtung = hybridShapeFactory1.AddNewDirectionByCoord(1, 0, 0);
            Reference refxRichtung = hsp_catiaPart.Part.CreateReferenceFromObject(xRichtung);

            CircPattern kreismuster = shapeFactory1.AddNewSurfacicCircPattern(factory2D1, 1, 2, 0, 0, 1, 1, refUrsprung, refxRichtung, false, 0, true, false);
            kreismuster.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;
            AngularRepartition angularRepartition1 = kreismuster.AngularRepartition;
            Angle angle1 = angularRepartition1.AngularSpacing;
            angle1.Value = Convert.ToDouble(360 / ZR1.zähnezahl);
            AngularRepartition angularRepartition2 = kreismuster.AngularRepartition;
            IntParam intParam1 = angularRepartition2.InstancesCount;
            intParam1.Value = Convert.ToInt32(ZR1.zähnezahl) + 1;


            //Kreismusterenden verbinden

            Reference refKreismuster = hsp_catiaPart.Part.CreateReferenceFromObject(kreismuster);
            HybridShapeAssemble verbindung = hybridShapeFactory1.AddNewJoin(refKreismuster, refKreismuster);
            Reference refVerbindung = hsp_catiaPart.Part.CreateReferenceFromObject(verbindung);

            hybridShapeFactory1.GSMVisibility(refVerbindung, 0);

            hsp_catiaPart.Part.MainBody.InsertHybridShape(verbindung);



            hsp_catiaPart.Part.Update();

            ErzeugeDieNeueZahnradTasche(ZR1, refVerbindung, shapeFactory1);



        }

        public void Screenshot(string bildname)
        {

            object[] arr1 = new object[3];
            hsp_catiaApp.ActiveWindow.ActiveViewer.GetBackgroundColor(arr1);
            Console.WriteLine("Col: " + arr1[0] + " " + arr1[1] + " " + arr1[2]);

            object[] arr2 = new object[] { 1, 1, 1 };
            hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(arr2);

            hsp_catiaApp.StartCommand("CompassDisplayOff");
            hsp_catiaApp.ActiveWindow.ActiveViewer.Reframe();

            // hsp_catiaApp.ActiveWindow.ActiveViewer.Viewpoint3D = INFITF.Viewpoint3D;
            //int[] color = new int[3]; // Hintergundfarbe in Weiß setzen
            //color[0] = 1;
            //color[1] = 1;
            //color[2] = 1;
            // CATSafeArray color[] = new CATSafeArrayVariant[3];

            INFITF.SettingControllers settingControllers1 = hsp_catiaApp.SettingControllers;
            //INFITF.VisualizationSettingAtt visualizationSettingAtt1 = settingControllers1.Item("CATVizVisualizationSettingCtrl");

            // hsp_catiaApp.ActiveWindow.ActiveViewer.PutBackgroundColor(color);

            hsp_catiaApp.ActiveWindow.ActiveViewer.CaptureToFile(CatCaptureFormat.catCaptureFormatBMP, "C:\\Temp\\" + bildname + ".bmp");
        }

    }
}
