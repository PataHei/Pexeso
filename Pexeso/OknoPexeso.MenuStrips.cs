using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class OknoPexeso : Form
    {
        //TOOL STRIPS - menu v zahlavy

        //VOLANI NOVE HRY
        /// <summary>
        /// Po kliknuti obnovy hru s vychozim nastavenim.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NovaHraToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.InitializujHru();
        }

        /// <summary>
        /// Nacte pole poctyKarticekVeHre do Items toolStripComboboxu. Uzivatel bude moc vybirat velikost herniho pole ze seznamu v menu Nova hra
        /// </summary>
        /// <param name="logikaHry"></param>
        void NactiPoloveneVelikostiHryDoPodmenuNovaHra(LogikaHry logikaHry)
        {
            int[] importPoctyKarticekVeHre = logikaHry.VratPolePovolenychPoctuKarticekVeHre();
            object[] poctyKarticekVehre = new object[importPoctyKarticekVeHre.Length];

            for (int i = 0; i < importPoctyKarticekVeHre.Length; i++)
            {
                poctyKarticekVehre[i] = importPoctyKarticekVeHre[i];
            }
            toolStripComboBoxVelikostHernihoPole.Items.AddRange(poctyKarticekVehre);
        }

        /// <summary>
        /// Po zvoleni velikosti hraciho pole (poctu karticek ve hre) vytvori novou hru a aktualizuje okno Pexesa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripComboBoxVelikostHernihoPole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolStripCombo = sender as ToolStripComboBox;
            pexeso = new LogikaHry("pocetKarticekVeHre", (int)toolStripCombo.SelectedItem);
            InicializujNoveOkno();
        }

        private void InicializujNoveOkno()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.InitializujHru();
        }

        //ULOZENI A NACTENI ROZEHRANE HRY
        /// <summary>
        /// Vytvori pole poli s aktualnimi klicovych vlastnostmi PictureBoxu reprezentujicich karticky ve hre.
        /// Pred serializaci do xml je treba rozlozit na jednotlive pole pro kazdy PictureBox
        /// </summary>
        /// <returns></returns>
        private object[] VytvorZalohuKaticek()
        {
            object[] ZalohaVlastnistiKarticek = new object[Karticky.Length];
            //pomocne pole na ukladani vlastnosti pictureBoxu
            var vlastnostiPictureBoxu = new object[4]; // { Name, tag, image, enable }
            for (int i = 0; i < Karticky.Length; i++)
            {
                vlastnostiPictureBoxu[0] = Karticky[i].Name;
                vlastnostiPictureBoxu[1] = Karticky[i].Tag;
                vlastnostiPictureBoxu[2] = Karticky[i].Image;
                vlastnostiPictureBoxu[3] = Karticky[i].Enabled;
                //zapsani pole vlastnostiPictureBoxu do pole ZalohaVlastnistiKarticek
                ZalohaVlastnistiKarticek[i] = vlastnostiPictureBoxu;
            }
            return ZalohaVlastnistiKarticek;
        }

        private void NastavVlastnostiPictureBoxuSeZalohy()
        {
            for (int i = 0; i < Karticky.Length; i++)
            {
                //var vlastnostiPictureBoxu = (object)pexeso.ZalohaVlastnistiKarticek[i]; //{ tag, image, enable }
                //Karticky[i].Tag = vlastnostiPictureBoxu;
                
            }
        }
        /// <summary>
        /// Metoda po kliknuti na polozku Uloz hru v menu, ulozi xml soubor s parametry instance pexeso a nazev souboru do Listu ulozeneZalohyHerNazvySouboru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UložHruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VytvorZalohuKaticek();
            string nazevSouboru = "";
            nazevSouboru = nazevSouboru.VytvorNazev("hra");
            pexeso.ZalohaVlastnistiKarticek = VytvorZalohuKaticek(); //vytvori se v instanci pexeso tridy LogikaHry zaloha nastaveni obrazku v kartickach.
            bool xmlUlozeno;
            pexeso.UlozInstanciDoXML(nazevSouboru, UlozisteZaloh, out xmlUlozeno);
            //povrzeni o provedenem ukladani xml
            if (xmlUlozeno)
            {
                MessageBox.Show("Hra byla uložena.", "Ukládání hry", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ukládání hry se nepovedlo.", "Ukládání hry", MessageBoxButtons.OK);
            }
        }

        private void NačtiHruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogOtevriHru.ShowDialog();
            pexeso = (LogikaHry)pexeso.Deserializuj(openFileDialogOtevriHru.FileName);
            InicializujNoveOkno();
            NastavVlastnostiPictureBoxuSeZalohy();
            
        }

        //HRACI
        //bude umoznovat pridavat, ubyrat hrace, prohlizet herni staticstiky spojene s odehranyma hrama
        //UKONCENI HRY

        /// <summary>
        /// Vypne okno Pexeso. Pred ukoncenim aplikace ulozi seznam zaloh her ulozeneZalohyHerNazvySouboru do souboru XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KonecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //INFORMACE A NAPOVEDY
        /// <summary>
        /// Zobrazi informace o hre pro uzivatele
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 info = new AboutBox1();
            info.Show();
        }

        /// <summary>
        /// Zobrazi informace jak hrat Pexeso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Napoveda napoveda = new Napoveda();
            napoveda.Show();
        }
    }
}
