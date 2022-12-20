namespace text.GUI
{
    partial class DnDoimk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DnDoimk));
            this.panel1 = new System.Windows.Forms.Panel();
            this.clickThoat = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clickThoat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clickThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 0;
            // 
            // clickThoat
            // 
            this.clickThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clickThoat.BackgroundImage")));
            this.clickThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clickThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clickThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.clickThoat.Location = new System.Drawing.Point(726, 0);
            this.clickThoat.Name = "clickThoat";
            this.clickThoat.Size = new System.Drawing.Size(74, 48);
            this.clickThoat.TabIndex = 0;
            this.clickThoat.TabStop = false;
            this.clickThoat.Click += new System.EventHandler(this.clickThoat_Click);
            // 
            // DnDoimk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DnDoimk";
            this.Text = "DnDoimk";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clickThoat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox clickThoat;
    }
}