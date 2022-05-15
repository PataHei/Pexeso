
namespace Pexeso
{
    partial class OknoKonecHry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelHHraci = new System.Windows.Forms.Label();
            this.labelHSkore = new System.Windows.Forms.Label();
            this.labelHPocetTahu = new System.Windows.Forms.Label();
            this.labelHPoradi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataPexesoDataSet = new Pexeso.DataPexesoDataSet();
            this.dataPexesoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonKonec = new System.Windows.Forms.Button();
            this.buttonNovaHra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataPexesoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPexesoDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHHraci
            // 
            this.labelHHraci.AutoSize = true;
            this.labelHHraci.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHHraci.Location = new System.Drawing.Point(206, 87);
            this.labelHHraci.Name = "labelHHraci";
            this.labelHHraci.Size = new System.Drawing.Size(62, 25);
            this.labelHHraci.TabIndex = 0;
            this.labelHHraci.Text = "Hrači";
            // 
            // labelHSkore
            // 
            this.labelHSkore.AutoSize = true;
            this.labelHSkore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHSkore.Location = new System.Drawing.Point(358, 87);
            this.labelHSkore.Name = "labelHSkore";
            this.labelHSkore.Size = new System.Drawing.Size(69, 25);
            this.labelHSkore.TabIndex = 1;
            this.labelHSkore.Text = "Skore";
            // 
            // labelHPocetTahu
            // 
            this.labelHPocetTahu.AutoSize = true;
            this.labelHPocetTahu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHPocetTahu.Location = new System.Drawing.Point(525, 87);
            this.labelHPocetTahu.Name = "labelHPocetTahu";
            this.labelHPocetTahu.Size = new System.Drawing.Size(115, 25);
            this.labelHPocetTahu.TabIndex = 2;
            this.labelHPocetTahu.Text = "Počet tahů";
            // 
            // labelHPoradi
            // 
            this.labelHPoradi.AutoSize = true;
            this.labelHPoradi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHPoradi.Location = new System.Drawing.Point(60, 87);
            this.labelHPoradi.Name = "labelHPoradi";
            this.labelHPoradi.Size = new System.Drawing.Size(74, 25);
            this.labelHPoradi.TabIndex = 3;
            this.labelHPoradi.Text = "Pořadí";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(229, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Listina výsledků hry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 122);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(25, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = ".1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(209, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Karel";
            // 
            // dataPexesoDataSet
            // 
            this.dataPexesoDataSet.DataSetName = "DataPexesoDataSet";
            this.dataPexesoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataPexesoDataSetBindingSource
            // 
            this.dataPexesoDataSetBindingSource.DataSource = this.dataPexesoDataSet;
            this.dataPexesoDataSetBindingSource.Position = 0;
            // 
            // buttonKonec
            // 
            this.buttonKonec.Location = new System.Drawing.Point(173, 343);
            this.buttonKonec.Name = "buttonKonec";
            this.buttonKonec.Size = new System.Drawing.Size(135, 44);
            this.buttonKonec.TabIndex = 9;
            this.buttonKonec.Text = "Konec";
            this.buttonKonec.UseVisualStyleBackColor = true;
            this.buttonKonec.Click += new System.EventHandler(this.buttonKonec_Click);
            // 
            // buttonNovaHra
            // 
            this.buttonNovaHra.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonNovaHra.Location = new System.Drawing.Point(408, 343);
            this.buttonNovaHra.Name = "buttonNovaHra";
            this.buttonNovaHra.Size = new System.Drawing.Size(135, 44);
            this.buttonNovaHra.TabIndex = 10;
            this.buttonNovaHra.Text = "Nová hra";
            this.buttonNovaHra.UseVisualStyleBackColor = true;
            this.buttonNovaHra.Click += new System.EventHandler(this.buttonNovaHra_Click);
            // 
            // OknoKonecHry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonNovaHra);
            this.Controls.Add(this.buttonKonec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelHPoradi);
            this.Controls.Add(this.labelHPocetTahu);
            this.Controls.Add(this.labelHSkore);
            this.Controls.Add(this.labelHHraci);
            this.Name = "OknoKonecHry";
            this.Text = "Konec hry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OknoKonecHry_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataPexesoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPexesoDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHHraci;
        private System.Windows.Forms.Label labelHSkore;
        private System.Windows.Forms.Label labelHPocetTahu;
        private System.Windows.Forms.Label labelHPoradi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DataPexesoDataSet dataPexesoDataSet;
        private System.Windows.Forms.BindingSource dataPexesoDataSetBindingSource;
        private System.Windows.Forms.Button buttonKonec;
        private System.Windows.Forms.Button buttonNovaHra;
    }
}