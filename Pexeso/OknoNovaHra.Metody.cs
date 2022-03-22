using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    /// <summary>
    /// Trida bude rešit prijimani parametru od uzivatele nutnych k vytvoreni nove hry podle zadani uzivatele.
    /// Mela by sezbírat všenchny potrebne informace od uzivatele a po zmacknuti tlacitka vytvor hru predat tyto data instancim OknaPexoso a LogikaHry.
    /// Po ukonceni dialogu bez potvrzeni by se nemelo nic stat.
    /// </summary>
    partial class OknoNovaHra : Form
    {
        /// <summary>
        /// Konstruktor okna NovaHra
        /// </summary>

        Label[] labelsHraci;
        ComboBox[] hraci;
        int maxPocetHracuVeHre;

        public OknoNovaHra(int maxPocetHracuVeHre = 6)
        {
            InitializeComponent();
            this.maxPocetHracuVeHre = maxPocetHracuVeHre;
            labelsHraci = VytvorLabelyHraci(maxPocetHracuVeHre);
        }
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

        private void numericUpDownPocetHracu_ValueChanged(object sender, EventArgs e)
        {
            //oznaceni hrace cislem (1 az n), nasledne je treba odecist 1 pro index v poli
            int hracCislo = (int)numericUpDownPocetHracu.Value;

            //if (labelsHraci[hracCislo] == null) //doresit podminky
            //{
            //    ZobrazDalsiLabelHrac(hracCislo );
            //}
            //else
            //{
            //    SmazPosledniLabel(hracCislo - 1);
            //}

        }

        private void SmazPosledniLabel(int i)
        {
            labelsHraci[i].Visible = false;

        }

        private void ZobrazDalsiLabelHrac(int i)
        {
            labelsHraci[i].Visible = true;
        }

        private void VytvorLabelHrac(int i)
        {
            Label label = new Label(); //prevezme vlastnosti labelhrac1 a nasledne se upravy ty parametry, ktere jsou individualni jako umisteni v okne, nazev, text, tab
            label.Name = "labelHrac" + i.ToString();
            label.Text = "hráč " + (i + 1).ToString() + ":";
            label.Location = new System.Drawing.Point(labelhrac1.Location.X, labelhrac1.Location.Y + i * 25);

            label.Size = labelhrac1.Size;
            label.TabIndex = labelhrac1.TabIndex + i + 1;
            label.Font = labelhrac1.Font;
            label.Visible = false;
            //prida label do formulare
            this.Controls.Add(label);
            //prida do seznamu labelu pro dalsi hromadne upravy    
            labelsHraci[i] = label;
        }
    }
}
