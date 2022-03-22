using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    /// <summary>
    /// Trida bude rešit prijimani parametru od uzivatele nutnych k vytvoreni nove hry podle zadani uzivatele
    /// </summary>
    partial class OknoNovaHra: Form
    {
        private Label labelPocetHracu;
        private Label labelPocetKartiček;
        private NumericUpDown numericUpDownPocetHracu;
        private Button buttonVytvor;
        private Button buttonCancel;
        private ComboBox comboBox1;
        private Label labelhrac1;
        private Label label1;


        private void InitializeComponent()
        {
            this.labelPocetHracu = new System.Windows.Forms.Label();
            this.labelPocetKartiček = new System.Windows.Forms.Label();
            this.numericUpDownPocetHracu = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVytvor = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelhrac1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetHracu)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPocetHracu
            // 
            this.labelPocetHracu.AutoSize = true;
            this.labelPocetHracu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPocetHracu.Location = new System.Drawing.Point(43, 42);
            this.labelPocetHracu.Name = "labelPocetHracu";
            this.labelPocetHracu.Size = new System.Drawing.Size(116, 25);
            this.labelPocetHracu.TabIndex = 0;
            this.labelPocetHracu.Text = "Počet hráčů";
            // 
            // labelPocetKartiček
            // 
            this.labelPocetKartiček.AutoSize = true;
            this.labelPocetKartiček.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPocetKartiček.Location = new System.Drawing.Point(364, 42);
            this.labelPocetKartiček.Name = "labelPocetKartiček";
            this.labelPocetKartiček.Size = new System.Drawing.Size(134, 25);
            this.labelPocetKartiček.TabIndex = 1;
            this.labelPocetKartiček.Text = "Počet kartiček";
            // 
            // numericUpDownPocetHracu
            // 
            this.numericUpDownPocetHracu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPocetHracu.Location = new System.Drawing.Point(176, 41);
            this.numericUpDownPocetHracu.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownPocetHracu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPocetHracu.Name = "numericUpDownPocetHracu";
            this.numericUpDownPocetHracu.Size = new System.Drawing.Size(50, 27);
            this.numericUpDownPocetHracu.TabIndex = 3;
            this.numericUpDownPocetHracu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPocetHracu.ValueChanged += new System.EventHandler(this.numericUpDownPocetHracu_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hráčí";
            // 
            // buttonVytvor
            // 
            this.buttonVytvor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVytvor.Location = new System.Drawing.Point(109, 312);
            this.buttonVytvor.Name = "buttonVytvor";
            this.buttonVytvor.Size = new System.Drawing.Size(158, 40);
            this.buttonVytvor.TabIndex = 7;
            this.buttonVytvor.Text = "Vytvoř hru";
            this.buttonVytvor.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(340, 312);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(158, 40);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Zahoď";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(517, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(56, 24);
            this.comboBox1.TabIndex = 9;
            // 
            // labelhrac1
            // 
            this.labelhrac1.AutoSize = true;
            this.labelhrac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelhrac1.Location = new System.Drawing.Point(58, 139);
            this.labelhrac1.Name = "labelhrac1";
            this.labelhrac1.Size = new System.Drawing.Size(61, 20);
            this.labelhrac1.TabIndex = 10;
            this.labelhrac1.Text = "hrač 1:";
            // 
            // OknoNovaHra
            // 
            this.ClientSize = new System.Drawing.Size(628, 383);
            this.Controls.Add(this.labelhrac1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonVytvor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownPocetHracu);
            this.Controls.Add(this.labelPocetKartiček);
            this.Controls.Add(this.labelPocetHracu);
            this.Name = "OknoNovaHra";
            this.Text = "Nová hra";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPocetHracu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
