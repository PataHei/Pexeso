using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Pole se všemi možnými obrázky pro pexeso.
        /// </summary>
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
        Bitmap[] dilekPexesa = new Bitmap[30]; // 30 karticek

        public Form1()
        {
            InitializeComponent();
            buttonNovaHra_Click(null, null);
        }

        /// <summary>
        /// Zobrazi v pictureBoxu dílek pexesa v aktuální sadě.
        /// </summary>
        /// <param name="pictureBox">Kde se má zobrazit obrázek</param>
        /// <param name="indexDilku">Index dílku v aktuální sadě pro hru.</param>
        private void ZobrazDilek(PictureBox pictureBox, int indexDilku)
        {
            if (pictureBox == null) return;
            if (pictureBox.Image != null) return;
            pictureBox.Image = dilekPexesa[indexDilku];
        }

        PictureBox prvniVybranyDilek = null;
        PictureBox druhyVybranyDilek = null;

        /// <summary>
        /// Zkontroluje, jestli je aktualni dilek do páru (pokud je druhý uložený) nebo uloží první a
        /// vyhodnotí, jestli jsou stejné při třetím kliknutí.
        /// </summary>
        /// <param name="pictureBox">PictureBox, na ktery uzivatel klikl.</param>
        private void ZkontrolujPar(PictureBox pictureBox)
        {
            // pokud byl prvni klik, ulozi se prvni dilek
            if (prvniVybranyDilek == null)
            {
                prvniVybranyDilek = pictureBox;
                return;
            }
            
            // pokud se kliklo podruhe na stejny, nic se nedeje
            if (prvniVybranyDilek == pictureBox)
            {
                return;
            }

            // pokud byl druhy klik na jiny dilek
            if (druhyVybranyDilek == null)
            {
                druhyVybranyDilek = pictureBox;
                return;
            }

            // pokud byl treti klik, vyhodnoti se, jestli jsou obrazky stejne
            // kdyz nejsou, dilky se smazou, pokud jsou, zakaze se dalsi klikani, aby nesly vybrat
            if (prvniVybranyDilek.Image != druhyVybranyDilek.Image)
            {
                prvniVybranyDilek.Image = null;
                druhyVybranyDilek.Image = null;
            }
            else
            {
                prvniVybranyDilek.Enabled = false;
                druhyVybranyDilek.Enabled = false;
            }

            // a protoze tohle je treti klik, ulozi se hned jako prvni vybrany obrazek
            druhyVybranyDilek = null;
            prvniVybranyDilek = pictureBox;
        }
        
        /// <summary>
        /// Smaze otocene obrazky a zamicha karticky
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNovaHra_Click(object sender, EventArgs e)
        {
            ZamichejKarticky();
            SmazObrazkyPexesa();
        }

        /// <summary>
        /// Zamicha karticky v poli, kde je aktualni sada pro hru
        /// </summary>
        private void ZamichejKarticky()
        {
            // pripravi se pary dilku
            for (int i = 0; i < dilekPexesa.Length; i += 2)
            {
                dilekPexesa[i] = obrazky[i];
                dilekPexesa[i + 1] = obrazky[i];
            }

            // zamichame se - nahodne se vyberou dva dilky, ktere se prohodi
            Random generatorNahodnychCisel = new Random();
            for (int i = 0; i < 100; i++)
            {
                int indexPrvni = generatorNahodnychCisel.Next(dilekPexesa.Length);
                int indexDruhy = generatorNahodnychCisel.Next(dilekPexesa.Length);

                Bitmap prohazovanyObrazek = dilekPexesa[indexPrvni];
                dilekPexesa[indexPrvni] = dilekPexesa[indexDruhy];
                dilekPexesa[indexDruhy] = prohazovanyObrazek;
            }
        }

        /// <summary>
        /// Vsem pictureBoxum nastavi misto obrazku null a povoli klikani
        /// </summary>
        private void SmazObrazkyPexesa()
        {
            pictureBox1.Image = null;
            pictureBox1.Enabled = true;
            pictureBox2.Image = null;
            pictureBox2.Enabled = true;
            pictureBox3.Image = null;
            pictureBox3.Enabled = true;
            pictureBox4.Image = null;
            pictureBox4.Enabled = true;
            pictureBox5.Image = null;
            pictureBox5.Enabled = true;
            pictureBox6.Image = null;
            pictureBox6.Enabled = true;
            pictureBox7.Image = null;
            pictureBox7.Enabled = true;
            pictureBox8.Image = null;
            pictureBox8.Enabled = true;
            pictureBox9.Image = null;
            pictureBox9.Enabled = true;
            pictureBox10.Image = null;
            pictureBox10.Enabled = true;
            pictureBox11.Image = null;
            pictureBox11.Enabled = true;
            pictureBox12.Image = null;
            pictureBox12.Enabled = true;
            pictureBox13.Image = null;
            pictureBox13.Enabled = true;
            pictureBox14.Image = null;
            pictureBox14.Enabled = true;
            pictureBox15.Image = null;
            pictureBox15.Enabled = true;
            pictureBox16.Image = null;
            pictureBox16.Enabled = true;
            pictureBox17.Image = null;
            pictureBox17.Enabled = true;
            pictureBox18.Image = null;
            pictureBox18.Enabled = true;
            pictureBox19.Image = null;
            pictureBox19.Enabled = true;
            pictureBox20.Image = null;
            pictureBox20.Enabled = true;
            pictureBox21.Image = null;
            pictureBox21.Enabled = true;
            pictureBox22.Image = null;
            pictureBox22.Enabled = true;
            pictureBox23.Image = null;
            pictureBox23.Enabled = true;
            pictureBox24.Image = null;
            pictureBox24.Enabled = true;
            pictureBox25.Image = null;
            pictureBox25.Enabled = true;
            pictureBox26.Image = null;
            pictureBox26.Enabled = true;
            pictureBox27.Image = null;
            pictureBox27.Enabled = true;
            pictureBox28.Image = null;
            pictureBox28.Enabled = true;
            pictureBox29.Image = null;
            pictureBox29.Enabled = true;
            pictureBox30.Image = null;
            pictureBox30.Enabled = true;
        }

        #region Klikani na PictureBoxy

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox1, 0);
            ZkontrolujPar(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox2, 1);
            ZkontrolujPar(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox3, 2);
            ZkontrolujPar(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox4, 3);
            ZkontrolujPar(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox5, 4);
            ZkontrolujPar(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox6, 5);
            ZkontrolujPar(pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox7, 6);
            ZkontrolujPar(pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox8, 7);
            ZkontrolujPar(pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox9, 8);
            ZkontrolujPar(pictureBox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox10, 9);
            ZkontrolujPar(pictureBox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox11, 10);
            ZkontrolujPar(pictureBox11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox12, 11);
            ZkontrolujPar(pictureBox12);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox13, 12);
            ZkontrolujPar(pictureBox13);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox14, 13);
            ZkontrolujPar(pictureBox14);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox15, 14);
            ZkontrolujPar(pictureBox15);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox16, 15);
            ZkontrolujPar(pictureBox16);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox17, 16);
            ZkontrolujPar(pictureBox17);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox18, 17);
            ZkontrolujPar(pictureBox18);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox19, 18);
            ZkontrolujPar(pictureBox19);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox20, 19);
            ZkontrolujPar(pictureBox20);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox21, 20);
            ZkontrolujPar(pictureBox21);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox22, 21);
            ZkontrolujPar(pictureBox22);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox23, 22);
            ZkontrolujPar(pictureBox23);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox24, 23);
            ZkontrolujPar(pictureBox24);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox25, 24);
            ZkontrolujPar(pictureBox25);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox26, 25);
            ZkontrolujPar(pictureBox26);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox27, 26);
            ZkontrolujPar(pictureBox27);
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox28, 27);
            ZkontrolujPar(pictureBox28);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox29, 28);
            ZkontrolujPar(pictureBox29);
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            ZobrazDilek(pictureBox30, 29);
            ZkontrolujPar(pictureBox30);
        }

        #endregion
    }
}
