using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography;


namespace Pexeso
{
    public partial class Form1 : Form
    {
      
        Bitmap[] obrazky = new Bitmap[]
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

        Bitmap[] dilekPexesa = new Bitmap[30]; // toto vytvoří pole s 30 položkami - resp. 2 x 15.

        int[] poleRNDCiselDvojte = new int[30]; //NAhodne indexy

        PictureBox[] vsechnyKarticky = new PictureBox[30];

        string cisloKarticky;

        public Form1() // toto je okno kde jsou pexesa
        {
            InitializeComponent();
            
            //tady má ješte připsanou inicializaci jako by klikl na nová hra.           
        }

        private void tlNovaHra_Click(object sender, EventArgs e) //toto se stane po kliknutí na tlačítko nová hra.
        {
            //všechny viditelné obrazky jsou nastaveny na null + pole dilekPexesa se vysype na null.
            #region
            obrazekPexesa1.Image = null;
            obrazekPexesa2.Image = null;
            obrazekPexesa3.Image = null;
            obrazekPexesa4.Image = null;
            obrazekPexesa5.Image = null;
            obrazekPexesa6.Image = null;
            obrazekPexesa7.Image = null;
            obrazekPexesa8.Image = null;
            obrazekPexesa9.Image = null;
            obrazekPexesa10.Image = null;
            obrazekPexesa11.Image = null;
            obrazekPexesa12.Image = null;
            obrazekPexesa13.Image = null;
            obrazekPexesa14.Image = null;
            obrazekPexesa15.Image = null;
            obrazekPexesa16.Image = null;
            obrazekPexesa17.Image = null;
            obrazekPexesa18.Image = null;
            obrazekPexesa19.Image = null;
            obrazekPexesa20.Image = null;
            obrazekPexesa21.Image = null;
            obrazekPexesa22.Image = null;
            obrazekPexesa23.Image = null;
            obrazekPexesa24.Image = null;
            obrazekPexesa25.Image = null;
            obrazekPexesa26.Image = null;
            obrazekPexesa27.Image = null;
            obrazekPexesa28.Image = null;
            obrazekPexesa29.Image = null;
            obrazekPexesa30.Image = null;
            #endregion

            /*
             for (int i = 0; i < 30; i++) //tohle do všech nandá null (mělo by je to skrýt).
             {
                 dilekPexesa[i] = null;
             }
             */


            //vytvoří pole 15 náhodných čísel, každé musí být unikátní --P.H. dat do separatni metody MichejKarticky
            #region
            int[] poleNahodnychCisel = new int[15];
            Random generatorNahodnehoRozlozeni = new Random();

            for (int x = 0; x < 15; x++) //tohle je naplní náhodnými čísly.
            {
                int nahodneCislo = generatorNahodnehoRozlozeni.Next(30);//toto zadává rozsah generovaných čísel (1-30).

                if (poleNahodnychCisel.Contains(nahodneCislo)) //pole již obsahuje na některé předchozí pozici stejné čislo.
                {
                    x--;
                    continue;
                }
                else //uloží vygenerované číslo na pozici v poli.
                {
                    poleNahodnychCisel[x] = nahodneCislo;
                }
            }

            int[] poleNahodnychCiselZdvojeno = poleNahodnychCisel.Concat(poleNahodnychCisel).ToArray(); //zdvojí to pole.

            //int[] combined = front.Concat(back).ToArray(); // toto je z stackoverflow.

            Random rnd = new Random(); // vytvoří nový (další) objekt generátoru náhody.
            int[] poleRNDCiselDvojte = new int[30];

            poleRNDCiselDvojte = poleNahodnychCiselZdvojeno.OrderBy(x => rnd.Next()).ToArray();
            #endregion
            #region

            /*tohle by mělo dát ty náhodné čísla na obrázky do jednotlivých čtverečků.
            
            obrazekPexesa1.Image = obrazky[poleRNDCiselDvojte[0]];
            obrazekPexesa2.Image = obrazky[poleRNDCiselDvojte[1]];
            obrazekPexesa3.Image = obrazky[poleRNDCiselDvojte[2]];
            obrazekPexesa4.Image = obrazky[poleRNDCiselDvojte[3]];
            obrazekPexesa5.Image = obrazky[poleRNDCiselDvojte[4]];
            
            obrazekPexesa6.Image = obrazky[poleRNDCiselDvojte[5]];
            obrazekPexesa7.Image = obrazky[poleRNDCiselDvojte[6]];
            obrazekPexesa8.Image = obrazky[poleRNDCiselDvojte[7]];
            obrazekPexesa9.Image = obrazky[poleRNDCiselDvojte[8]];
            obrazekPexesa10.Image = obrazky[poleRNDCiselDvojte[9]];

            obrazekPexesa11.Image = obrazky[poleRNDCiselDvojte[10]];
            obrazekPexesa12.Image = obrazky[poleRNDCiselDvojte[11]];
            obrazekPexesa13.Image = obrazky[poleRNDCiselDvojte[12]];
            obrazekPexesa14.Image = obrazky[poleRNDCiselDvojte[13]]; 
            obrazekPexesa15.Image = obrazky[poleRNDCiselDvojte[14]];

            obrazekPexesa16.Image = obrazky[poleRNDCiselDvojte[15]];
            obrazekPexesa17.Image = obrazky[poleRNDCiselDvojte[16]];
            obrazekPexesa18.Image = obrazky[poleRNDCiselDvojte[17]];
            obrazekPexesa19.Image = obrazky[poleRNDCiselDvojte[18]];
            obrazekPexesa20.Image = obrazky[poleRNDCiselDvojte[19]];

            obrazekPexesa21.Image = obrazky[poleRNDCiselDvojte[20]];
            obrazekPexesa22.Image = obrazky[poleRNDCiselDvojte[21]];
            obrazekPexesa23.Image = obrazky[poleRNDCiselDvojte[22]];
            obrazekPexesa24.Image = obrazky[poleRNDCiselDvojte[23]];
            obrazekPexesa25.Image = obrazky[poleRNDCiselDvojte[24]];

            obrazekPexesa26.Image = obrazky[poleRNDCiselDvojte[25]];
            obrazekPexesa27.Image = obrazky[poleRNDCiselDvojte[26]];
            obrazekPexesa28.Image = obrazky[poleRNDCiselDvojte[27]];
            obrazekPexesa29.Image = obrazky[poleRNDCiselDvojte[28]];
            obrazekPexesa30.Image = obrazky[poleRNDCiselDvojte[29]];
            */

            #endregion

            //presunout na zacatek tridy - ma to vlastne stejnou fci jako Bitmap[] dilekPexesa
            vsechnyKarticky = new PictureBox[] {obrazekPexesa1, obrazekPexesa2, obrazekPexesa3, obrazekPexesa4, obrazekPexesa5, obrazekPexesa6, obrazekPexesa7, obrazekPexesa8,
            obrazekPexesa9, obrazekPexesa10, obrazekPexesa11, obrazekPexesa12, obrazekPexesa13, obrazekPexesa14, obrazekPexesa15, obrazekPexesa16, obrazekPexesa17, obrazekPexesa18, obrazekPexesa19,
            obrazekPexesa20, obrazekPexesa21, obrazekPexesa22, obrazekPexesa23, obrazekPexesa24, obrazekPexesa25, obrazekPexesa26, obrazekPexesa27, obrazekPexesa28, obrazekPexesa29, obrazekPexesa30};
            
            SkryjKarticky();

        }

