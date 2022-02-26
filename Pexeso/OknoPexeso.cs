using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class OknoPexeso : Form
    {
        /// <summary>
        /// Pole se všemi možnými obrázky pro pexeso.
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
        Random random = new Random();
        int?[] OdkryteObrazky; //uklada index ulozene v pictureBox.Tag
        int Score; //za odkrytou dvojici prida bod
        int AktualniPocetOdkrytychKarticek; //hodnota 0 az 2
        public bool[] ImagePictureViewed; //hlida stav zobrazeni obrazku
        int?[] RozlozeniHry; //uklada rozlozeni obrazku v poli
        int?[] PouziteObrazky; //uklada indexy nactenych obrazku do hry z pole Obrazky
        PictureBox PredchoziObrazek; //uklada prvni odhaleny obrazek ve dvojici
        private void SetDefaultValues()
        {
            //pole uklada index obrazku z pole Obrazky
            //velikost pole odpovida pocetu karticek ve hre, 
            RozlozeniHry = new int?[8]; 
            //pole uklada index pouzitych obrazku v poradi jak jsou nahodne vylosovany
            PouziteObrazky = new int?[4];
            //uklada se informace zda jsou obrazky nactene. Na zacatku hry nejsou.
            ImagePictureViewed = new bool[8] { false, false, false, false, false, false, false, false };

            //vygeneruje pocatecni rozlozeni obrazku:

            bool jePrazdneMisto = false; //uchovava informaci zda misto v poli RozlozeniHry je uz obsazene
            
            for (int i = 0; i < (RozlozeniHry.Length / 2); i++)
            {
                //vybere nahodne obrazek z pole Obrazky
                int nahodnyObrazek;
                do
                {
                    nahodnyObrazek = random.Next(obrazky.Length - 1);
                }
                while (PouziteObrazky.Contains(nahodnyObrazek)); //overi zda nahodne vybrany obrazek jiz nebyl jednou vybran
                //ulozi vybrany obrazek do seznamu pouzitych obrazku
                PouziteObrazky[i] = nahodnyObrazek;
                //vybere pseudonahodne misto v poli RozlozeniHry. Pokud je misto jiz zaplnene, najde nejblizsi dalsi, tak aby se losovani rozlozeni nezaseklo na hadani posledniho mista
                for (int j = 0; j < 2; j++)
                {
                    int nahodneUmisteni = random.Next(RozlozeniHry.Length);
                    int nahodneUmisteni0 = nahodneUmisteni; //zapamatuje si puvodne vybrane nahodne misto

                    //pokud v poli RozlozeniHry je misto pod vybranym indexem volne obrazek(index) se tam ulozi
                    if (RozlozeniHry[nahodneUmisteni] == null)
                    {
                        RozlozeniHry[nahodneUmisteni] = nahodnyObrazek;
                    }
                    //pokud by dane misto bylo jiz obsazene najde algorimus nejaky nejblizsi misto kolem
                    else
                    {
                        jePrazdneMisto = false;
                        while (nahodneUmisteni < RozlozeniHry.Length-1)
                        {
                            nahodneUmisteni++;
                            if (RozlozeniHry[nahodneUmisteni] == null)
                            {
                                RozlozeniHry[nahodneUmisteni] = nahodnyObrazek;
                                jePrazdneMisto = true; //zabezpeci, aby se nesepl druhy sestupny cyklus, pokud se najde prazdne misto v poli
                                break;
                            }

                        }
                        nahodneUmisteni = nahodneUmisteni0;
                        while (nahodneUmisteni > 0 && !jePrazdneMisto)
                        {
                            nahodneUmisteni--;
                            if (RozlozeniHry[nahodneUmisteni] == null)
                            {
                                RozlozeniHry[nahodneUmisteni] = nahodnyObrazek;
                                break;
                            }

                        }
                    }

                }
            }

            OdkryteObrazky = new int?[2] { null, null };
            Score = 0;
            AktualniPocetOdkrytychKarticek = 0;
            PredchoziObrazek = null;
            // zobrazuje skore
            label_Score.Text = Score.ToString();
        }
        public OknoPexeso()
        {
            InitializeComponent();
            SetDefaultValues();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //KARTICKY
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int i = int.Parse((string)pictureBox.Tag); //index pictureboxu ulozeny v Tag
            //pokud obrazek byl zakryty:
            //odkryt dovoli max. 2 obrazky
            if (ImagePictureViewed[i] == false && AktualniPocetOdkrytychKarticek <2)
            {
                pictureBox.Image = obrazky[(int)RozlozeniHry[i]];
                ImagePictureViewed[i] = true;
                AktualniPocetOdkrytychKarticek++; //zvysi pocet aktualne odkrytych karet
                //uklada indexy vybranych obrazku
                switch (AktualniPocetOdkrytychKarticek)
                {
                    case 1:
                        OdkryteObrazky[0] = RozlozeniHry[i];
                        PredchoziObrazek = pictureBox;
                        pictureBox.Enabled = false;
                        break;
                    case 2:
                        OdkryteObrazky[1] = RozlozeniHry[i]; break;
                        
                }
                //pokud se dvojice vybranych obrazku rovna = vyhodnoceni vyberu
                if (OdkryteObrazky[0] == OdkryteObrazky[1])
                {
                    Score++;
                    label_Score.Text = Score.ToString();
                    pictureBox.Enabled = false;
                    //nalezene dvojice obrazku se deaktivuji 
                    PredchoziObrazek = null;
                    AktualniPocetOdkrytychKarticek = 0;
                }

            }
            //pokud byla odkryta dvojice obrazku
            else if (ImagePictureViewed[i] == true)
            {
                pictureBox.Image = null;
                ImagePictureViewed[i] = false;
                AktualniPocetOdkrytychKarticek--; //snizi aktualni pocet odkrytych karet

                PredchoziObrazek.Image = null;
                ImagePictureViewed[int.Parse((string)PredchoziObrazek.Tag)] = false;
                AktualniPocetOdkrytychKarticek--;
                //pictureBox.Enabled = true;
                PredchoziObrazek.Enabled = true;
                OdkryteObrazky[0] = null; 
                OdkryteObrazky[1] = null; 
            }
            

        }

        private void novaHraToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.SetDefaultValues();
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 info = new AboutBox1();
            info.Show();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Napoveda napoveda = new Napoveda();
            napoveda.Show();
        }
    }
}
