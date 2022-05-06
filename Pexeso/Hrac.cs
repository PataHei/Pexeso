using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    /// <summary>
    /// uchovava informaci o hraci jako: Jmeno, Skore, PocetTahu provedenych ve hre. Vsechny parametry jsou Public, aby je mohla serializovat fce z tridy PraceSxml.
    /// </summary>
    public class Hrac
    {
        public string Prezdivka; 
        public int IdHrac;

        //public int IdHra;
        public int Skore;
        public int PocetTahu;

        /// <summary>
        /// Konstruktor automatickeho hrace se sprezdivkou hrac, 0 body a 0 tahy
        /// </summary>
        public Hrac()
        {   
            this.Prezdivka = "hrac";
            //this.prezdivkaMaxPocetZnaku = 25;
            this.Skore = 0;
            this.PocetTahu = 0;
        }

        /// <summary>
        /// Konstruktor Hrac s volitelnym nastavenim vsech parametru
        /// </summary>
        /// <param name="prezdivka">string - maximalne 25 znaku</param>
        /// <param name="skore">int - Volitelny parametr, vychozi hodnota je 0</param>
        /// <param name="pocetTahu">int - Volitelny parametr, vychozi hodnota je 0</param>
        public Hrac(string prezdivka, int skore = 0, int pocetTahu = 0) 
        {
            this.Prezdivka = prezdivka;
            //this.prezdivkaMaxPocetZnaku = 25;
            this.Skore = skore;
            this.PocetTahu = pocetTahu;
        }
        

    }
}