        private void SkryjKarticky()
        {
            for (int i = 0; i < vsechnyKarticky.Length; i++)
            {
                vsechnyKarticky[i].Image = null;
                
            }


        }

        private void NaplnHodnotyTag()
        {
            for (int i = 0; i < vsechnyKarticky.Length; i++)
            {
                vsechnyKarticky[i].Tag = poleRNDCiselDvojte[i];
            }
        }

        private void zobrazDilek(PictureBox pictureBox, int cisloDilku)
        {
             
        }


        private void MetodaVolanaZKazdeKarty(object sender, EventArgs e)  //EventArgs je událost.
        {
            int pocetOtocenychKaret = 0;
            PictureBox pictureBox = sender as PictureBox; //vytvoří nový objekt pictureBox typu Picturebox, a sender je kartička na kterou jsi klikl.
            if (pocetOtocenychKaret == 0)
            {
                if (pictureBox.Image == null)
                {
                    cisloKarticky = pictureBox.Tag.ToString(); //Tagi obsahuji cisla 1 az 30, ale indexy jsou 0 az 29
                    int cisloKartickyInt = int.Parse(cisloKarticky);
                    pictureBox.Image = obrazky[cisloKartickyInt];

                    pocetOtocenychKaret++;
                }

                else
                {
                    pictureBox.Image = null;
                }
            }

            else if (pocetOtocenychKaret == 1)
            {
                if (pictureBox.Image == null)
                {
                    //cisloKarticky = pictureBox.Tag.ToString();
                    int cisloKartickyInt = int.Parse(cisloKarticky);
                    pictureBox.Image = obrazky[cisloKartickyInt];

                    pocetOtocenychKaret++;
                }

                else
                {
                    pictureBox.Image = null;
                }
            }

            else if (pocetOtocenychKaret==2)
            {
                if (cisloKarticky == pictureBox.Tag.ToString())
                {
                   // pictureBox.Enabled = false;
                }
            }
            
                     

        }
    }
}       
