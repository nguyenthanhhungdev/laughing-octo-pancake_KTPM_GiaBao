using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using text.DAO;
using text.DTO;

namespace text
{
    public partial class ThucDon : Form
    {
        BindingSource foodList = new BindingSource();
        public ThucDon()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            loadFoodList();
            loadFoodBinding();
            loadCateGory();
        }
        void loadFoodList()
        {   
            string query = "SELECT * FROM Food";
            DataProvider dataProvider = new DataProvider();
            dgvMenu.DataSource = dataProvider.ExecuteQuery(query);  
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        //Load CateGory
        void loadCateGory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbbCateGory.DataSource = listCategory;
            cbbCateGory.DisplayMember = "name";
        }

        //Load CateGory ID
        void loadFoodListByCateGoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCateGoryID(id);
            cbbCateGory.DataSource = listFood;
            cbbCateGory.DisplayMember = "name";
        }
        //Check input
        bool checkInput()
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbCateGory.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbCateGory.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(nudPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập mức giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudPrice.Focus();
                return false;
            }
            return true;
        }

        //DataBinding
        public void loadFoodBinding()
        {
            txtName.DataBindings.Add(new Binding("Text", dgvMenu.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtId.DataBindings.Add(new Binding("Text", dgvMenu.DataSource, "Id", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvMenu.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }


        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbCateGory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            Category item = cb.SelectedItem as Category;
            loadFoodListByCateGoryID(id);
        }

        //Insert Food
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int categoryID = (cbbCateGory.SelectedItem as Category).ID;
            float price = (float)nudPrice.Value;
            
            if (checkInput() && FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm thành công");
                loadFoodList();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm món!");
            } 
        }

  
        private void btnEdit_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            int categoryID = (cbbCateGory.SelectedItem as Category).ID;
            float price = (float)nudPrice.Value;
            int id = Convert.ToInt32(txtId.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                loadFoodList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                loadFoodList();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedCells.Count > 0)
                {
                    int id = (int)dgvMenu.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbbCateGory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbbCateGory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbbCateGory.SelectedIndex = index;
                }
            }
            catch { }
        }


        List<Food> SearhFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = SearhFoodByName(txtSearchFood.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadFoodList();
        }
    }
}
