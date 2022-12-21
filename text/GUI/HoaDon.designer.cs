using System.Windows.Forms;

namespace text
{
    partial class HoaDon
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoaDon));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PrintCSV = new System.Windows.Forms.Button();
            this.Switch_from = new System.Windows.Forms.ComboBox();
            this.PrintReceipt = new System.Windows.Forms.Button();
            this.Switch = new System.Windows.Forms.Button();
            this.Switch_to = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Unit = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.FoodName = new System.Windows.Forms.ComboBox();
            this.Category = new System.Windows.Forms.ComboBox();
            this.Quantity = new System.Windows.Forms.NumericUpDown();
            this.Receipt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Table = new System.Windows.Forms.ComboBox();
            this.Payment = new System.Windows.Forms.Button();
            this.Discount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.Tables = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Discount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Turquoise;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Tables, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.05769F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.94231F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 516);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightCyan;
            this.label2.Location = new System.Drawing.Point(395, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "HÓA ĐƠN ĐẶT MÓN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightCyan;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH BÀN ĂN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Controls.Add(this.PrintCSV, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Switch_from, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PrintReceipt, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Switch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Switch_to, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 458);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 55);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // PrintCSV
            // 
            this.PrintCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintCSV.Location = new System.Drawing.Point(344, 3);
            this.PrintCSV.Name = "PrintCSV";
            this.tableLayoutPanel2.SetRowSpan(this.PrintCSV, 2);
            this.PrintCSV.Size = new System.Drawing.Size(39, 49);
            this.PrintCSV.TabIndex = 8;
            this.PrintCSV.Text = "In CSV";
            this.PrintCSV.UseVisualStyleBackColor = true;
            this.PrintCSV.Click += new System.EventHandler(this.PrintCSV_Click);
            // 
            // Switch_from
            // 
            this.Switch_from.BackColor = System.Drawing.Color.PaleGreen;
            this.Switch_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Switch_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Switch_from.FormattingEnabled = true;
            this.Switch_from.Location = new System.Drawing.Point(3, 3);
            this.Switch_from.Name = "Switch_from";
            this.Switch_from.Size = new System.Drawing.Size(150, 21);
            this.Switch_from.TabIndex = 4;
            // 
            // PrintReceipt
            // 
            this.PrintReceipt.BackColor = System.Drawing.Color.NavajoWhite;
            this.PrintReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintReceipt.Image = ((System.Drawing.Image)(resources.GetObject("PrintReceipt.Image")));
            this.PrintReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintReceipt.Location = new System.Drawing.Point(234, 3);
            this.PrintReceipt.Name = "PrintReceipt";
            this.tableLayoutPanel2.SetRowSpan(this.PrintReceipt, 2);
            this.PrintReceipt.Size = new System.Drawing.Size(104, 49);
            this.PrintReceipt.TabIndex = 3;
            this.PrintReceipt.Text = "In hóa đơn";
            this.PrintReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintReceipt.UseVisualStyleBackColor = false;
            // 
            // Switch
            // 
            this.Switch.BackColor = System.Drawing.Color.NavajoWhite;
            this.Switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Switch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Switch.Image = ((System.Drawing.Image)(resources.GetObject("Switch.Image")));
            this.Switch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Switch.Location = new System.Drawing.Point(159, 3);
            this.Switch.Name = "Switch";
            this.tableLayoutPanel2.SetRowSpan(this.Switch, 2);
            this.Switch.Size = new System.Drawing.Size(69, 49);
            this.Switch.TabIndex = 0;
            this.Switch.Text = "Chuyển bàn";
            this.Switch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Switch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Switch.UseVisualStyleBackColor = false;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // Switch_to
            // 
            this.Switch_to.BackColor = System.Drawing.Color.PaleGreen;
            this.Switch_to.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Switch_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Switch_to.FormattingEnabled = true;
            this.Switch_to.Location = new System.Drawing.Point(3, 30);
            this.Switch_to.Name = "Switch_to";
            this.Switch_to.Size = new System.Drawing.Size(150, 21);
            this.Switch_to.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Controls.Add(this.Unit, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.Total, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Add, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.FoodName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Category, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Quantity, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.Receipt, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Delete, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(395, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.392996F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.392996F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.392996F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.82101F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 399);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // Unit
            // 
            this.Unit.BackColor = System.Drawing.Color.PaleGreen;
            this.Unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Unit.Location = new System.Drawing.Point(189, 61);
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Size = new System.Drawing.Size(134, 20);
            this.Unit.TabIndex = 9;
            this.Unit.Text = "0";
            this.Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.Color.PaleGreen;
            this.Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Total.Location = new System.Drawing.Point(3, 61);
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Size = new System.Drawing.Size(180, 20);
            this.Total.TabIndex = 8;
            this.Total.Text = "0";
            this.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.NavajoWhite;
            this.Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.Location = new System.Drawing.Point(189, 3);
            this.Add.Name = "Add";
            this.tableLayoutPanel3.SetRowSpan(this.Add, 2);
            this.Add.Size = new System.Drawing.Size(134, 52);
            this.Add.TabIndex = 4;
            this.Add.Text = "Thêm món";
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // FoodName
            // 
            this.FoodName.BackColor = System.Drawing.Color.PaleGreen;
            this.FoodName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FoodName.FormattingEnabled = true;
            this.FoodName.Location = new System.Drawing.Point(3, 32);
            this.FoodName.Name = "FoodName";
            this.FoodName.Size = new System.Drawing.Size(180, 21);
            this.FoodName.TabIndex = 3;
            this.FoodName.SelectedIndexChanged += new System.EventHandler(this.FoodName_SelectedIndexChanged);
            // 
            // Category
            // 
            this.Category.BackColor = System.Drawing.Color.PaleGreen;
            this.Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Category.FormattingEnabled = true;
            this.Category.Location = new System.Drawing.Point(3, 3);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(180, 21);
            this.Category.TabIndex = 2;
            this.Category.SelectedIndexChanged += new System.EventHandler(this.Category_SelectedIndexChanged);
            // 
            // Quantity
            // 
            this.Quantity.BackColor = System.Drawing.Color.PaleGreen;
            this.Quantity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Quantity.Location = new System.Drawing.Point(329, 64);
            this.Quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(54, 20);
            this.Quantity.TabIndex = 5;
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Receipt
            // 
            this.Receipt.BackColor = System.Drawing.Color.Gainsboro;
            this.Receipt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.tableLayoutPanel3.SetColumnSpan(this.Receipt, 3);
            this.Receipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Receipt.HideSelection = false;
            this.Receipt.Location = new System.Drawing.Point(3, 90);
            this.Receipt.Name = "Receipt";
            this.Receipt.Size = new System.Drawing.Size(380, 306);
            this.Receipt.TabIndex = 6;
            this.Receipt.UseCompatibleStateImageBehavior = false;
            this.Receipt.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đơn giá";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 100;
            // 
            // Delete
            // 
            this.Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete.Location = new System.Drawing.Point(329, 3);
            this.Delete.Name = "Delete";
            this.tableLayoutPanel3.SetRowSpan(this.Delete, 2);
            this.Delete.Size = new System.Drawing.Size(54, 52);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Xoa";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.Controls.Add(this.Table, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Payment, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.Discount, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Price, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(395, 458);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(386, 55);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.Color.PaleGreen;
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Table.FormattingEnabled = true;
            this.Table.Location = new System.Drawing.Point(153, 3);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(110, 21);
            this.Table.TabIndex = 9;
            // 
            // Payment
            // 
            this.Payment.BackColor = System.Drawing.Color.NavajoWhite;
            this.Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Payment.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Payment.Image = ((System.Drawing.Image)(resources.GetObject("Payment.Image")));
            this.Payment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Payment.Location = new System.Drawing.Point(269, 3);
            this.Payment.Name = "Payment";
            this.tableLayoutPanel4.SetRowSpan(this.Payment, 2);
            this.Payment.Size = new System.Drawing.Size(114, 49);
            this.Payment.TabIndex = 8;
            this.Payment.Text = "Thanh toán";
            this.Payment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Payment.UseVisualStyleBackColor = false;
            this.Payment.Click += new System.EventHandler(this.Payment_Click);
            // 
            // Discount
            // 
            this.Discount.BackColor = System.Drawing.Color.PaleGreen;
            this.Discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Discount.Location = new System.Drawing.Point(103, 4);
            this.Discount.Name = "Discount";
            this.Discount.Size = new System.Drawing.Size(44, 20);
            this.Discount.TabIndex = 6;
            this.Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Discount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Discount.ValueChanged += new System.EventHandler(this.Discount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Thành tiền";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giảm giá (%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Price
            // 
            this.Price.BackColor = System.Drawing.Color.PaleGreen;
            this.tableLayoutPanel4.SetColumnSpan(this.Price, 2);
            this.Price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Price.Location = new System.Drawing.Point(103, 30);
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Size = new System.Drawing.Size(160, 20);
            this.Price.TabIndex = 7;
            this.Price.Text = "0";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Tables
            // 
            this.Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tables.Location = new System.Drawing.Point(3, 53);
            this.Tables.Name = "Tables";
            this.Tables.Size = new System.Drawing.Size(386, 399);
            this.Tables.TabIndex = 5;
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HoaDon";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Discount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button PrintReceipt;
        private Button Switch;
        private ComboBox Switch_to;
        private TableLayoutPanel tableLayoutPanel3;
        private Button Add;
        private ComboBox FoodName;
        private ComboBox Category;
        private ListView Receipt;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private TableLayoutPanel tableLayoutPanel4;
        private Button Payment;
        private NumericUpDown Discount;
        private TextBox Price;
        private FlowLayoutPanel Tables;
        private NumericUpDown Quantity;
        private Button Delete;
        private ComboBox Switch_from;
        private Button PrintCSV;
        private TextBox Unit;
        private TextBox Total;
        private Label label4;
        private Label label3;
        private ComboBox Table;
    }
}