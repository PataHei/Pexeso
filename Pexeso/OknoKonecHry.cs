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
    public partial class OknoKonecHry : Form
    {
        LogikaHry pexeso;
        public OknoKonecHry(LogikaHry pexeso)
        {
            InitializeComponent();
            this.pexeso = pexeso;
        }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OknoKonecHry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
            {

            }
        }
    }
}
