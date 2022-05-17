using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using PataClassLibraryExtation;
using System.Xml;
using System.Xml.Serialization;
namespace pexesoTestovaniTridyLogikaHry
{
    class Program
    {
        static void Main(string[] args)
        {
            LogikaHry pexeso = new LogikaHry(8);

            Console.WriteLine(pexeso.VygenerujPoleIndexuKarticek());
            pexeso.PoleIndexuKarticek.TiskniTo();
            Console.WriteLine(pexeso.PoleIndexuKarticek.Sum()); //test
            pexeso.ZamichejKarticky(10);
            pexeso.PoleIndexuKarticek.TiskniTo();
            Console.WriteLine(pexeso.PoleIndexuKarticek.Sum()); //test 
            /*
            Console.WriteLine("pocet karet v radku {0}", pexeso.RozpocitejHraciPlochuZKarticek().ToString()); //test
            LogikaHry pexeso1 = new LogikaHry(16);
            Console.WriteLine("pocet karet v radku {0}", pexeso1.RozpocitejHraciPlochuZKarticek().ToString()); //test
            LogikaHry pexeso2 = new LogikaHry(15);
            Console.WriteLine("pocet karet v radku {0}", pexeso2.RozpocitejHraciPlochuZKarticek().ToString()); //test
            LogikaHry pexeso3 = new LogikaHry(42);
            Console.WriteLine("pocet karet v radku {0}", pexeso3.RozpocitejHraciPlochuZKarticek(5,6).ToString()); //test
            */
            pexeso.VygenerujHerniSestavuKarticek();
            //Serializace parametru inst. LogikaHry do xml
            //pexeso.UlozInstanciDoXML("pexeso");

            //SerializujNastaveniHry(pexeso);
            //Deserializace
            //Deserializuj(pexeso);

            //test univerzality tridy PraceSxml
            //Serializace
            List<string> planets = new List<string> { "Merkur", "Venuse", "Zeme", "Mars", "Jupiter", "Saturn", "Uran", "Neptun" };
            var weigthOfPlanets = new Dictionary<string, double>(8) { { "Merkur", 0.33 }, { "Venuse", 4.87 }, { "Zeme", 5.97 }, { "Mars", 0.642 }, { "Jupiter", 1899 }, { "Saturn", 568 }, { "Uran", 86.8 }, { "Neptun", 102 } }; //weights units are 10^24 kg
            //planets.UlozInstanciDoXML("planety");
            //weigthOfPlanets.UlozInstanciDoXML("HmotnostiPlanet");
            //Deserializace
            ;
            //pexeso = NactiSXmlUlozenouHru(pexeso); //prepise vytvoreny konstuktor parametry s xml souboru

            LogikaHry hra = new LogikaHry();
                hra = NactiSXmlUlozenouHru(hra);
            Console.WriteLine("skore: {0}", hra.Score);
        }

        private static LogikaHry NactiSXmlUlozenouHru(LogikaHry pexeso)
        {
            pexeso  = (LogikaHry)pexeso.Deserializuj("pexeso");
            return pexeso;
        }
    }
}
