namespace text.GUI
{
    partial class Quenmk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quenmk));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ClickThoat = new System.Windows.Forms.PictureBox();
            this.txt_tht = new System.Windows.Forms.TextBox();
            this.txt_hmk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_tl = new System.Windows.Forms.Button();
            this.btn_hmk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClickThoat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ClickThoat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 46);
            this.panel1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Location = new System.Drawing.Point(147, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "QUÊN MẬT KHẨU";
            // 
            // ClickThoat
            // 
            this.ClickThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClickThoat.BackgroundImage")));
            this.ClickThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClickThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClickThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClickThoat.Location = new System.Drawing.Point(391, 0);
            this.ClickThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClickThoat.Name = "ClickThoat";
            this.ClickThoat.Size = new System.Drawing.Size(61, 46);
            this.ClickThoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ClickThoat.TabIndex = 0;
            this.ClickThoat.TabStop = false;
            this.ClickThoat.Click += new System.EventHandler(this.ClickThoat_Click);
            // 
            // txt_tht
            // 
            this.txt_tht.Location = new System.Drawing.Point(197, 111);
            this.txt_tht.Name = "txt_tht";
            this.txt_tht.Size = new System.Drawing.Size(220, 22);
            this.txt_tht.TabIndex = 23;
            // 
            // txt_hmk
            // 
            this.txt_hmk.Location = new System.Drawing.Point(197, 186);
            this.txt_hmk.Name = "txt_hmk";
            this.txt_hmk.Size = new System.Drawing.Size(220, 22);
            this.txt_hmk.TabIndex = 24;
            this.txt_hmk.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(58, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tên hiển thị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label3.Location = new System.Drawing.Point(58, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 19);
            this.label3.TabIndex = 26;
            this.label3.Visible = false;
            // 
            // btn_tl
            // 
            this.btn_tl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tl.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_tl.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btn_tl.Location = new System.Drawing.Point(292, 256);
            this.btn_tl.Name = "btn_tl";
            this.btn_tl.Size = new System.Drawing.Size(125, 54);
            this.btn_tl.TabIndex = 27;
            this.btn_tl.Text = "Trở lại";
            this.btn_tl.UseVisualStyleBackColor = true;
            this.btn_tl.Click += new System.EventHandler(this.btn_tl_Click);
            // 
            // btn_hmk
            // 
            this.btn_hmk.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_hmk.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btn_hmk.Location = new System.Drawing.Point(62, 256);
            this.btn_hmk.Name = "btn_hmk";
            this.btn_hmk.Size = new System.Drawing.Size(159, 54);
            this.btn_hmk.TabIndex = 28;
            this.btn_hmk.Text = "Hiển thị mật Khẩu ";
            this.btn_hmk.UseVisualStyleBackColor = true;
            this.btn_hmk.Click += new System.EventHandler(this.btn_hmk_Click);
            // 
            // Quenmk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(452, 368);
            this.Controls.Add(this.btn_hmk);
            this.Controls.Add(this.btn_tl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_hmk);
            this.Controls.Add(this.txt_tht);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Quenmk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quenmk";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClickThoat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ClickThoat;
        private System.Windows.Forms.TextBox txt_tht;
        private System.Windows.Forms.TextBox txt_hmk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_tl;
        private System.Windows.Forms.Button btn_hmk;
    }
}