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
    /// <summary>
    /// Dialog se zobrazi na konci hry a zobrazi vysledky hry/hracu a nabidne dalsi moznosti - ukonceni aplikace, novou hru
    /// </summary>
    public partial class OknoKonecHry : Form
    {
        LogikaHry pexeso;
        public OknoKonecHry(LogikaHry pexeso)
        {
            this.pexeso = pexeso;
            InitializeComponent();
            VytvorLabelyVysledkuHryVRadku();
        }
        //METODY SPOJENE SE ZOBRAZENIM VYSLEDKU HRY - STATISTIKY

        /// <summary>
        /// Zobrazi tabulku vysledku poskladanou s labelu 
        /// </summary>
        /// <param name="maxPocetHracuVeHre"></param>
        private void VytvorLabelyVysledkuHryVRadku()
        {
            Hrac[] poradiHracu = SeratHracePodlePoradiVeHre(pexeso.seznamHracu);
            for (int i = 0; i < pexeso.PocetHracu; i++)
            {
                VytvorLabel(i+1, 0, (i+1).ToString() + ".",  labelHPoradi);
                VytvorLabel(i + 1, 1, poradiHracu[i].Prezdivka, labelHHraci);
                VytvorLabel(i + 1, 2, poradiHracu[i].Skore.ToString(), labelHSkore);
                VytvorLabel(i + 1, 3, poradiHracu[i].PocetTahu.ToString(), labelHPocetTahu);
            }

        }
        /// <summary>
        /// Vytovri Label s jednou informaci o hraci
        /// </summary>
        /// <param name="radek">int, 0. radek je zahlavi</param>
        /// <param name="sloupec">int od 0</param>
        /// <param name="text">jedna informace o hraci</param>
        /// <param name="LabelZahlavi">prvni zobrazeny label hlavicky (z leva) tabulky od ktereho se pocita pozice noveho labelu </param>
        private void VytvorLabel(int radek, int sloupec, string text, Label LabelZahlavi)
        {
            Label label = new Label(); 
            label.Name = $"label{radek}{sloupec}";
            label.Text = text;
            label.Location = new System.Drawing.Point(LabelZahlavi.Location.X, LabelZahlavi.Location.Y + radek * 40);
            label.AutoSize = true;
            label.Font = LabelZahlavi.Font;
            label.Visible = true;
            label.TextAlign = ContentAlignment.MiddleLeft;
            //prida label do formulare
            this.Controls.Add(label);

        }

        private Hrac[] SeratHracePodlePoradiVeHre(Hrac[] hraci)
        {
            IQueryable hraciQ = hraci.AsQueryable();
            IEnumerable<Hrac> hraciDistintovani = hraci.Distinct();
            return hraciDistintovani.OrderByDescending(hrac => hrac.Skore).ToArray();
        }

        //METODY SPOJENE S VOLBOU DALSICH AKTIVIT V APLIKACI
        /// <summary>
        /// Ukonci hru pexeso po stisknuti tlacitka.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonKonec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// Otevre dialog nova hra pro vytvoreni nove hry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNovaHra_Click(object sender, EventArgs e)
        {
            this.Close();   
        }



    }
}
