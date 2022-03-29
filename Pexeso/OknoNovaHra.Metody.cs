using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Pexeso
{
    /// <summary>
    /// Trida bude rešit prijimani parametru od uzivatele nutnych k vytvoreni nove hry podle zadani uzivatele.
    /// Mela by sezbírat všenchny potrebne informace od uzivatele a po zmacknuti tlacitka vytvor hru predat tyto data instancim OknaPexoso a LogikaHry.
    /// Po ukonceni dialogu bez potvrzeni by se nemelo nic stat.
    /// </summary>
    partial class OknoNovaHra : Form
    {

        //Prvky Okna Nova Hra
        Label[] labelsHraci;
        ComboBox[] comboBoxesJmenaHracu;
        ComboBox aktivniComboxJmenoHrace;
        int maxPocetHracuVeHre; //pri tvorbe konstruktoru umoznuje omezit kolik muze byt voleno poctu hracu
        object[] herniPole; //pole hodnot velikosti herniho plochy (poctu karticek), ktere se zobrazi v comboBoxu comboBoxPocetKarticek

        //Data z databaze her a hracu
        object[] jmenaHracu;

        //Parametry k hracum => predavaj se do instance LogikaHry
        public int pocetHracu; //zadany pocet hracu uzivatelem
        public Hrac[] zadaniHraciVeHre; //seznam navolenych hracu

        //Parametry k rozlozeni hry  => predavaj se do instance LogikaHry
        public int PocetKarticekVeHre;
       

        /// <summary>
        /// Konstruktor okna NovaHra
        /// </summary>
        public OknoNovaHra(object[] herniPole, int maxPocetHracuVeHre = 6)
        {
            //Data z databaze her a hracu
            jmenaHracu = new object[] { "Karel", "Iveta", "Zdenek", "Lubor"};
            this.maxPocetHracuVeHre = maxPocetHracuVeHre;
            this.herniPole = herniPole;

            //Statické prvky Okna Nova Hra
            InitializeComponent();

            //Comboboxy na zadani prezdivky hracu se predvitvori a pak se zobrazuji podle potreby
            aktivniComboxJmenoHrace = comboBoxJmenoHrace1;
            labelsHraci = VytvorLabelyHraci(maxPocetHracuVeHre);
            comboBoxJmenoHrace1.Items.AddRange(jmenaHracu);
            comboBoxesJmenaHracu = VytvorComboBoxyJmenaHracu(maxPocetHracuVeHre);
            numericUpDownPocetHracu.Maximum = maxPocetHracuVeHre; //nastavi limit poctu hracu na prvek UpDown
            //Nove jmeno
            textBoxNoveJmeno.SelectionStart = 0;
            textBoxNoveJmeno.SelectionLength = textBoxNoveJmeno.Text.Length;

            naplnComboBoxHerniPole();
            comboBoxPocetKarticek.SelectedIndex = 0; //na zacaktu je vzdy vybrana prvni polozka

            //Parametry k hracum => predavaj se do instance LogikaHry
            //vzdy ve hre je aspon jeden hrac
            pocetHracu = 1; 
            zadaniHraciVeHre = new Hrac[maxPocetHracuVeHre];
            zadaniHraciVeHre[0] = new Hrac("hrac 1");
            comboBoxesJmenaHracu[0].SelectedItem = zadaniHraciVeHre[0].VratJmeno();
            
        }

        //VOLBA ROZLOZENI HRY

        /// <summary>
        /// metoda pridava do ComboBoxu Pocet karticek polozky povolenych velikosti hraciho pole ulozenych ve slovniku rozlozeni v tride LogikaHry.
        /// </summary>
        private void naplnComboBoxHerniPole()
        {
            comboBoxPocetKarticek.Items.AddRange(herniPole);
        }

        private void comboBoxPocetKarticek_SelectedIndexChanged(object sender, EventArgs e)
        {
            PocetKarticekVeHre = (int)comboBoxPocetKarticek.SelectedItem;
        }

       
        //POCET HRACU A PRIDAVANI LABELU HRAC A COMBOBOXU
        private void numericUpDownPocetHracu_ValueChanged(object sender, EventArgs e)
        {
            //oznaceni hrace cislem (1 az n), nasledne je treba odecist 1 pro index v poli
            int hracCislo = (int)numericUpDownPocetHracu.Value;
           if(hracCislo > pocetHracu)
            {
                ZobrazDalsiControlsHrac();
            }
            else 
            {
                SmazPosledniControls();
            }
        }

        private void SmazPosledniControls()
        {
            pocetHracu--;
            zadaniHraciVeHre[pocetHracu] = null; 
            labelsHraci[pocetHracu].Visible = false;
            comboBoxesJmenaHracu[pocetHracu].Visible = false;
        }

        private void ZobrazDalsiControlsHrac()
        {
            pocetHracu++;
            zadaniHraciVeHre[pocetHracu - 1] = new Hrac($"hrac {pocetHracu}");
            labelsHraci[pocetHracu - 1].Visible = true;
            comboBoxesJmenaHracu[pocetHracu - 1].Visible = true;
        }

        //POPISKY HRACI

        /// <summary>
        /// Vytvori controls Labels do pole labelsHraci. 
        /// </summary>
        /// <param name="maxPocetHracuVeHre"></param>
        private Label[] VytvorLabelyHraci(int maxPocetHracuVeHre)
        {
            labelsHraci = new Label[maxPocetHracuVeHre];
            labelsHraci[0] = labelhrac1;
            for (int i = 1; i < labelsHraci.Length; i++)
            {
                VytvorLabelHrac(i);
            }
            return labelsHraci;
        }
        private void VytvorLabelHrac(int i)
        {
            Label label = new Label(); //prevezme vlastnosti labelhrac1 a nasledne se upravy ty parametry, ktere jsou individualni jako umisteni v okne, nazev, text, tab
            label.Name = $"labelHrac{i}";
            label.Text = $"hráč{i + 1}:";
            label.Location = new System.Drawing.Point(labelhrac1.Location.X, labelhrac1.Location.Y + i * 30);

            label.Size = labelhrac1.Size;
            label.TabIndex = labelhrac1.TabIndex + i + 1;
            label.Font = labelhrac1.Font;
            label.Visible = false;
            //prida label do formulare
            this.Controls.Add(label);
            //prida do seznamu labelu pro dalsi hromadne upravy    
            labelsHraci[i] = label;
        }


        //ZADANI HRACU - COMBOBOX

        private ComboBox[] VytvorComboBoxyJmenaHracu (int maxPocetHracuVeHre)
        {
            comboBoxesJmenaHracu = new ComboBox[maxPocetHracuVeHre];
            comboBoxesJmenaHracu[0] = comboBoxJmenoHrace1;
            for (int i = 1; i < comboBoxesJmenaHracu.Length; i++)
            {
                VytvorComboBoxJmenoHrace(i);
            }
            return comboBoxesJmenaHracu;
        }

        /// <summary>
        /// Vytvori comboBox pro zadani jmena hrace. comboBox se vytvari na zaklade comboBoxJmenoHrace1. ComboBox se ulozi do pole comboBoxesJmenaHracu.
        /// </summary>
        /// <param name="i"></param>
        private void VytvorComboBoxJmenoHrace(int i)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Font = comboBoxJmenoHrace1.Font;
            comboBox.FormattingEnabled = comboBoxJmenoHrace1.FormattingEnabled;
            comboBox.Items.AddRange(jmenaHracu);
            comboBox.Items.Add("přidat jméno");
            comboBox.Location = new System.Drawing.Point(comboBoxJmenoHrace1.Location.X, comboBoxJmenoHrace1.Location.Y + 30*i);
            comboBox.Name = $"comboBoxJmenoHrace{i}";
            comboBox.Size = comboBoxJmenoHrace1.Size;
            comboBox.TabIndex = comboBoxJmenoHrace1.TabIndex + i;
            comboBox.Tag = i;
            comboBox.Visible = false;

            //prida combobox do formulare
            this.Controls.Add(comboBox);
            //prida do seznamu labelu pro dalsi hromadne upravy    
            comboBoxesJmenaHracu[i] = comboBox;
            //prirazene udalosti
            comboBox.SelectedValueChanged += new System.EventHandler(comboBoxJmenoHrace_SelectedValueChanged);
            comboBox.TextChanged += new System.EventHandler(this.comboBoxJmenoHrace_TextChanged);
        }
        /// <summary>
        /// Po vybrani jmena hrace se jmeno (prezdivka) zapise do instance Hrac. Pokud uzivatel nevybere zadne jmeno, zustavne v instaci Hrace automaticky vygenerovana prezdivka. Pokud vybere "nove jmeno" bude moci zadat jine jmeno, ktere neni v seznamu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxJmenoHrace_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            aktivniComboxJmenoHrace = comboBox;
            string novaPresdivka = comboBox.SelectedItem.ToString();
            zadaniHraciVeHre[(int)comboBox.Tag].PrejmenujHrace(novaPresdivka);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxJmenoHrace_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string novaPresdivka = comboBox.Text;
            zadaniHraciVeHre[(int)comboBox.Tag].PrejmenujHrace(novaPresdivka);
            //Napsat validaci jmeno jestli uz neexistuje
        }

        //pridat metodu, ktera pri zavirani okna ulozi nove prezdivky do nejake databaze, co jeste neexistuje
    }
}
