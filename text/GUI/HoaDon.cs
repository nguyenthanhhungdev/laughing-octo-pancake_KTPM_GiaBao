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
            Switch_to.DisplayMember = "Name";
            Switch_to.ValueMember = "ID";
            Switch_from.DisplayMember = "Name";
            Switch_from.ValueMember = "ID";
            Table.DisplayMember = "Name";
            Table.ValueMember = "ID";

            Discount.Value = 10;
            RefreshAll();
        }
        private void RefreshCategory()
        {
            Category.SelectedIndex = -1;
            var foodCategories = FoodCategoryDAO.getFoodCategories();
            var rowList = foodCategories.Select(category => new DbCombobox() { ID = category.FoodId, Name = category.Name }).ToList();
            Category.DataSource = rowList;
            RefreshName();
        }
        private void RefreshName()
        {
            FoodName.SelectedIndex = -1;
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
            Total.Text = sum.ToString();
            Price.Text = (sum - sum / 100 * Discount.Value).ToString();
        }
        private void RefreshUnit()
        {
            Unit.Text = FoodDAO.GetFood((int)FoodName.SelectedValue).Price.ToString();
        }
        private List<DTO.DsbanDTO> RefreshSwitch()
        {
            var tables = DsbanDAO.GetTables();
            var rowList = tables.Select(table => new DbCombobox() { ID = table.Id, Name = table.Name }).ToList();
            Switch_to.DataSource = rowList;
            Switch_from.DataSource = new List<DbCombobox>(rowList);
            if (Table.DataSource == null)
            {
                Table.DataSource = new List<DbCombobox>(rowList);
            }
            return tables;
        }
        private void RefreshTables()
        {
            Tables.Controls.Clear();
            Tables.Controls.AddRange(RefreshSwitch().Select(table => new TableButton()
            {
                Tag = table.Id,
                Mode = ConvertFromTinhtrangban(table.Trangthai),
                Text = table.Name
            })
                .ToArray());
        }
        private void RefreshAll()
        {
            RefreshTables();
            RefreshCategory();
        }
        private void Switch_Click(object sender, EventArgs e)
        {
            if (Switch_from.SelectedIndex == -1)
            {
                return;
            }
            if (Switch_to.SelectedIndex == -1)
            {
                return;
            }
            Swap2Table((TableButton)Tables.Controls[Switch_from.SelectedIndex], (TableButton)Tables.Controls[Switch_to.SelectedIndex]);
            RefreshTables();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (FoodName.SelectedIndex == -1)
            {
                return;
            }
            var daFood = FoodDAO.GetFood((int)FoodName.SelectedValue);
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
            var details = GrabReceiptDetails();
            if (details == null)
            {
                return;
            }
            if (BillDAO.InsertBill(new DTO.Bill(Program.CurrentlyLoggedIn.id, 1, (int)Discount.Value, Decimal.Parse(Price.Text), (int)Table.SelectedValue), details))
            {
                MessageBox.Show("Luu hoa don vao CSDL", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Receipt.Items.Clear();
            }
            else
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
        private void Swap2Table(TableButton first, TableButton second)
        {
            DsbanDAO.UpdateTable((int)first.Tag, second.Mode);
            DsbanDAO.UpdateTable((int)second.Tag, first.Mode);
        }
        private List<DTO.BillDetail> GrabReceiptDetails()
        {
            var details = new List<DTO.BillDetail>();
            foreach (ListViewItem item in Receipt.Items)
            {
                details.Add(new DTO.BillDetail((int)item.Tag, int.Parse(item.SubItems[2].Text)));
            }
            return details.Count == 0 ? null : details;
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
            private bool isNew = true;
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
                if (isNew)
                {
                    isNew = false;
                    return;
                }
                DsbanDAO.UpdateTable((int)Tag, Mode);
            }
        }
        public static string ConvertToTinhtrangban(Boolean trueDayfalseTrong)
        {
            return trueDayfalseTrong ? "yes" : "no";
        }
        public static Boolean ConvertFromTinhtrangban(string yesDaynoTrong)
        {
            return String.Equals(yesDaynoTrong, "yes", StringComparison.OrdinalIgnoreCase) || (String.Equals(yesDaynoTrong, "no", StringComparison.OrdinalIgnoreCase) ? false
                : throw new ArgumentException("Invalid Tinhtrangban value"));
        }
        private struct DbCombobox
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category.SelectedIndex < 0)
            {
                return;
            }
            RefreshName();
        }

        private void FoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FoodName.SelectedIndex < 0)
            {
                return;
            }
            RefreshUnit();
        }

        private void PrintReceipt_Click(object sender, EventArgs e)
        {
            var details = new List<ReceiptItem>();
            if (Receipt.Items.Count == 0)
            {
                details.Add(new ReceiptItem() { id = "N/A", name = "N/A", quantity = "N/A", subtotal = "N/A", unit = "N/A" });
            }
            else
            {
                foreach(ListViewItem item in Receipt.Items)
                {
                    details.Add(new ReceiptItem()
                    {
                        id = ((int)item.Tag).ToString(),
                        name = item.SubItems[0].Text,
                        unit = decimal.Parse(item.SubItems[1].Text).ToString(),
                        quantity = int.Parse(item.SubItems[2].Text).ToString(),
                        subtotal = decimal.Parse(item.SubItems[3].Text).ToString()
                    });
                }
            }
            var rpt = new ReceiptRuntimeTextTemplate
            {
                Session = new Dictionary<string, object>()
            };
            rpt.Session["Model"] = new ReceiptModel()
            {
                id = "Preview N/A",
                cashier = Program.CurrentlyLoggedIn.id + " - " + (Program.CurrentlyLoggedIn.username ?? "N/A"),
                date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                table = ((DbCombobox)Table.SelectedItem).ID + " - " + ((DbCombobox)Table.SelectedItem).Name,
                discount = Discount.Value + "%",
                total = Total.Text.ToString(),
                totalAfterDiscount = Price.Text.ToString(),
                items = details
            };
            rpt.Initialize();
            var receiptViewer = new GUI.ReceiptPreview();
            receiptViewer.SetWebViewer(rpt.TransformText());
            receiptViewer.ShowDialog();
        }
    }
}