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

        Bitmap[] dilekPexesa = new Bitmap[30]; // toto vytvoří pole s 30 položkami.


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
            
            for (int i = 0; i < 30; i++) //tohle do všech nandá null (mělo by je to skrýt).
            {
                dilekPexesa[i] = null; //Pata - mozna lepsi je pouzit picture.Visible = false
            }
            

            //vytvoří pole 15 náhodných čísel, každé musí být unikátní
            int[] poleNahodnychCisel = new int[15];
            Random generatorNahodnehoRozlozeni = new Random();

            for (int x = 0; x < 15; x++) //tohle je naplní náhodnými čísly.
            {                
                int nahodneCislo = generatorNahodnehoRozlozeni.Next(30);//toto zadává rozsah generovaných čísel (1-30).
                                                                        //0-29 je rozsah indexu obrazku, proto argument je 30

                if (poleNahodnychCisel.Contains(nahodneCislo)) //pole již obsahuje na některé předchozí pozici stejné čislo.
                {
                    x--;
                    //break;
                }
                else //uloží vygenerované číslo na pozici v poli.
                {
                    poleNahodnychCisel[x] = nahodneCislo;  
                }                
            }

            int[] poleNahodnychCiselZdvojeno = poleNahodnychCisel.Concat(poleNahodnychCisel).ToArray();

            /*
            for (int q = 0; q < 15; q++) //tohle do všech nandá null (aby to mohlo generovat další rozdání).
            {
                poleNahodnychCisel[q] = int.MinValue;
            }

            */

            //int[] combined = front.Concat(back).ToArray(); // toto je z stackoverflow.

            Random rnd = new Random(); // vytvoří nový (další) objekt generátoru náhody.

            int[] poleRNDCiselDvojte = poleNahodnychCiselZdvojeno.OrderBy(x => rnd.Next()).ToArray();
            
            #region
            //tohle by mělo dát ty náhodné čísla na obrázky do jednotlivých čtverečků.           
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
            
            #endregion
        }

        public void MetodaVolanaZKazdeKarty(int cislo)
        {

           if (cislo == 1)
            {
                obrazekPexesa1.Image = obrazky[cislo];

            }

            else if (cislo == 2)
            {
                obrazekPexesa2.Image = obrazky[2];
            }
             
            
        }

        #region
        /*toto je na vytvoření vlastního plusu +
         * 
         * 
         * 
         * 
         * 
         */

        #endregion






























        private void obrazekPexesa1_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(1);
        }


        private void obrazekPexesa2_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(2);
        }

        private void obrazekPexesa3_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(3);
        }

        private void obrazekPexesa4_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(4);
        }

        private void obrazekPexesa5_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(5);
        }

        private void obrazekPexesa6_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(6);
        }

        private void obrazekPexesa7_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(7);
        }

        private void obrazekPexesa8_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(8);
        }

        private void obrazekPexesa9_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(9);
        }

        private void obrazekPexesa10_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(10);
        }

        private void obrazekPexesa11_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(11);
        }

        private void obrazekPexesa12_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(12);
        }

        private void obrazekPexesa13_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(13);
        }

        private void obrazekPexesa14_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(14);
        }

        private void obrazekPexesa15_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(15);
        }

        private void obrazekPexesa16_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(16);
        }

        private void obrazekPexesa17_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(17);
        }

        private void obrazekPexesa18_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(18);
        }

        private void obrazekPexesa19_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(19);
        }

        private void obrazekPexesa20_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(20);
        }

        private void obrazekPexesa21_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(21);
        }

        private void obrazekPexesa22_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(22);
        }

        private void obrazekPexesa23_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(23);
        }

        private void obrazekPexesa24_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(24);
        }

        private void obrazekPexesa25_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(25);
        }

        private void obrazekPexesa26_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(26);
        }

        private void obrazekPexesa27_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(27);
        }

        private void obrazekPexesa28_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(28);
        }

        private void obrazekPexesa29_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(29);
        }

        private void obrazekPexesa30_Click(object sender, EventArgs e)
        {
            MetodaVolanaZKazdeKarty(30);
        }
    }
}       
