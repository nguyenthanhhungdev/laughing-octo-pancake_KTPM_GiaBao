using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using System.Runtime.Remoting.Contexts;
using text.DAO;
using System.Xml.Linq;

namespace text
{
    public partial class DSban : Form
    {
        string Quyen = "";

        public DSban()
        {
            InitializeComponent();

        }

        public DSban(string quyen)
        {
            InitializeComponent();
            this.Quyen = quyen;
        }

        void ketnoicsdl()
        {
            string query = "SELECT Id,Tenban as N'Tên bàn',Tinhtrangban as N'Tình trạng bàn' FROM DSban";
            DataProvider dataProvider = new DataProvider();
            dataGridView1.DataSource = dataProvider.ExecuteQuery(query);
        }

        public bool chestdata()
        {
            if (string.IsNullOrEmpty(txt_id.Text))

            {
                MessageBox.Show("Bạn  chưa nhập ID", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_id.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_tenban.Text))
            {
                MessageBox.Show("Bạn  chưa nhập tên bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenban.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_trangthai.Text))
            {
                MessageBox.Show("Bạn  chưa nhập trạng thái", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_trangthai.Focus();
                return false;
            }
            return true;
        }

        public void lamtrong()
        {
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            txt_id.Enabled = true;
            btn_them.Enabled = true;
            txt_id.Text = "";
            txt_tenban.Text = "";
            txt_trangthai.Text = "";
            txt_id.Focus();
        }
        private void DSban_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            lamtrong();

            txt_id.Focus();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (chestdata())
                {
                    string name = txt_tenban.Text;
                    int id = Convert.ToInt32(txt_id.Text);
                    string trangthai = txt_trangthai.Text;
                    if (DsbanDAO.Instance.insdsb(id, trangthai, name))
                    {
                        MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ketnoicsdl();
                    }
                    txt_id.Focus();
                    lamtrong();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txt_id.Text);

                    if (DsbanDAO.Instance.Deletedsb(id))
                    {
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        ketnoicsdl();
                    }
                    txt_id.Focus();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            lamtrong();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string name = txt_tenban.Text;
            int id = Convert.ToInt32(txt_id.Text);
            string trangthai = txt_trangthai.Text;
            if (chestdata())
            {
                if (DsbanDAO.Instance.updatedsb(id, trangthai, name))
                {
                    MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ketnoicsdl();
                }
            }
            lamtrong();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Enabled = false;
            btn_them.Enabled = false;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;

            int i;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            i = dataGridView1.CurrentRow.Index;
            txt_id.Text = row.Cells[0].Value.ToString();
            txt_tenban.Text = row.Cells[1].Value.ToString();
            txt_trangthai.Text = row.Cells[2].Value.ToString();
        }
    }
}
