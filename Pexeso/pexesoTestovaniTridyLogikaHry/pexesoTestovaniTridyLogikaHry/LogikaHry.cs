using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pexesoTestovaniTridyLogikaHry
{
    public class LogikaHry
    {
        public int PocetKarticekVeHre;
        public int[] PoleIndexuKarticek; //uchovava indexi odkazujici na nacitane obrazky
        public int Score;

        //Konstruktory

        /// <summary>
        /// Zakladni hra
        /// </summary>
        public LogikaHry()
        {
            PocetKarticekVeHre = 8;
            PoleIndexuKarticek = new int[PocetKarticekVeHre];
            Score = 0;
        }

        /// <summary>
        /// Volitelne velke hraci pole
        /// </summary>
        public LogikaHry(int pocetKarticekVeHre )
        {
            PocetKarticekVeHre = pocetKarticekVeHre;
            PoleIndexuKarticek = new int[PocetKarticekVeHre];
            Score = 0;
        }

        //Metody na vytvoreni hry
        /// <summary>
        /// Najde delitele ze zadaneho rozsahu hodnot, kterym lze pocet karet ve hre podelit beze zbytku. Urci se tak velikost obdelniku, do ktereho karticky budou rozlozeny.
        /// </summary>
        /// <param name="minPocetKaret">minimalni pocet karticek v radku</param>
        /// <param name="maxPocetKaret">maximalni pocet karticek v radku</param>
        /// <returns>pocet karticek v radku</returns>
        public int? VratVhodneRozlozeniPocetSloupcu(int minPocetKaret = 3, int maxPocetKaret = 6)
        { 
            //prvni zkusi zda lze karticky poskladat do ctverce
            int pocetKaretVRadku = (int)Math.Sqrt(PocetKarticekVeHre);

            if ((pocetKaretVRadku^2) == PocetKarticekVeHre) //pokud true, lze karty usporadat do ctverce, coz je optimum
            {
                return pocetKaretVRadku;
            }
            else //pokud ne bude hledat moznost poskladat obdelnik v mezich vstupnich parametru
            {
                for (int delitel = minPocetKaret; delitel <= maxPocetKaret; delitel++)
                {
                    if (PocetKarticekVeHre % delitel == 0)
                    {
                        //vrati delitele, ktery je mensi nebo roven maximalnimu rozmenu na sirku
                        return ((PocetKarticekVeHre / delitel) > maxPocetKaret) ? delitel : PocetKarticekVeHre / delitel;
                    }
                }
            }
            //nelze sestavit obdelnikovou hraci plochu v mezich zadanych rozmeru
            //TODO dopsat exception
            return null;
        }
        /// <summary>
        /// Vytvori pole indentifikatoru karticek, kde se bude vzdy jeden identifikator opakovat dvakrat. Velikost pole zavisi od hodnoty PocetKarticekVeHre
        /// </summary>
        /// <returns>int[] PoleIndexuKarticek</returns>
        public int[] VygenerujPoleIndexuKarticek()
        {
            int[] pulPole = new int[PoleIndexuKarticek.Length / 2];
            for (int i = 0; i < PoleIndexuKarticek.Length/2; i++)
            {
                pulPole[i] = i;
            }
            return PoleIndexuKarticek = pulPole.Concat(pulPole).ToArray();
        }
        /// <summary>
        /// Nahodne promicha hodnoty identifikatoru obrazku v poli PoleIndexuKarticek
        /// </summary>
        /// <param name="pocetIteraciMichani">kolikrat ma dojit k prohozeni dvojic identifikatoru karticek. Cim vyssi cislo, tim vice promichane pole bude.</param>
        public void ZamichejKarticky(int pocetIteraciMichani)
        {
            Random random = new Random();

            for (int i = 0; i < pocetIteraciMichani; i++)
            {
                int nahodnyIndex = random.Next(1,PoleIndexuKarticek.Length - 1);

                //b(a+b) = a + b, 5 = 2 + 3
                PoleIndexuKarticek[nahodnyIndex] = PoleIndexuKarticek[0] + PoleIndexuKarticek[nahodnyIndex];


                //b(a+b) = 5, a = 2
                //a = b(a+b) - a = 5 - 2 = 3
                PoleIndexuKarticek[0] = PoleIndexuKarticek[nahodnyIndex] - PoleIndexuKarticek[0];


                //a = 3, b(a+b) = 5;
                //b = b(a+b) - a = 5 - 3 = 2
                PoleIndexuKarticek[nahodnyIndex] = PoleIndexuKarticek[nahodnyIndex] - PoleIndexuKarticek[0];

            }

        }

        private void TiskniMezivysledek(int nahodnyIndex)
        {
            Console.WriteLine("b = {0}, a a = {1}", PoleIndexuKarticek[nahodnyIndex], PoleIndexuKarticek[0]);
        }

        //Metody vyhodnocujici prubeh hry
        /// <summary>
        /// Porovna zda identifikatory dvou obrazku (Tag ci index) jsou stejne.
        /// </summary>
        /// <param name="indexOdkrytehoObrazku1">int identifikujici obrazek, napr. Tag ci index pole</param>
        /// <param name="indexOdkrytehoObrazku2">int identifikujici obrazek, napr. Tag ci index pole</param>
        /// <returns>True pokud identifikatory jsou stejne.</returns>
        public bool PorovnejDvojiciKarticek(int indexOdkrytehoObrazku1, int indexOdkrytehoObrazku2)
        {
            return indexOdkrytehoObrazku1 == indexOdkrytehoObrazku2;
        }
        /// <summary>
        /// Pricte pocet bodu, pokud je splnena podminka pro naviseni bodu.
        /// </summary>
        /// <param name="indexOdkrytehoObrazku1">int identifikujici obrazek, napr. Tag ci index pole</param>
        /// <param name="indexOdkrytehoObrazku2">int identifikujici obrazek, napr. Tag ci index pole</param>
        /// <returns>Hodnoty Score (int) </returns>
        public int AktualizujSkore( int indexOdkrytehoObrazku1, int indexOdkrytehoObrazku2)
        {
            return PorovnejDvojiciKarticek(indexOdkrytehoObrazku1, indexOdkrytehoObrazku2) ? Score++ : Score;
        }

        public void VygenerujHerniSestavuKarticek()
        {
            int pocetKaretVradku = 4;
            int pocetRadku = 4;
            //Karticky = new PictureBox[hra.PocetKarticekVeHre];

            int kartaIndex; //vygenerovany index prirazujici karticku s pole skladKarticek
            int i = 0; //index prochazejici pole Karticky

            for (int radek = 1; radek <= pocetRadku; radek++)
            {
                kartaIndex = radek * 10;
                for (int sloupec = 1; sloupec <= pocetKaretVradku; sloupec++)
                {
                    //Karticky[i] = skladKarticek[kartaIndex + sloupec];
                    Console.WriteLine(kartaIndex + sloupec);
                    i++;
                }
            }
        }
    }
}
