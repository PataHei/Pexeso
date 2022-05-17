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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OknoPexeso));
            this.labelScoreValue = new System.Windows.Forms.Label();
            this.labelPocetBodu = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaHraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložHruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načtiHruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hračiAStatistikyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikyHerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stopky = new System.Windows.Forms.Timer(this.components);
            this.PocetPokusuPopisek = new System.Windows.Forms.Label();
            this.labelHodnotaPocetPokusu = new System.Windows.Forms.Label();
            this.openFileDialogOtevriHru = new System.Windows.Forms.OpenFileDialog();
            this.labelJmenoHrace = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelScoreValue
            // 
            resources.ApplyResources(this.labelScoreValue, "labelScoreValue");
            this.labelScoreValue.Name = "labelScoreValue";
            // 
            // labelPocetBodu
            // 
            resources.ApplyResources(this.labelPocetBodu, "labelPocetBodu");
            this.labelPocetBodu.Name = "labelPocetBodu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hraToolStripMenuItem,
            this.hračiAStatistikyToolStripMenuItem,
            this.hraciToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaHraToolStripMenuItem,
            this.uložHruToolStripMenuItem,
            this.načtiHruToolStripMenuItem,
            this.konecToolStripMenuItem});
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            resources.ApplyResources(this.hraToolStripMenuItem, "hraToolStripMenuItem");
            // 
            // novaHraToolStripMenuItem
            // 
            this.novaHraToolStripMenuItem.Name = "novaHraToolStripMenuItem";
            resources.ApplyResources(this.novaHraToolStripMenuItem, "novaHraToolStripMenuItem");
            this.novaHraToolStripMenuItem.Click += new System.EventHandler(this.NovaHraToolStripMenuItem_Click);
            // 
            // uložHruToolStripMenuItem
            // 
            this.uložHruToolStripMenuItem.Name = "uložHruToolStripMenuItem";
            resources.ApplyResources(this.uložHruToolStripMenuItem, "uložHruToolStripMenuItem");
            this.uložHruToolStripMenuItem.Click += new System.EventHandler(this.UložHruToolStripMenuItem_Click);
            // 
            // načtiHruToolStripMenuItem
            // 
            this.načtiHruToolStripMenuItem.Name = "načtiHruToolStripMenuItem";
            resources.ApplyResources(this.načtiHruToolStripMenuItem, "načtiHruToolStripMenuItem");
            this.načtiHruToolStripMenuItem.Click += new System.EventHandler(this.NačtiHruToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            resources.ApplyResources(this.konecToolStripMenuItem, "konecToolStripMenuItem");
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.KonecToolStripMenuItem_Click);
            // 
            // hračiAStatistikyToolStripMenuItem
            // 
            this.hračiAStatistikyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statistikyHerToolStripMenuItem});
            this.hračiAStatistikyToolStripMenuItem.Name = "hračiAStatistikyToolStripMenuItem";
            resources.ApplyResources(this.hračiAStatistikyToolStripMenuItem, "hračiAStatistikyToolStripMenuItem");
            // 
            // statistikyHerToolStripMenuItem
            // 
            this.statistikyHerToolStripMenuItem.Name = "statistikyHerToolStripMenuItem";
            resources.ApplyResources(this.statistikyHerToolStripMenuItem, "statistikyHerToolStripMenuItem");
            // 
            // hraciToolStripMenuItem
            // 
            this.hraciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.hraciToolStripMenuItem.Name = "hraciToolStripMenuItem";
            resources.ApplyResources(this.hraciToolStripMenuItem, "hraciToolStripMenuItem");
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // Stopky
            // 
            this.Stopky.Interval = 1000;
            this.Stopky.Tick += new System.EventHandler(this.Stopky_Tick);
            // 
            // PocetPokusuPopisek
            // 
            resources.ApplyResources(this.PocetPokusuPopisek, "PocetPokusuPopisek");
            this.PocetPokusuPopisek.Name = "PocetPokusuPopisek";
            // 
            // labelHodnotaPocetPokusu
            // 
            resources.ApplyResources(this.labelHodnotaPocetPokusu, "labelHodnotaPocetPokusu");
            this.labelHodnotaPocetPokusu.Name = "labelHodnotaPocetPokusu";
            // 
            // openFileDialogOtevriHru
            // 
            this.openFileDialogOtevriHru.FileName = "hra";
            this.openFileDialogOtevriHru.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogOtevriHru_FileOk);
            // 
            // labelJmenoHrace
            // 
            resources.ApplyResources(this.labelJmenoHrace, "labelJmenoHrace");
            this.labelJmenoHrace.Name = "labelJmenoHrace";
            // 
            // OknoPexeso
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelJmenoHrace);
            this.Controls.Add(this.labelHodnotaPocetPokusu);
            this.Controls.Add(this.PocetPokusuPopisek);
            this.Controls.Add(this.labelPocetBodu);
            this.Controls.Add(this.labelScoreValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OknoPexeso";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.ToolStripMenuItem statistikyHerToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialogOtevriHru;
        private System.Windows.Forms.ToolStripMenuItem novaHraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložHruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načtiHruToolStripMenuItem;
        private System.Windows.Forms.Label labelJmenoHrace;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}

