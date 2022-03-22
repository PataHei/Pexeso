using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    /// <summary>
    /// uchovava informaci o hraci jako: Jmeno, Skore, PocetTahu provedenych ve hre.
    /// </summary>
    public class Hrac
    {
        public string Presdivka;
        public int Skore;
        public int PocetTahu;

        public Hrac(string presdivka, int skore = 0, int pocetTahu = 0) 
        {
            Presdivka = presdivka;
            Skore = skore;
            PocetTahu = pocetTahu;
        }

        public void PrejmenujHrace(string prezdivka)
        { 
            Presdivka = prezdivka;
        }

        public void ZapisSkore(int skore)
        { 
            Skore = skore;
        }
        public void ZapisPocetTahu(int pocetTahu)
        {
            PocetTahu = pocetTahu;
        }
    }
}
