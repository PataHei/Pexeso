using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pexeso
{
    /// <summary>
    /// Parcialni trida se stara o hraci pole v OknePexeso
    /// TODO: pozicovani labelu skore a pokusy
    /// </summary>
    public partial class OknoPexeso : Form
    {
        /// <summary>
        /// Pole s obrázky pro karticky pexesa.
        /// </summary>
        readonly Bitmap[] obrazky = new Bitmap[]
        {
            Properties.Resources._001_axe,
            Properties.Resources._002_carriage,
            Properties.Resources._003_castle,
            Properties.Resources._004_catapult,
            Properties.Resources._005_crest,
            Properties.Resources._006_crossbow,
            Properties.Resources._007_crown,
            Properties.Resources._008_knight,
            Properties.Resources._009_dragon,
            Properties.Resources._010_excalibur,
            Properties.Resources._011_fortress,
            Properties.Resources._012_gargoyle,
            Properties.Resources._013_guardian,
            Properties.Resources._014_guillotine,
            Properties.Resources._015_heraldic,
            Properties.Resources._016_holy_grail,
            Properties.Resources._017_horse,
            Properties.Resources._018_jester,
            Properties.Resources._019_king,
            Properties.Resources._020_mace,
            Properties.Resources._021_magic,
            Properties.Resources._022_priest,
            Properties.Resources._023_queen,
            Properties.Resources._024_scroll,
            Properties.Resources._025_shield,
            Properties.Resources._026_spear,
            Properties.Resources._027_throne,
            Properties.Resources._028_trumpet,
            Properties.Resources._029_wizard,
            Properties.Resources._030_wooden_mug
        };

        PictureBox odkrytaPrvniKarticka; //Aktualne odkryte karticky, ktere se nasledne vyhodnoti jejich stejnost
        PictureBox[] Karticky;
        
        //cesta, kde se ukladaji zalohy hry
        public string UlozisteZaloh;
        
        //vytvori instanci hry pexeso s rozlozenim 16 karet pro jednoho hrace
        //jine nastaveni hry se nastavuje v dialogu nova hra 
        public LogikaHry pexeso = new LogikaHry();

        public OknoPexeso()
        {
            InitializeComponent();
            InitializujHru();
            
        }

        /// <summary>
        /// Resi nastaveni hodnot do konstruktoru OknoPexeso. Krome konstruktoru vola i metoda novaHraToolStripMenuItem_Click().
        /// </summary>
        private void InitializujHru()
        {
            //polozky pole s velikosti hry ve striptu Nova hra
            NactiPoloveneVelikostiHryDoPodmenuNovaHra(pexeso);
            //parametry souvisejici s prubehem hry
            //AktualniPocetOdkrytychKarticek = 0;
            odkrytaPrvniKarticka = null; //pamatuje si odkryte karticky PictureBoxy
            //vytvoreni herni plochy
            Karticky = new PictureBox[pexeso.PocetKarticekVeHre]; //pamatuje si vsechny karticky PictureBoxy ve hre
            //VyrazeneKarticky = new object[pexeso.PocetKarticekVeHre];//uklada index k obrazku v poli obrazky[], ktery byl puvodne v Picture.Tag. Informace se ulozi pod stejny index jako ma karticka v poli Karticky.
            RozdejKarty();
            labelKonecHry.Visible = false;
            //nastaveni sirky menuStrip1 podle sirky okna
            this.menuStrip1.MinimumSize = new Size(this.Size.Width, 28); //prapodivne chovani, kdy je potreba sirku striptu nastavovat pres MinimumSize aby se pak podle neho aktualizovalo Size
            // zobrazeni hernich vysledku a dalsi info v picture boxu
            ZobrazSkoreVLabelu();
            ZobrazPocetPokusuVLabelu();
            //priradi jmeno hrace do labelJmenoHrace
            ZobrazJmenoHraceVLabelu();
            //prace s xml soubory - ukladani hry
            UlozisteZaloh = Application.StartupPath + "\\zalohy\\"; //pouziva se i dale na nastavweni ukladani her
            openFileDialogOtevriHru.InitialDirectory = UlozisteZaloh; // nastavi vychozi adresar se zalohama do dialugu otevri soubor
            //prace s sql
            //prida do databaze informace o hre, hracich a idHry a idHracu do jejich instanci
            PridejDataDoDataBaze();

            OknoKonecHry konce = new OknoKonecHry(pexeso);
            konce.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        /// <summary>
        /// Metoda vytvori pictureBox predstavujici herni karticku.
        /// </summary>
        /// <param name="name">string s nazvem pictureBoxu</param>
        /// <param name="location">Point se souradnicemi pozice karticky v okne</param>
        /// <param name="size">Size s velikosti karticky/pictureBoxu</param>
        /// <param name="tag">string obsahujici dalsi info o karticce, primarne urcene k ulozeni identifikatoru prirazeneho obrazku</param>
        /// <returns>PictureBox predstavujici herni karticku</returns>
        private PictureBox VytvorKarticku(string name, Point location, Size size, string tag)
        {
            PictureBox pictureBox = new PictureBox()
            {
                #region
                AccessibleName = null,
                BackColor = System.Drawing.Color.White,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.None,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Enabled = true,
                Image = null,
                InitialImage = null,
                Location = location, 
                Margin = new System.Windows.Forms.Padding(3, 2, 3, 2),
                Name = name,
                Padding = new System.Windows.Forms.Padding(2),
                Size = size, //new System.Drawing.Size(80, 80),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                TabIndex = 49,
                TabStop = false,
                Tag = tag,
                Visible = true,
                WaitOnLoad = true,
                #endregion
            };
            Controls.Add(pictureBox);
            pictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            return pictureBox;
        }

        /// <summary>
        /// Do pole Karticky prida pictureBoxy predstavujici v okne hry karticky.
        /// </summary>
        private void RozdejKarty()
        {

            int maxPocetSloupcu = pexeso.VyberVhodneRozlozeniPocetSloupcu();
            Size velikostKarticky = new Size(80, 80);
            Point pocatecniPolohaHracihoPole = new Point(50, 120);

            for (int i = 0; i < Karticky.Length; i++)
            {   
                Point poziceKarticky = VypoctiPoziciKartickyVOkne(velikostKarticky, pocatecniPolohaHracihoPole, UrciIndexSlouce(i, maxPocetSloupcu), UrciIndexRadku(i, maxPocetSloupcu), 10);

                // naplni se pole Karticky 
                Karticky[i] = VytvorKarticku($"pictureBox{i}", poziceKarticky, velikostKarticky, pexeso.PoleIndexuObrazkuNaKartickach[i].ToString());
            }

        }

        //POMOCNE FUNKCE PRO TRORBU HRACI PLOCHY -- mozna dat do nove tridy hraciPlocha
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="velikostKarticky"></param>
        /// <param name="pocatecniPolohaHracihoPole"></param>
        /// <param name="indexSloupce"></param>
        /// <param name="indexRadku"></param>
        /// <param name="mezeryMeziKartickama"></param>
        /// <returns></returns>
        private Point VypoctiPoziciKartickyVOkne( Size velikostKarticky, Point pocatecniPolohaHracihoPole, int indexSloupce, int indexRadku, int mezeryMeziKartickama)
        {
            return new Point(pocatecniPolohaHracihoPole.X + indexSloupce * (velikostKarticky.Width+mezeryMeziKartickama), pocatecniPolohaHracihoPole.Y + indexRadku * (velikostKarticky.Height + mezeryMeziKartickama));
        }
        /// <summary>
        /// Spocita na, kterem radku buee karticka zobrazena
        /// </summary>
        /// <param name="indexKarticky"></param>
        /// <param name="maxPocetSloupcu"></param>
        /// <returns></returns>
        private int UrciIndexRadku(int indexKarticky, int maxPocetSloupcu)
        {
            return indexKarticky / maxPocetSloupcu;
        }
        /// <summary>
        /// Spocita ve kterem sloupci bude karticka zobrazena
        /// </summary>
        /// <param name="indexKarticky"></param>
        /// <param name="maxPocetSloupcu"></param>
        /// <returns></returns>
        private int UrciIndexSlouce(int indexKarticky, int maxPocetSloupcu)
        {
            return indexKarticky % maxPocetSloupcu;
        }


        //KARTICKY - chovani behem hry
        /// <summary>
        /// Metoda vyvolana udalosti clic na pictureBox s obrazky Karticek zobrazi obrazek a vyhodnoti provedeny tah.
        /// </summary>
        /// <param name="sender">PictureBox</param>
        /// <param name="e">Click</param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            UkazSkrytyObrazek(pictureBox);
            VyhodnotTah(pictureBox);
        }

        /// <summary>
        /// Metoda hlida kolik je odkrytych karticek, porovnava odkryte dvojice a podle vysledku karticky zakryva nebo deaktivuje
        /// </summary>
        /// <param name="pictureBox"> obrazek karticky </param>
        private void VyhodnotTah(PictureBox pictureBox)
        {
            switch (odkrytaPrvniKarticka)
            {
                case null:
                    //ulozi informaci o tom ktery obrazek je odkryty
                    odkrytaPrvniKarticka = pictureBox;
                    //pri odkryti prvni karticky se pripise provedeny tah
                    AktualizujPocetTahu();
                    break;
                default: //pokud jsou dva obrazky uz odkryte provede kontrolu dvojice                 
                    //na dalsi karticky nelze klikat dokud se dvojice nevyhodnoti a bud nevyradi ze hry nebo spatky nezakryjou
                    ZnepristupniKarticky(Karticky);
                    //vyhodnoceni dvojice
                    bool jeZiskDvojice = pexeso.JsouDveKartickyStejne(odkrytaPrvniKarticka.Tag.ToString(), pictureBox.Tag.ToString());
                    AktualizujSkoreVOkne(jeZiskDvojice);
                    AktualizujZobrazeniKarticekPodleVysledkuTahu(pictureBox, jeZiskDvojice);
                    ZakonciHruPokudNastalKonec();
                    break;
            }

        }
        /// <summary>
        /// Informuje hrace pokud nastal konec hry. Vysledek hry ulozi do databaze.
        /// </summary>
        private void ZakonciHruPokudNastalKonec()
        {
            if (pexeso.JeKonecHry())
            {
                labelKonecHry.Visible = true;
                PraceSDatabazi ulozHruDoDatabaze = new PraceSDatabazi();
                for (int i = 0; i < pexeso.seznamHracu.Length ; i++)
                {
                    if (pexeso.seznamHracu[i] != null)
                    {
                        // hodnotama ve tvaru: IdHry, IdHrac, Skore, PocetTahu
                        ulozHruDoDatabaze.PridejVysledekHry(pexeso.IdHry, pexeso.seznamHracu[i].IdHrac, pexeso.seznamHracu[i].Skore, pexeso.seznamHracu[i].PocetTahu);
                    }
                    
                }
                
            }
        }

        /// <summary>
        /// Aktualizuje vzhled PictureBoxu s kartickama podle vysledku tahu hrace
        /// </summary>
        /// <param name="pictureBox">odkryta druha karticka PictureBox</param>
        /// <param name="jeZiskDvojice">bool true podku hrac odkryl dve stejne karticky</param>
        private void AktualizujZobrazeniKarticekPodleVysledkuTahu(PictureBox pictureBox, bool jeZiskDvojice)
        {
            if (jeZiskDvojice)
            {
                //vyradi se karticky nalezene dvojice ze hry
                OdstranKartickuZeHry(odkrytaPrvniKarticka);
                OdstranKartickuZeHry(pictureBox);
                //zbyle karticky ve hre se odemknou pro klikani
                ZmenDostupnostKarticek(Karticky);
            }
            else
            {
                //pokud karticky nejsou stejne, tak se spusti timer. Po dobu jednoho tiku se odkryte obrazky zobrazuji, po case se zpatky sami zakryjou.
                Stopky.Start();
            }
            odkrytaPrvniKarticka = null;
        }


        //TIMER na skryti karticek a prepnuti hrace
        /// <summary>
        /// Meri cas po ktery je odkryta dvojice karticek. Po jednom tiknuti karticky se zakryji (SkryjAktivniKarticky()), aktivni karticky ve hre se odemknou (ZmenDostupnostKarticek()) a timer se zastavi. Dojde k posunu hry na dalsiho hrace.
        /// </summary>
        /// <param name="sender">pictureBox</param>
        /// <param name="e">Pokud dve odkryte karticky nejsou stejne</param>
        private void Stopky_Tick(object sender, EventArgs e)
        {
            Stopky.Stop();
            SkryjAktivniKarticky();
            ZmenDostupnostKarticek(Karticky);
            NactiDalsihoHrace();

        }


        /// <summary>
        /// Smaze hodnotu parametru Tag pictureBoxu dane karticky a tim ji znepristupni
        /// </summary>
        /// <param name="pictureBox"></param>
        private void OdstranKartickuZeHry(PictureBox pictureBox)
        {
            pictureBox.Tag = null;
           
        }

        /// <summary>
        /// Zobrazi obrazek karticky prirazenim obrazku ze seznamu Obrazky do pictureBoxu.Image podle nastavene hodnty v .Tag (ocekava int odpovidajici indexu obrazku v seznamu Obrazky) a pictureBox nastavi Enabled = false.
        /// </summary>
        /// <param name="odkryvanyObrazek">PictureBox odkryte karticky</param>
        void UkazSkrytyObrazek(PictureBox odkryvanyObrazek)
        {
            if (odkryvanyObrazek.Tag != null) 
            {
                odkryvanyObrazek.Image = obrazky[int.Parse(odkryvanyObrazek.Tag.ToString())]; //precte obsah .Tag a zobrazi obrazek
                odkryvanyObrazek.Enabled = false; //uzavre obrazek pred dalsim kliknutim
            }
        }
        

        //METODY NASTAVUJICI VLASTNOSTI KARTICEK - PICTUREBOX
        /// <summary>
        /// Karticky, ktere byli Enabled true budou false a naopak
        /// </summary>
        /// <param name="poleKarticek">pole inst. PictureBox</param>
        private void ZmenDostupnostKarticek(PictureBox[] poleKarticek)
        {
            for (int i = 0; i < poleKarticek.Length; i++)
            {
                if (poleKarticek[i].Tag != null)
                {
                    poleKarticek[i].Enabled = !poleKarticek[i].Enabled;
                } 

            }
        }

        /// <summary>
        /// Nastavi na vsech PictureBoxech Enabled = false
        /// </summary>
        /// <param name="poleKarticek">pole inst. PictureBox</param>
        private void ZnepristupniKarticky(PictureBox[] poleKarticek)
        {
            for (int i = 0; i < poleKarticek.Length; i++)
            {
                if (poleKarticek[i].Tag != null)
                {
                    poleKarticek[i].Enabled = false;
                }
            }
        }
        /// <summary>
        /// Katicky, ktere jsou stale ve hre se po zavolani metody skryjou nastavenim parametru Image = null;
        /// </summary>
        private void SkryjAktivniKarticky()
        {
            for (int i = 0; i < Karticky.Length; i++)
            {
                if (Karticky[i].Tag != null)
                {
                    Karticky[i].Image = null;
                }
            }
        }

        //INFORMACE ZOBRAZENE POMOCI LABEL
        /// <summary>
        /// V Label hodnotaPocetPokusu nastavi Text na aktualni hodnotu skore. V okne se zobrazi skore
        /// </summary>
        private void ZobrazPocetPokusuVLabelu()
        {
            labelHodnotaPocetPokusu.Text = pexeso.seznamHracu[pexeso.AktualniHracNarade].PocetTahu.ToString();
        }

        /// <summary>
        /// Zobrazi aktualni hodnotu skore v okne. Hodnotu labelScore.Text aktualizuje.
        /// </summary>
        private void ZobrazSkoreVLabelu()
        {
            labelScoreValue.Text = pexeso.seznamHracu[pexeso.AktualniHracNarade].Skore.ToString();
        }
        /// <summary>
        /// Zmeni text v labelJmenoHrace podle parametru Prezdivka v poli seznamHracu vybraneho podle indexu AktualniHracNarade 
        /// </summary>
        private void ZobrazJmenoHraceVLabelu()
        {
            labelJmenoHrace.Text = pexeso.seznamHracu[pexeso.AktualniHracNarade].Prezdivka;
        }

        /// <summary>
        /// Zmeni Hrace na rade a aktualizuje label labelJmenoHrace, labelScoreValue a labelHodnotaPocetPokusu .
        /// </summary>
        private void NactiDalsihoHrace()
        {
            pexeso.ZmenHraceNaRade();
            //aktualizace info labelu
            ZobrazJmenoHraceVLabelu();
            ZobrazSkoreVLabelu();
            ZobrazPocetPokusuVLabelu();
        }

        /// <summary>
        /// Pripise skore do instance hrace a aktualizuje labelScoreValue
        /// </summary>
        /// <param name="jeZiskDvojici">bool true pokud hrac nasel dvojici</param>
        private void AktualizujSkoreVOkne(bool jeZiskDvojici)
        {
            pexeso.AktualizujSkore(druhHry: LogikaHry.DruhHry.KlasickaHra, pricti: jeZiskDvojici);
            ZobrazSkoreVLabelu();
        }

        /// <summary>
        /// Pripise pocet tahu do instance hrac a aktualizuje labelHodnotaPocetPokusu
        /// </summary>
        private void AktualizujPocetTahu()
        {
            pexeso.PrictiPokus();
            ZobrazPocetPokusuVLabelu();
        }

    }
}
