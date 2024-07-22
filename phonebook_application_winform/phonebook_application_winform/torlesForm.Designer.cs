namespace phonebook_application_winform
{
    partial class torlesForm
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
            this.visszabtn = new System.Windows.Forms.Button();
            this.tellist = new System.Windows.Forms.ListBox();
            this.torlesbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // visszabtn
            // 
            this.visszabtn.Location = new System.Drawing.Point(12, 399);
            this.visszabtn.Name = "visszabtn";
            this.visszabtn.Size = new System.Drawing.Size(107, 23);
            this.visszabtn.TabIndex = 69;
            this.visszabtn.Text = "Vissza a menübe";
            this.visszabtn.UseVisualStyleBackColor = true;
            this.visszabtn.Click += new System.EventHandler(this.visszabtn_Click);
            // 
            // tellist
            // 
            this.tellist.BackColor = System.Drawing.SystemColors.Menu;
            this.tellist.FormattingEnabled = true;
            this.tellist.Location = new System.Drawing.Point(12, 12);
            this.tellist.Name = "tellist";
            this.tellist.Size = new System.Drawing.Size(229, 381);
            this.tellist.TabIndex = 52;
            // 
            // torlesbtn
            // 
            this.torlesbtn.Location = new System.Drawing.Point(156, 399);
            this.torlesbtn.Name = "torlesbtn";
            this.torlesbtn.Size = new System.Drawing.Size(85, 23);
            this.torlesbtn.TabIndex = 70;
            this.torlesbtn.Text = "Törlés";
            this.torlesbtn.UseVisualStyleBackColor = true;
            this.torlesbtn.Click += new System.EventHandler(this.torlesbtn_Click);
            // 
            // torlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(253, 431);
            this.Controls.Add(this.torlesbtn);
            this.Controls.Add(this.visszabtn);
            this.Controls.Add(this.tellist);
            this.Name = "torlesForm";
            this.Text = "Törlés";
            this.Load += new System.EventHandler(this.torlesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button visszabtn;
        private System.Windows.Forms.ListBox tellist;
        private System.Windows.Forms.Button torlesbtn;
    }
}