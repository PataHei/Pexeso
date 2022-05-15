using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    /// <summary>
    /// Parcialni trida se stara o menu polozky v zahlavi okna OknoPexesa.
    /// </summary>
    public partial class OknoPexeso : Form
    { 
        //TOOL STRIPS - menu v zahlavy

        //VOLANI NOVE HRY
        /// <summary>
        /// Po kliknuti na stript Nova hra se vytvori instance tridy OknoNovaHra, coz je modalni dialogove okno Nova hra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NovaHraToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            NovaHra();

        }

        private void NovaHra()
        {
            //Otevre se dialog Nova hra
            OknoNovaHra oknoNovaHra = new OknoNovaHra(NactiPoloveneVelikostiHryDoPodmenuNovaHra(pexeso), 4);
            oknoNovaHra.ShowDialog(); //ShowDialog otevre modalni okno, ktere se musi zavrit cancelem nebo ok, Show() okno otevre jako druhe oknu a lze volne prechazet k rozehrane hre a to zde nechceme.
            if (oknoNovaHra.DialogResult == DialogResult.OK)
            {
                //pokud je dialog Nova hra uzavren potvrzenim OK, pak se prenastavi parametry inst. pexeso a reinicializuje se OknoPexeso

                pexeso = new LogikaHry(oknoNovaHra.PocetKarticekVeHre, oknoNovaHra.zadaniHraciVeHre, oknoNovaHra.pocetHracu);
                MessageBox.Show($"Pocet hracu bude {pexeso.PocetHracu} a karet ve hre bude {pexeso.PocetKarticekVeHre}.");
                InicializujNoveOkno();

            }
        }

        /// <summary>
        /// metoda zajisti predani informaci o hre a hracich do SQL databaze pomoci instance objektu tridy PraceSDatabazi
        /// </summary>
        private void PridejDataDoDataBaze()
        {
            //zaroven se zapisou informace o hre a hracich do databaze
            PraceSDatabazi dataHry = new PraceSDatabazi();

            //prida prezdivky hracu do databaze, pokud nejsou jiz v databazi. 
            //nastavi IdHrace s databaze do instanci Hrace
            foreach (var item in pexeso.seznamHracu)
            {
                if (item != null)
                {
                    dataHry.PridejHraceDoTabulkyHraci(item.Prezdivka);
                    item.IdHrac = dataHry.ZjistiZdatabazeIdHrace(item.Prezdivka);
                }
            }

            //prida hru do databaze
            dataHry.PridejHruDoTabulkyHry(pexeso.PocetHracu, pexeso.PocetKarticekVeHre);

            //nastavi IdHry s databaze do instance LogikaHry
            pexeso.IdHry = dataHry.ZjistiZdatabazeIdHry();
 
        }

        /// <summary>
        /// Nacte pole poctyKarticekVeHre do Items toolStripComboboxu. Uzivatel bude moc vybirat velikost herniho pole ze seznamu v menu Nova hra
        /// </summary>
        /// <param name="logikaHry">instance tridy LogikaHry</param>
        object[] NactiPoloveneVelikostiHryDoPodmenuNovaHra(LogikaHry logikaHry)
        {
            int[] importPoctyKarticekVeHre = logikaHry.VratPolePovolenychPoctuKarticekVeHre();
            //int[] je treba prevest na object[]
            object[] poctyKarticekVehre = new object[importPoctyKarticekVeHre.Length];

            for (int i = 0; i < importPoctyKarticekVeHre.Length; i++)
            {
                poctyKarticekVehre[i] = importPoctyKarticekVeHre[i];
            }
            //toolStripComboBoxVelikostHernihoPole.Items.AddRange(poctyKarticekVehre);
            return poctyKarticekVehre;
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

            for (int i = 0; i < Karticky.Length; i++)
            {
                var vlastnostiPictureBoxu = new object[4]; // { Name, tag, <tag>image, enable }
                vlastnostiPictureBoxu[0] = Karticky[i].Name;
                vlastnostiPictureBoxu[1] = Karticky[i].Tag;
 
                vlastnostiPictureBoxu[3] = Karticky[i].Enabled;
                //zapsani pole vlastnostiPictureBoxu do pole ZalohaVlastnistiKarticek
                ZalohaVlastnistiKarticek[i] = vlastnostiPictureBoxu;
            }
            return ZalohaVlastnistiKarticek;
        }

        private string[] VytvorZalohuHracu(Hrac[] hraci)
        {
            string[] zalohaHraci = new string[hraci.Length];
            for (int i = 0; i < hraci.Length; i++)
            {
                zalohaHraci[i] = hraci[i].UlozInstanciDoXMLretezce();
            }
            return zalohaHraci;
        }

        /// <summary>
        /// Metoda vyvolana kliknutim na stripMenu Nacti hru, ktera nacte xml soubor a zavola metody na nacteni parametru do instance pexeso tridy LogikaHry
        /// </summary>
        /// <param name="sender">StripMenu Nacti hru</param>
        /// <param name="e">Click</param>
        private void NačtiHruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogOtevriHru.ShowDialog();
            //musi se provest az po zadani OK:
            //pexeso = (LogikaHry)pexeso.Deserializuj(openFileDialogOtevriHru.FileName);
            //InicializujNoveOkno();
            //NastavVlastnostiPictureBoxuSeZalohy(pexeso.ZalohaVlastnistiKarticekSOknaPexeso); 

        }
        /// <summary>
        /// Provede nacteni zalohy hry ze xml souboru po potvrzeni volby souboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialogOtevriHru_FileOk(object sender, CancelEventArgs e)
        {
            pexeso = (LogikaHry)pexeso.Deserializuj(openFileDialogOtevriHru.FileName);
            InicializujNoveOkno();
            NastavVlastnostiPictureBoxuSeZalohy(pexeso.ZalohaVlastnistiKarticekSOknaPexeso);
        }

        /// <summary>
        /// Nacte parametry instance pexeso tridy LogikaHry a nastavi tak hru do stavu v zaloze
        /// </summary>
        /// <param name="zalohaVlastnistiKarticek"></param>
        private void NastavVlastnostiPictureBoxuSeZalohy(object[] zalohaVlastnistiKarticek)
        {
            try
            {
                for (int i = 0; i < Karticky.Length; i++)
                {
                    object[] vlastnostiPictureBoxu = (object[])zalohaVlastnistiKarticek[i]; // { Name, Tag, Image, Enable }
                    Karticky[i].Name = (string)vlastnostiPictureBoxu[0];
                    Karticky[i].Tag = (string)vlastnostiPictureBoxu[1];
                    if (Karticky[i].Tag == null) //pokud je karticka vyrazena, tak se obrazek nacte se pole obrazky pomoci indexu s pole pexeso.PoleIndexuObrazkuNaKartickach
                    {
                        Karticky[i].Image = obrazky[pexeso.PoleIndexuObrazkuNaKartickach[i]]; 
                    }
                    Karticky[i].Enabled = (bool)vlastnostiPictureBoxu[3];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hru nelze načíst ze zalohy.", "Načítání hry ze zalohy.", MessageBoxButtons.OK);
                return;
            }
        }

        /// <summary>
        /// Metoda po kliknuti na polozku Uloz hru v menu, ulozi xml soubor s parametry instance pexeso a nazev souboru do Listu ulozeneZalohyHerNazvySouboru.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UložHruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pexeso.seznamHracu[0].UlozInstanciDoXMLretezce();
            
            //VytvorZalohuKaticek();
            string prefix = "hra";
            string nazevSouboru = prefix.VytvorNazev();
            //vytvori se v instanci pexeso tridy LogikaHry zaloha nastaveni obrazku v kartickach.
            pexeso.ZalohaVlastnistiKarticekSOknaPexeso = VytvorZalohuKaticek();
            //tvorba xml
            pexeso.UlozInstanciDoXMLsouboru(nazevSouboru, UlozisteZaloh, out bool xmlUlozeno);
            //povrzeni uzivateli o provedenem ukladani xml
            if (xmlUlozeno)
            {
                MessageBox.Show("Hra byla uložena.", "Ukládání hry", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ukládání hry se nepovedlo.", "Ukládání hry", MessageBoxButtons.OK);
            }
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
            info.ShowDialog();
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
