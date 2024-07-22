namespace phonebook_application_winform
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ujhozzaadasaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listazasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilepesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modositasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keresesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.torlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(-7, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "ÜDVÖZÖLJÜK A TELEFONKÖNYBEN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ujhozzaadasaToolStripMenuItem,
            this.listazasToolStripMenuItem,
            this.kilepesToolStripMenuItem,
            this.modositasToolStripMenuItem,
            this.keresesToolStripMenuItem,
            this.torlesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ujhozzaadasaToolStripMenuItem
            // 
            this.ujhozzaadasaToolStripMenuItem.Name = "ujhozzaadasaToolStripMenuItem";
            this.ujhozzaadasaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.ujhozzaadasaToolStripMenuItem.Text = "Új hozzáadása";
            this.ujhozzaadasaToolStripMenuItem.Click += new System.EventHandler(this.ujhozzaadasaToolStripMenuItem_Click);
            // 
            // listazasToolStripMenuItem
            // 
            this.listazasToolStripMenuItem.Name = "listazasToolStripMenuItem";
            this.listazasToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.listazasToolStripMenuItem.Text = "Listázás";
            this.listazasToolStripMenuItem.Click += new System.EventHandler(this.listazasToolStripMenuItem_Click);
            // 
            // kilepesToolStripMenuItem
            // 
            this.kilepesToolStripMenuItem.Name = "kilepesToolStripMenuItem";
            this.kilepesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kilepesToolStripMenuItem.Text = "Kilépés";
            this.kilepesToolStripMenuItem.Click += new System.EventHandler(this.kilepesToolStripMenuItem_Click);
            // 
            // modositasToolStripMenuItem
            // 
            this.modositasToolStripMenuItem.Name = "modositasToolStripMenuItem";
            this.modositasToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.modositasToolStripMenuItem.Text = "Módosítás";
            this.modositasToolStripMenuItem.Click += new System.EventHandler(this.modositasToolStripMenuItem_Click);
            // 
            // keresesToolStripMenuItem
            // 
            this.keresesToolStripMenuItem.Name = "keresesToolStripMenuItem";
            this.keresesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.keresesToolStripMenuItem.Text = "Keresés";
            this.keresesToolStripMenuItem.Click += new System.EventHandler(this.keresesToolStripMenuItem_Click);
            // 
            // torlesToolStripMenuItem
            // 
            this.torlesToolStripMenuItem.Name = "torlesToolStripMenuItem";
            this.torlesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.torlesToolStripMenuItem.Text = "Törlés";
            this.torlesToolStripMenuItem.Click += new System.EventHandler(this.torlesToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(593, 406);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menü";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ujhozzaadasaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listazasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilepesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modositasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keresesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem torlesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}