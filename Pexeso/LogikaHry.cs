using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    public class LogikaHry
    {
        readonly static Dictionary<int, int> rozlozeni = new Dictionary<int, int> { { 8, 4 }, { 10, 5 }, { 12, 4 }, { 16, 4 }, { 18, 6 }, { 20, 5 }, { 24, 6 }, { 30, 6 }, { 36, 6 } }; 

        public int PocetKarticekVeHre;
        public int[] PoleIndexuObrazkuNaKartickach; //uchovava indexi odkazujici na nacitane obrazky
        
        //vlastnosti k zalohovani hry prevzatych s tridy s rozhranim pro uzivatele
        public object[] ZalohaVlastnistiKarticekSOknaPexeso;

        //vytvori instanci hracu
        public int PocetHracu;
        public Hrac[] seznamHracu; //pole instanci hrac, ktery uchovava informaci o presdivce, skore a poctu tahu
        public int AktualniHracNarade;
        //KONSTRUKTORY--------------------------------------------------------

        /// <summary>
        /// Hra s vychozim nastavenim: jeden hrac a 16 karet
        /// </summary>
        public LogikaHry()
        {
            PocetKarticekVeHre = 16;
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach(3 * PocetKarticekVeHre);
            ZalohaVlastnistiKarticekSOknaPexeso = new object[PocetKarticekVeHre];

            //sprava hracu
            PocetHracu = 1;
            seznamHracu = new Hrac[] { new Hrac("hrac", 0, 0) };
            AktualniHracNarade = 0;
        }

        /// <summary>
        /// Hra s volitelnou velikosti pole a poctu hracu
        /// </summary>
        /// <param name="pocetHracu">int</param>
        /// <param name="pocetKarticekVeHre">int. Musi odpovidat hodnotam ulozenym ve slovniku rozlozeni</param>
        public LogikaHry(int pocetKarticekVeHre, Hrac[] seznamHracu, int pocetHracu )
            :this()
        {
            PocetKarticekVeHre = pocetKarticekVeHre;
            this.seznamHracu = seznamHracu;
            PocetHracu = pocetHracu;
            AktualniHracNarade = 0; //muze se pridat losovani
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach(3 * PocetKarticekVeHre);
        }

        /// <summary>
        /// PREDELAT PRO POLE HRAC[]
        /// Hra s volbou poctu hracu a vychozim poctem karticek nebo s jednim hracem a volitelnym poctem kraticek
        /// </summary>
        /// <param name="parametrName">nazev celociselneho parametru tridy LogikaHry: pocetKarticekVeHre, pocetHracu</param>
        /// <param name="intValue">celociselna hodnota</param>
        public LogikaHry(string parametrName, int intValue)
            :this()
        {
            switch (parametrName)
            {
                case "pocetKarticekVeHre": 
                    PocetKarticekVeHre = intValue;
                    break;
                case "pocetHracu":
                    PocetHracu = intValue;
                    break;
            }
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach(3 * PocetKarticekVeHre); //vola se dvakrat
        }

        //FUNKCE GENERUJICI ROZLOZENI HRY-------------------------------------------------

        /// <summary>
        /// Vytvori pole indentifikatoru karticek, kde se bude vzdy jeden identifikator opakovat dvakrat. Velikost pole zavisi od hodnoty PocetKarticekVeHre
        /// </summary>
        /// <returns>int[] PoleIndexuKarticek</returns>
        void VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach(int pocetMichaniKaret)
        {
            int[] pulPole = new int[PocetKarticekVeHre / 2];
            for (int i = 0; i < pulPole.Length; i++)
            {
                pulPole[i] = i;
            }
            PoleIndexuObrazkuNaKartickach = pulPole.Concat(pulPole).ToArray();
            ZamichejKarticky(pocetMichaniKaret);
        }
        /// <summary>
        /// Nahodne promicha hodnoty identifikatoru obrazku v poli PoleIndexuKarticek
        /// </summary>
        /// <param name="pocetIteraciMichani">kolikrat ma dojit k prohozeni dvojic identifikatoru karticek. Cim vyssi cislo, tim vice promichane pole bude.</param>
        void ZamichejKarticky(int pocetIteraciMichani = 50)
        {
            Random random = new Random();

            for (int i = 0; i < pocetIteraciMichani; i++)
            {
                int nahodnyIndex = random.Next(1, PoleIndexuObrazkuNaKartickach.Length - 1);

                PoleIndexuObrazkuNaKartickach[nahodnyIndex] = PoleIndexuObrazkuNaKartickach[0] + PoleIndexuObrazkuNaKartickach[nahodnyIndex];
                PoleIndexuObrazkuNaKartickach[0] = PoleIndexuObrazkuNaKartickach[nahodnyIndex] - PoleIndexuObrazkuNaKartickach[0];
                PoleIndexuObrazkuNaKartickach[nahodnyIndex] = PoleIndexuObrazkuNaKartickach[nahodnyIndex] - PoleIndexuObrazkuNaKartickach[0];
            }

        }
        /// <summary>
        /// Vrati pole povolenych (podporovanych) poctu karticek ve hre.
        /// </summary>
        /// <returns></returns>
        public int[] VratPolePovolenychPoctuKarticekVeHre()
        {
            return rozlozeni.Keys.ToArray();
        }

        //Metody na vytvoreni hraci plochy

        /// <summary>
        /// Vraci pocet karet v radku pro dany pocet karet ve hre.
        /// </summary>
        /// <returns>int - pocet karet v radku</returns>
        public int VyberVhodneRozlozeniPocetSloupcu()
        {
            return rozlozeni[PocetKarticekVeHre];
        }

        //VYHODNOCENI HRY
        /// <summary>
        /// Porovna zda identifikatory dvou obrazku (Tag ci index) jsou stejne.
        /// </summary>
        /// <param name="indexOdkrytehoObrazku1">string jednoznacne identifikujici obrazek, napr. Tag ci index pole prevedeny na string</param>
        /// <param name="indexOdkrytehoObrazku2">string jednoznacne identifikujici obrazek, napr. Tag ci index pole prevedeny na string</param>
        /// <returns>True pokud identifikatory jsou stejne.</returns>
        public bool JsouDveKartickyStejne(string indexOdkrytehoObrazku1, string indexOdkrytehoObrazku2)
        {
            return indexOdkrytehoObrazku1 == indexOdkrytehoObrazku2;
        }

        /// <summary>
        /// Pricte danemu hraci zadany pocet bodu, obvykle 1.
        /// </summary>
        /// <param name="hrac">instance daneho hrace tridy Hrac</param>
        /// <param name="pricteneSkore">Hodnota poctu prictenych bodu. Pokud se pricita jen jeden bod neni treba zadavat</param>
        public void AktualizujSkore(Hrac hrac, int pricteneSkore = 1)
        {
            hrac.PripisSkore(ziskaneSkore: pricteneSkore);
        }

        /// <summary>
        /// Pricte danemu hraci pokus.
        /// </summary>
        /// <param name="hrac">instance daneho hrace tridy Hrac</param>
        public void PrictiPokus(Hrac hrac)
        {
            hrac.PripisPocetTahu();
        }

        /// <summary>
        /// Predava tah dalsimu hraci v poli seznamHracu.
        /// </summary>
        public void ZmenHraceNaRade()
        {
            if (AktualniHracNarade++ == PocetHracu-1)
            {
                AktualniHracNarade = 0;
            } 

        }
    }
}
