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
using System.Xml.Linq;
using text.DAO;
using text.GUI;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace text
{
    public partial class TaiKhoan : Form
    {
        string Quyen = "";

        public TaiKhoan(string quyen)
        {
            InitializeComponent();
            this.Quyen = quyen;

        }
        public void lamtrong()
        {
            cbb_UserType.Enabled = true;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            btnResetPW.Enabled = false;
            txt_UserName.Enabled = true;
            btn_them.Enabled = true;
            txt_UserName.Text = "";
            txt_Name.Text = "";
            txt_UserName.Focus();
        }

        public bool chestdata()
        {
            string tk = txt_UserName.Text;
            string tenht = txt_Name.Text;
            string sql = "select Tentk,Tenhienthi from Taikhoan where Tentk= '" + tk + "' or  Tenhienthi='" + tenht + "'";
            DataTable rs = DataProvider.Instance.ExecuteQuery(sql);

            if (rs.Rows.Count > 0)
            {
                MessageBox.Show("Tên này đã được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_UserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_UserName.Text))

            {
                MessageBox.Show("Bạn  chưa nhập userName", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_UserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("Bạn  chưa nhập tên tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Name.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbb_UserType.Text))
            {
                MessageBox.Show("Bạn  chưa nhập ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbb_UserType.Focus();
                return false;
            }

            return true;
        }
        private void ketcsdl()
        {
            string query = "select  Id ,Tentk as N'Tên tài khoản ',Tenhienthi as N'Tên hiển thị',Loai as 'Loại' from Taikhoan ORDER BY Loai ASC";
            DataProvider dataProvider = new DataProvider();
            dataGridView1.DataSource = dataProvider.ExecuteQuery(query);
        }
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int Id = Convert.ToInt32(txt_id.Text);

                    if (TaikhoanDao.Instance.Deletetk(Id))
                    {
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ketcsdl();
                    }
                    lamtrong();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnResetPW_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                DatLaiMatKhau datlaimk = new DatLaiMatKhau(Quyen);
                DatLaiMatKhau.tendn = txt_UserName.Text;
                DatLaiMatKhau.tenhienthi = txt_Name.Text;
                datlaimk.ShowDialog();
            }
            else
            {
                DnDoimk dnDoimk = new DnDoimk();
                DnDoimk.tendn = txt_UserName.Text;
                DnDoimk.tenhienthi = txt_Name.Text;

                dnDoimk.ShowDialog();
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            lamtrong();
            cbb_UserType.SelectedIndex = 1;
            ketcsdl();
            dataGridView1.Columns["id"].Visible = false;
            if (Quyen != "admin")
            {
                cbb_UserType.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbb_UserType.Enabled = false;
            btn_them.Enabled = false;
            btnResetPW.Enabled = true;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;

            int i;
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            i = dataGridView1.CurrentRow.Index;
            if (Quyen == "admin")
            {
                cbb_UserType.Enabled = true;
                if (i == 0)
                {
                    btn_xoa.Enabled = false;
                }
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_UserName.Text = row.Cells[1].Value.ToString();
                txt_Name.Text = row.Cells[2].Value.ToString();
                cbb_UserType.Text = row.Cells[3].Value.ToString();
            }
            else if (i == 0)
            {
                lamtrong();
                cbb_UserType.Enabled = false;
                MessageBox.Show("Xin lỗi bạn không có quyền admin", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_UserName.Text = row.Cells[1].Value.ToString();
                txt_Name.Text = row.Cells[2].Value.ToString();
                cbb_UserType.Text = row.Cells[3].Value.ToString();
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                if (chestdata())
                {
                    string Tentk = txt_UserName.Text;
                    string Loai = cbb_UserType.Text;
                    string Tenht = txt_Name.Text;
                    if (TaikhoanDao.Instance.instk(Tentk, Tenht, Loai))
                    {
                        MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ketcsdl();
                    }
                    lamtrong();
                }
            }
            else { MessageBox.Show("Xin lỗi bạn phải là admin mới mới có quyền", "Cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            ketcsdl();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                lamtrong();
            }
            else
            {
                lamtrong();
                cbb_UserType.Enabled = false;
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string Tentk = txt_UserName.Text;
            string Loai = cbb_UserType.Text;
            string Tenht = txt_Name.Text;
            int id = Convert.ToInt32(txt_id.Text);
            if (chestdata())
            {
                if (TaikhoanDao.Instance.updatetk(Tentk, Tenht, Loai, id))
                {
                    MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ketcsdl();
                    lamtrong();
                }
            }

        }
    }
}
