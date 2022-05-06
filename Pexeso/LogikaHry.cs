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
        readonly static Dictionary<int, int> rozlozeni = new Dictionary<int, int> { { 8, 4 }, { 10, 5 }, { 12, 4 }, { 16, 4 }, { 18, 6 }, { 20, 5 }, { 24, 6 }, { 30, 6 }, { 36, 6 }, { 56, 8 } };

        /// <summary>
        /// obsahuje seznam ruznych pexeso her lisici se napr. zpusobem pocitani skore
        /// </summary>
        public enum DruhHry
        {
            KlasickaHra = 0,
            ZaporneBodyZaSpatnyTah = 1,
        }

        public int PocetKarticekVeHre;
        public int AktualniPocetKarticekVeHre; //pocita aktualni pocet karticek, ktere nebyli odstraneny ze hry. Na zacatku hry vzdy rovno hodnote parametru PocetKarticekVeHre.
        public int[] PoleIndexuObrazkuNaKartickach; //uchovava indexi odkazujici na nacitane obrazky
        
        //vlastnosti k zalohovani hry prevzatych s tridy s rozhranim pro uzivatele
        public object[] ZalohaVlastnistiKarticekSOknaPexeso;
        //public string[] ZalohaHraci;

        //vytvori instanci hracu
        public int PocetHracu;
        public Hrac[] seznamHracu; //pole instanci hrac, ktery uchovava informaci o presdivce, skore a poctu tahu
        public int AktualniHracNarade;
        //databaze her
        public int IdHry; 


        //KONSTRUKTORY--------------------------------------------------------

        /// <summary>
        /// Hra s vychozim nastavenim: jeden hrac a 16 karet
        /// </summary>
        public LogikaHry()
        {
            PocetKarticekVeHre = 16;
            AktualniPocetKarticekVeHre = PocetKarticekVeHre;
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach();
            ZalohaVlastnistiKarticekSOknaPexeso = new object[PocetKarticekVeHre];
            //ZalohaHraci = new string[PocetKarticekVeHre];

            //sprava hracu
            PocetHracu = 1;
            seznamHracu = new Hrac[] { new Hrac("hrac", 0, 0) };
            AktualniHracNarade = 0;
            //databaze her
            IdHry = 0;

        }

        /// <summary>
        /// Hra s volitelnou velikosti pole a poctu hracu
        /// </summary>
        /// <param name="pocetHracu">int</param>
        /// <param name="seznamHracu">pole instanci Hrac</param>
        /// <param name="pocetKarticekVeHre">int. Musi odpovidat hodnotam ulozenym ve slovniku rozlozeni</param>
        public LogikaHry(int pocetKarticekVeHre, Hrac[] seznamHracu, int pocetHracu )
            :this()
        {
            PocetKarticekVeHre = pocetKarticekVeHre;
            AktualniPocetKarticekVeHre = pocetKarticekVeHre;
            this.seznamHracu = seznamHracu;
            PocetHracu = pocetHracu;
            AktualniHracNarade = 0; //muze se pridat losovani
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach();
            //databaze her
            IdHry = 0;

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
            VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach(); //vola se dvakrat
        }

        //FUNKCE GENERUJICI ROZLOZENI HRY-------------------------------------------------

        /// <summary>
        /// Vytvori pole indentifikatoru karticek, kde se bude vzdy jeden identifikator opakovat dvakrat. Velikost pole zavisi od hodnoty PocetKarticekVeHre
        /// </summary>
        /// <returns>int[] PoleIndexuKarticek</returns>
        void VygenerujPoleNahodnePromichanychIndexuObrazkuNaKartickach()
        {
            int[] pulPole = new int[PocetKarticekVeHre / 2];
            for (int i = 0; i < pulPole.Length; i++)
            {
                pulPole[i] = i;
            }
            PoleIndexuObrazkuNaKartickach = pulPole.Concat(pulPole).ToArray();
            ZamichejKarticky(PocetKarticekVeHre*5);
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
        /// <returns>pole celych cisel</returns>
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
        /// <returns>True pokud identifikatory jsou stejne. Zaroven se ponizi parametr AktualniPocetKarticekVeHre o 2</returns>
        public bool JsouDveKartickyStejne(string indexOdkrytehoObrazku1, string indexOdkrytehoObrazku2)
        {
            if (indexOdkrytehoObrazku1 == indexOdkrytehoObrazku2)
            {
                AktualniPocetKarticekVeHre -= 2; //odebere dvojici z aktualniho poctu karticek
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Pricte danemu hraci na rade (par. AktualniHracNaRade) pocet bodu podle pravidel hry
        /// </summary>
        /// <param name="druhHry">enum se seznamem her s ruznym zpusobem pocitani skore. Bez zadani je vybrana KlasickaHra</param>
        /// <param name="pricti">volitelny bool parametr, ktery je true pokud hrac obdrzi body a false pokud se body maji odecist</param>
        public void AktualizujSkore(DruhHry druhHry = DruhHry.KlasickaHra, bool pricti = true)
        {
            if (pricti) //pricte body za dvojici
            {
                switch (druhHry)
                {
                    case DruhHry.KlasickaHra: 
                        seznamHracu[AktualniHracNarade].Skore++;
                        break;
                    case DruhHry.ZaporneBodyZaSpatnyTah: 
                            seznamHracu[AktualniHracNarade].Skore += 2;
                        break;
                    default:
                        break;
                }
                
            }
            else //odecte body za pokus bez odkryti dvojici
            {
                switch (druhHry)
                {
                    case DruhHry.KlasickaHra: 
                        break;
                    case DruhHry.ZaporneBodyZaSpatnyTah: 
                        seznamHracu[AktualniHracNarade].Skore -= 1;
                        break;
                    default:
                        break;
                }
            }
            
            
        }

        /// <summary>
        /// Pricte danemu hraci pokus.
        /// </summary>
        public void PrictiPokus()
        {
            seznamHracu[AktualniHracNarade].PocetTahu++;
        }

        /// <summary>
        /// Predava tah dalsimu hraci v poli seznamHracu.
        /// </summary>
        public void ZmenHraceNaRade()
        {
            AktualniHracNarade++;
            if (AktualniHracNarade == PocetHracu)
            {
                AktualniHracNarade = 0;
            } 

        }

        /// <summary>
        /// Overi zda nastala podminka pro konec hry (zadne karticky ve hre) a nastavi hodnotu parametru KonecHry na true pokud je podminka splnena.
        /// </summary>
        /// <param name="pocetNeodkrytychKaret">aktualni pocet karticek ve hre</param>
        public bool JeKonecHry()
        {
            if (AktualniPocetKarticekVeHre == 0)
            {
                return true;
            }

            return false;
                
        }
    }
}
