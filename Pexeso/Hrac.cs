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
        string prezdivka;
        int skore;
        int pocetTahu;

        public Hrac(string prezdivka, int skore = 0, int pocetTahu = 0) 
        {
            this.prezdivka = prezdivka;
            this.skore = skore;
            this.pocetTahu = pocetTahu;
        }

        //METODY
        /// <summary>
        /// Umozni hraci zmenit prezdivku.
        /// </summary>
        /// <param name="prezdivka"></param>
        public void PrejmenujHrace(string prezdivka)
        { 
            this.prezdivka = prezdivka;
        }

        public string VratJmeno()
        {
            return prezdivka;
        }
        /// <summary>
        /// Pripise nove ziskane skore k celkovemu skore. Obvykle se pricita 1 bod, ale muzou existovat i jine moznosti podle pravidel hry
        /// </summary>
        /// <param name="ziskaneSkore">int skore, ktere je treba hraci pricist k jiz ziskanemu skore</param>
        public void PripisSkore(int ziskaneSkore)
        { 
            this.skore += ziskaneSkore;
        }

        /// <summary>
        /// Pricte jeden tah k celkevemu poctu provedenych tahu
        /// </summary>
        public void PripisPocetTahu()
        {
            this.pocetTahu++;
        }

        public int VratSkore()
        {
            return skore;
        }

        public int VratPocetPokusu()
        {
            return pocetTahu;
        }

    }
}
