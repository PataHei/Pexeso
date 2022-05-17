
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
            this.labelHPoradi = new System.Windows.Forms.Label();
            this.labelHSkore = new System.Windows.Forms.Label();
            this.labelHPocetTahu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.labelHHraci.Location = new System.Drawing.Point(246, 87);
            this.labelHHraci.Name = "labelHHraci";
            this.labelHHraci.Size = new System.Drawing.Size(62, 25);
            this.labelHHraci.TabIndex = 0;
            this.labelHHraci.Text = "Hrači";
            // 
            // labelHPoradi
            // 
            this.labelHPoradi.AutoSize = true;
            this.labelHPoradi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHPoradi.Location = new System.Drawing.Point(80, 87);
            this.labelHPoradi.Name = "labelHPoradi";
            this.labelHPoradi.Size = new System.Drawing.Size(74, 25);
            this.labelHPoradi.TabIndex = 3;
            this.labelHPoradi.Text = "Pořadí";
            // 
            // labelHSkore
            // 
            this.labelHSkore.AutoSize = true;
            this.labelHSkore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHSkore.Location = new System.Drawing.Point(424, 87);
            this.labelHSkore.Name = "labelHSkore";
            this.labelHSkore.Size = new System.Drawing.Size(69, 25);
            this.labelHSkore.TabIndex = 1;
            this.labelHSkore.Text = "Skore";
            // 
            // labelHPocetTahu
            // 
            this.labelHPocetTahu.AutoSize = true;
            this.labelHPocetTahu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHPocetTahu.Location = new System.Drawing.Point(594, 87);
            this.labelHPocetTahu.Name = "labelHPocetTahu";
            this.labelHPocetTahu.Size = new System.Drawing.Size(115, 25);
            this.labelHPocetTahu.TabIndex = 2;
            this.labelHPocetTahu.Text = "Počet tahů";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(200, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Listina výsledků hry";
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
            this.buttonKonec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelHPoradi);
            this.Controls.Add(this.labelHPocetTahu);
            this.Controls.Add(this.labelHSkore);
            this.Controls.Add(this.labelHHraci);
            this.Name = "OknoKonecHry";
            this.Text = "Konec hry";
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
        private DataPexesoDataSet dataPexesoDataSet;
        private System.Windows.Forms.BindingSource dataPexesoDataSetBindingSource;
        private System.Windows.Forms.Button buttonKonec;
        private System.Windows.Forms.Button buttonNovaHra;
    }
}