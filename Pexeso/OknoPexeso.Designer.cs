namespace Pexeso
{
    partial class OknoPexeso
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
            this.labelScoreValue = new System.Windows.Forms.Label();
            this.labelPocetBodu = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaHraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložHruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načtiHruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hračiAStatistikyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novýHráčToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načtiHráčeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.zobrazProfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikaHerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smažHráčeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikyHerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stopky = new System.Windows.Forms.Timer(this.components);
            this.PocetPokusuPopisek = new System.Windows.Forms.Label();
            this.labelHodnotaPocetPokusu = new System.Windows.Forms.Label();
            this.openFileDialogOtevriHru = new System.Windows.Forms.OpenFileDialog();
            this.labelJmenoHrace = new System.Windows.Forms.Label();
            this.labelKonecHry = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelScoreValue
            // 
            this.labelScoreValue.AutoSize = true;
            this.labelScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreValue.Location = new System.Drawing.Point(418, 76);
            this.labelScoreValue.Name = "labelScoreValue";
            this.labelScoreValue.Size = new System.Drawing.Size(24, 25);
            this.labelScoreValue.TabIndex = 7;
            this.labelScoreValue.Text = "0";
            // 
            // labelPocetBodu
            // 
            this.labelPocetBodu.AutoSize = true;
            this.labelPocetBodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPocetBodu.Location = new System.Drawing.Point(294, 78);
            this.labelPocetBodu.Name = "labelPocetBodu";
            this.labelPocetBodu.Size = new System.Drawing.Size(109, 20);
            this.labelPocetBodu.TabIndex = 19;
            this.labelPocetBodu.Text = "Počet bodů:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hraToolStripMenuItem,
            this.hračiAStatistikyToolStripMenuItem,
            this.hraciToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(1000, 30);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(800, 27);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaHraToolStripMenuItem,
            this.uložHruToolStripMenuItem,
            this.načtiHruToolStripMenuItem,
            this.konecToolStripMenuItem});
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.hraToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.hraToolStripMenuItem.Text = "Hra";
            // 
            // novaHraToolStripMenuItem
            // 
            this.novaHraToolStripMenuItem.Name = "novaHraToolStripMenuItem";
            this.novaHraToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.novaHraToolStripMenuItem.Text = "Nova hra";
            this.novaHraToolStripMenuItem.Click += new System.EventHandler(this.NovaHraToolStripMenuItem_Click);
            // 
            // uložHruToolStripMenuItem
            // 
            this.uložHruToolStripMenuItem.Name = "uložHruToolStripMenuItem";
            this.uložHruToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.uložHruToolStripMenuItem.Text = "Ulož hru";
            this.uložHruToolStripMenuItem.Click += new System.EventHandler(this.UložHruToolStripMenuItem_Click);
            // 
            // načtiHruToolStripMenuItem
            // 
            this.načtiHruToolStripMenuItem.Name = "načtiHruToolStripMenuItem";
            this.načtiHruToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.načtiHruToolStripMenuItem.Text = "Načti hru";
            this.načtiHruToolStripMenuItem.Click += new System.EventHandler(this.NačtiHruToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.KonecToolStripMenuItem_Click);
            // 
            // hračiAStatistikyToolStripMenuItem
            // 
            this.hračiAStatistikyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novýHráčToolStripMenuItem,
            this.načtiHráčeToolStripMenuItem,
            this.smažHráčeToolStripMenuItem,
            this.statistikyHerToolStripMenuItem});
            this.hračiAStatistikyToolStripMenuItem.Name = "hračiAStatistikyToolStripMenuItem";
            this.hračiAStatistikyToolStripMenuItem.Size = new System.Drawing.Size(131, 23);
            this.hračiAStatistikyToolStripMenuItem.Text = "Hrači a statistiky";
            // 
            // novýHráčToolStripMenuItem
            // 
            this.novýHráčToolStripMenuItem.Name = "novýHráčToolStripMenuItem";
            this.novýHráčToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.novýHráčToolStripMenuItem.Text = "Nový hráč";
            // 
            // načtiHráčeToolStripMenuItem
            // 
            this.načtiHráčeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.zobrazProfilToolStripMenuItem,
            this.statistikaHerToolStripMenuItem});
            this.načtiHráčeToolStripMenuItem.Name = "načtiHráčeToolStripMenuItem";
            this.načtiHráčeToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.načtiHráčeToolStripMenuItem.Text = "Načti hráče";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.Text = "Hráč";
            // 
            // zobrazProfilToolStripMenuItem
            // 
            this.zobrazProfilToolStripMenuItem.Name = "zobrazProfilToolStripMenuItem";
            this.zobrazProfilToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.zobrazProfilToolStripMenuItem.Text = "Zobraz profil";
            // 
            // statistikaHerToolStripMenuItem
            // 
            this.statistikaHerToolStripMenuItem.Name = "statistikaHerToolStripMenuItem";
            this.statistikaHerToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.statistikaHerToolStripMenuItem.Text = "Statistika her";
            // 
            // smažHráčeToolStripMenuItem
            // 
            this.smažHráčeToolStripMenuItem.Name = "smažHráčeToolStripMenuItem";
            this.smažHráčeToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.smažHráčeToolStripMenuItem.Text = "Smaž hráče";
            // 
            // statistikyHerToolStripMenuItem
            // 
            this.statistikyHerToolStripMenuItem.Name = "statistikyHerToolStripMenuItem";
            this.statistikyHerToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.statistikyHerToolStripMenuItem.Text = "Žebříčky her";
            // 
            // hraciToolStripMenuItem
            // 
            this.hraciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.hraciToolStripMenuItem.Name = "hraciToolStripMenuItem";
            this.hraciToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.hraciToolStripMenuItem.Text = "Help";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.HelpToolStripMenuItem.Text = "Pravidla";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.infoToolStripMenuItem.Text = "O aplikaci";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // Stopky
            // 
            this.Stopky.Interval = 1000;
            this.Stopky.Tick += new System.EventHandler(this.Stopky_Tick);
            // 
            // PocetPokusuPopisek
            // 
            this.PocetPokusuPopisek.AutoSize = true;
            this.PocetPokusuPopisek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PocetPokusuPopisek.Location = new System.Drawing.Point(507, 78);
            this.PocetPokusuPopisek.Name = "PocetPokusuPopisek";
            this.PocetPokusuPopisek.Size = new System.Drawing.Size(128, 20);
            this.PocetPokusuPopisek.TabIndex = 21;
            this.PocetPokusuPopisek.Text = "Počet pokusů:";
            // 
            // labelHodnotaPocetPokusu
            // 
            this.labelHodnotaPocetPokusu.AutoSize = true;
            this.labelHodnotaPocetPokusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHodnotaPocetPokusu.Location = new System.Drawing.Point(653, 76);
            this.labelHodnotaPocetPokusu.Name = "labelHodnotaPocetPokusu";
            this.labelHodnotaPocetPokusu.Size = new System.Drawing.Size(24, 25);
            this.labelHodnotaPocetPokusu.TabIndex = 22;
            this.labelHodnotaPocetPokusu.Text = "0";
            this.labelHodnotaPocetPokusu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialogOtevriHru
            // 
            this.openFileDialogOtevriHru.FileName = "hra";
            this.openFileDialogOtevriHru.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogOtevriHru_FileOk);
            // 
            // labelJmenoHrace
            // 
            this.labelJmenoHrace.AutoSize = true;
            this.labelJmenoHrace.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJmenoHrace.Location = new System.Drawing.Point(89, 70);
            this.labelJmenoHrace.Name = "labelJmenoHrace";
            this.labelJmenoHrace.Size = new System.Drawing.Size(101, 37);
            this.labelJmenoHrace.TabIndex = 23;
            this.labelJmenoHrace.Text = "hráčxxx";
            // 
            // labelKonecHry
            // 
            this.labelKonecHry.AutoSize = true;
            this.labelKonecHry.BackColor = System.Drawing.Color.Transparent;
            this.labelKonecHry.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKonecHry.ForeColor = System.Drawing.Color.BlueViolet;
            this.labelKonecHry.Location = new System.Drawing.Point(290, 237);
            this.labelKonecHry.Name = "labelKonecHry";
            this.labelKonecHry.Size = new System.Drawing.Size(205, 44);
            this.labelKonecHry.TabIndex = 25;
            this.labelKonecHry.Text = "Konec Hry";
            this.labelKonecHry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OknoPexeso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.labelKonecHry);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelJmenoHrace);
            this.Controls.Add(this.labelHodnotaPocetPokusu);
            this.Controls.Add(this.PocetPokusuPopisek);
            this.Controls.Add(this.labelPocetBodu);
            this.Controls.Add(this.labelScoreValue);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(570, 370);
            this.Name = "OknoPexeso";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 70, 60);
            this.Text = "Pexeso";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelScoreValue;
        private System.Windows.Forms.Label labelPocetBodu;
        private System.Windows.Forms.ToolStripMenuItem hraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hraciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Timer Stopky;
        private System.Windows.Forms.Label PocetPokusuPopisek;
        private System.Windows.Forms.Label labelHodnotaPocetPokusu;
        private System.Windows.Forms.ToolStripMenuItem hračiAStatistikyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novýHráčToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načtiHráčeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem zobrazProfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikaHerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smažHráčeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikyHerToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialogOtevriHru;
        private System.Windows.Forms.ToolStripMenuItem novaHraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložHruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načtiHruToolStripMenuItem;
        private System.Windows.Forms.Label labelJmenoHrace;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label labelKonecHry;
    }
}

