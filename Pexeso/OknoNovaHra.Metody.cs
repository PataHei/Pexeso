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

        public OknoNovaHra()
        {
            InitializeComponent();
            maxPocetHracuVeHre = 6;
            labelsHraci = new Label[maxPocetHracuVeHre];
            labelsHraci[0] = labelhrac1;
        }

        private void numericUpDownPocetHracu_ValueChanged(object sender, EventArgs e)
        {
            int i = (int)numericUpDownPocetHracu.Value - 1;
            Label label = new Label();
            label.Name = "labelHrac" + i.ToString();
            label.Text = "hráč " + (i+1).ToString() + ":";
            label.TabIndex = labelhrac1.TabIndex + 1;
            label.Location = new System.Drawing.Point(71, 141 + i * 25);
            label.Visible = true;

            //staticke vlastnosti
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Size = new System.Drawing.Size(61, 20);
            this.Controls.Add(label);
                
            labelsHraci[i] = label;
        }
    }
}
