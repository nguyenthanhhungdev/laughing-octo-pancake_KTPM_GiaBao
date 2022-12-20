using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using text.DAO;

namespace text
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            Category.DisplayMember = "Name";
            Category.ValueMember = "ID";
            FoodName.DisplayMember = "Name";
            FoodName.ValueMember = "ID";
            RefreshAll();
        }
        private void RefreshCategory()
        {
            var foodCategories = FoodCategoryDAO.getFoodCategories();
            var rowList = foodCategories.Select(category => new DbCombobox() { ID = category.FoodId, Name = category.Name }).ToList();
            Category.DataSource = rowList;
            RefreshName();
        }
        private void RefreshName()
        {
            var foods = FoodDAO.Instance.GetFoodByCateGoryID((int)Category.SelectedValue);
            var rowList = foods.Select(food => new DbCombobox() { ID = food.ID, Name = food.Name }).ToList();
            FoodName.DataSource = rowList;
        }
        private void RefreshPrice()
        {
            decimal sum = 0;
            foreach (ListViewItem item in Receipt.Items)
            {
                sum += Decimal.Parse(item.SubItems[3].Text);
            }
            Price.Text = sum.ToString();
        }

        // TODO: CHUA CO DAO DTO DSBan
        private void RefreshSwitch()
        {
            //var rowList = new List<DbCombobox>();
            //SqlDataReader data = new SqlCommand("SELECT Id, Tenban FROM DSBan", database).ExecuteReader();
            //while (data.Read())
            //{
            //    rowList.Add(new DbCombobox() { ID = data.GetInt32(data.GetOrdinal("Id")), Name = data.GetString(data.GetOrdinal("Tenban")) });
            //}
            //Switch_to.DataSource = rowList;
            //Switch_to.DisplayMember = "Name";
            //Switch_to.ValueMember = "ID";
            //Switch_from.DataSource = rowList;
            //Switch_from.DisplayMember = "Name";
            //Switch_from.ValueMember = "ID";
        }
        private void RefreshTables()
        {
            //var rowList = new List<TableButton>();
            //SqlDataReader data = new SqlCommand("SELECT Id, Tinhtrangban, Tenban FROM DSBan ORDER BY Id", database).ExecuteReader();
            //while (data.Read())
            //{
            //    rowList.Add(new TableButton()
            //    {
            //        Tag = data.GetInt32(data.GetOrdinal("Id")),
            //        Mode = ConvertFromTinhtrangban(data.GetString(data.GetOrdinal("Tinhtrangban"))),
            //        Text = data.GetString(data.GetOrdinal("Tenban"))
            //    });
            //}
            //Tables.Controls.Clear();
            //Tables.Controls.AddRange(rowList.ToArray());
        }
        private void RefreshAll()
        {
            RefreshSwitch();
            RefreshCategory();
        }
        private void Switch_Click(object sender, EventArgs e)
        {
            //if (Switch_from.SelectedIndex == -1)
            //{
            //    return;
            //}
            //if (Switch_to.SelectedIndex == -1)
            //{
            //    return;
            //}
            //SqlDataReader from = new SqlCommand("SELECT TOP 1 Tinhtrangban FROM DSBan WHERE Id=" + Switch_from.SelectedValue, database).ExecuteReader();
            //SqlDataReader to = new SqlCommand("SELECT TOP 1 Tinhtrangban FROM DSBan WHERE Id=" + Switch_to.SelectedValue, database).ExecuteReader();
            //if (from.Read() && to.Read())
            //{
            //    new SqlCommand("UPDATE DSBan SET Tinhtrangban=" + from.GetString(from.GetOrdinal("Tinhtrangban"))
            //        + " WHERE Id=" + Switch_to.SelectedValue, database).ExecuteNonQuery();
            //    new SqlCommand("UPDATE DSBan SET Tinhtrangban=" + to.GetString(to.GetOrdinal("Tinhtrangban"))
            //        + " WHERE Id=" + Switch_from.SelectedValue, database).ExecuteNonQuery();
            //}
            //RefreshTables();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (FoodName.SelectedIndex == -1)
            {
                return;
            }
            var daFood = FoodDAO.Instance.GetFoodByCateGoryID((int)FoodName.SelectedValue)[0];
            ReceiptAdd(daFood.ID, daFood.Name, daFood.Price, (int)Quantity.Value);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in Receipt.SelectedItems)
            {
                Receipt.Items.Remove(item);
            }
            RefreshPrice();
        }
        private void Payment_Click(object sender, EventArgs e)
        {
            var details = new List<DTO.BillDetail>();
            foreach(ListViewItem item in Receipt.Items)
            {
                details.Add(new DTO.BillDetail((int)item.Tag, int.Parse(item.SubItems[2].Text)));
            }
            if (BillDAO.InsertBill(new DTO.Bill(Program.currentlyLoggedInAs, 1, (int)Discount.Value, Decimal.Parse(Price.Text)), details))
            {
                MessageBox.Show("Luu hoa don vao CSDL", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Receipt.Clear();
            } else
            {
                MessageBox.Show("Luu hoa don vao CSDL that bai", "Thong bao loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintCSV_Click(object sender, EventArgs e)
        {
            if (Receipt.Items.Count <= 0)
            {
                return;
            }
            FolderBrowserDialog browser = new FolderBrowserDialog();
            DialogResult = browser.ShowDialog();
            if (DialogResult != DialogResult.OK)
            {
                return;
            }
            string path = browser.SelectedPath;
            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Ten mon,Don gia,So luong,Thanh tien");
            foreach (ListViewItem item in Receipt.Items)
            {
                csv.AppendLine(String.Join(",", item.SubItems));
            }
            csv.AppendLine(",,," + Price.Text);
            try
            {
                System.IO.File.WriteAllText(path, csv.ToString());
                MessageBox.Show("Luu file thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Luu file khong duoc", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Discount_ValueChanged(object sender, EventArgs e)
        {
            RefreshPrice();
        }
        private void ReceiptAdd(int id, String name, decimal price, int quantity)
        {
            var item = new ListViewItem(new String[] { name, price.ToString(), quantity.ToString(), (price * quantity).ToString() })
            {
                Tag = id
            };
            Receipt.Items.Add(item);
            RefreshPrice();
        }
        private partial class TableButton : Button
        {
            public TableButton() : base()
            {
                Size = new System.Drawing.Size(91, 92);
                TextAlign = System.Drawing.ContentAlignment.TopLeft;
                TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
                UseVisualStyleBackColor = false;
            }
            private Boolean mode;
            public Boolean Mode
            {
                get
                {
                    return mode;
                }
                set
                {
                    mode = value;
                    UpdateMode();
                }
            }
            private void UpdateMode()
            {
                if (mode)
                {
                    BackColor = System.Drawing.Color.Tomato;
                    Image = global::text.Properties.Resources.conference_room;
                }
                else
                {
                    BackColor = System.Drawing.Color.Lime;
                    Image = global::text.Properties.Resources.conference_room_colorized;
                }
                OnModeChange();
            }
            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Mode = !Mode;
            }
            private void OnModeChange()
            {
                new SqlCommand("UPDATE DSBan SET Tinhtrangban=" + Mode + " WHERE Id=" + Tag).ExecuteNonQuery();
            }
        }
        private string ConvertToTinhtrangban(Boolean trueDayfalseTrong)
        {
            return trueDayfalseTrong ? "yes" : "no";
        }
        private Boolean ConvertFromTinhtrangban(string yesDaynoTrong)
        {
            return String.Equals(yesDaynoTrong, "yes", StringComparison.OrdinalIgnoreCase) ? true
                : String.Equals(yesDaynoTrong, "no", StringComparison.OrdinalIgnoreCase) ? false
                : throw new ArgumentException("Invalid Tinhtrangban value");
        }
        private struct DbCombobox
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public struct DbTableButton
        {
            public int ID { get; set; }
            public Boolean Mode { get; set; }
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category.SelectedIndex < 0)
            {
                return;
            }
            RefreshName();
        }
    }
}